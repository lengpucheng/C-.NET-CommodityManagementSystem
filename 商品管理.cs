using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 商品管理系统
{
    public partial class 商品管理 : Form
    {
        private Boolean 是否点关闭 = true;
        private Form 上个界面;
        private int 行 = 0;
        private int 列 = 0;
        private Boolean 编辑模式 = false;
        private Boolean 查询模式 = false;
        private 商品 sp = new 商品();
        public 商品管理(Form 父级)
        {
            InitializeComponent();
            上个界面 = 父级;
        }

        //退出登录
        private void button1_Click(object sender, EventArgs e)
        {
            是否点关闭 = false;
            this.Close();
            系统.退出登录();
        }

        private void 商品管理_Load(object sender, EventArgs e)
        {
            用户名.Text = 系统.获取登录用户().姓名();

            数量类别.SelectedIndex = 0;
            数量条件.SelectedIndex = 0;
            属性类别.SelectedIndex=0;
            显示数据();
        }
        //回到上一个
        private void button2_Click(object sender, EventArgs e)
        {
            是否点关闭 = false;
            this.Close();
            上个界面.Show();
        }

        private void 商品管理_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (是否点关闭)
                系统.关闭软件();
            else
                是否点关闭 = true;
        }


        //显示数据
        private void 显示数据()
        {
            //获取链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            String sql = "SELECT * FROM commodity";
            //执行
            MySqlCommand command = new MySqlCommand(sql, cnn);
            //读取
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            //建立本地的数据流
            DataSet ds = new DataSet();
            //把数据放入ds中
            adapter.Fill(ds);
            //关闭数据链接
            cnn.Close();
            //显示数据 从 ds---》DataGridView
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            //标题栏
            dataGridView1.Columns["id"].HeaderText = "编号";
            dataGridView1.Columns["Barcode"].HeaderText = "条码";
            dataGridView1.Columns["name"].HeaderText = "名称";
            dataGridView1.Columns["factory"].HeaderText = "生产厂家";
            dataGridView1.Columns["category"].HeaderText = "类别";
            dataGridView1.Columns["price"].HeaderText = "价格";
            dataGridView1.Columns["sales"].HeaderText = "销量";
            dataGridView1.Columns["sum"].HeaderText = "库存";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        


        //编辑前
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (编辑模式)
                {
                    行 = dataGridView1.CurrentCell.RowIndex;
                    列 = dataGridView1.CurrentCell.ColumnIndex;
                    sp = new 商品();
                    sp.编号 = int.Parse(dataGridView1.Rows[行].Cells[0].Value.ToString());
                    sp.条码 = dataGridView1.Rows[行].Cells[1].Value.ToString();
                    sp.名称 = dataGridView1.Rows[行].Cells[2].Value.ToString();
                    sp.厂家 = dataGridView1.Rows[行].Cells[3].Value.ToString();
                    sp.类别 = dataGridView1.Rows[行].Cells[4].Value.ToString();
                    sp.价格 = Double.Parse(dataGridView1.Rows[行].Cells[5].Value.ToString());
                    sp.销量 = int.Parse(dataGridView1.Rows[行].Cells[6].Value.ToString());
                    sp.库存 = int.Parse(dataGridView1.Rows[行].Cells[7].Value.ToString());
                }
            }
            catch (Exception) {
                MessageBox.Show("操作异常！");
            }


        }

        //编辑后
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (编辑模式)
                {
                    sp.条码 = dataGridView1.Rows[行].Cells[1].Value.ToString();
                    sp.名称 = dataGridView1.Rows[行].Cells[2].Value.ToString();
                    sp.厂家 = dataGridView1.Rows[行].Cells[3].Value.ToString();
                    sp.类别 = dataGridView1.Rows[行].Cells[4].Value.ToString();
                    sp.价格 = Double.Parse(dataGridView1.Rows[行].Cells[5].Value.ToString());
                    sp.销量 = int.Parse(dataGridView1.Rows[行].Cells[6].Value.ToString());
                    sp.库存 = int.Parse(dataGridView1.Rows[行].Cells[7].Value.ToString());
                    //sql语句
                    String sql = "UPDATE commodity SET " +
                        "Barcode = '{0}', name = '{1}', factory = '{2}'," +
                        " category = '{3}', price = {4}, sales = {5}, sum = {6} " +
                        "WHERE id = {7}";
                    sql = String.Format(sql, sp.条码, sp.名称, sp.厂家, sp.类别,
                        sp.价格,sp.销量, sp.库存,sp.编号);
                    //打开链接
                    MySqlConnection cnn = 系统.链接();
                    cnn.Open();
                    //执行
                    MySqlCommand command = new MySqlCommand(sql, cnn);
                    command.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("保存成功");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("保存异常！");
            }

        }

        //显示全部
        private void button5_Click(object sender, EventArgs e)
        {
            查询模式 = false;
            显示数据();
        }

        //进入编辑模式
        private void button6_Click(object sender, EventArgs e)
        {
            if (编辑模式) { 
            编辑模式 = false;
                button6.Text = "开启编辑模式";
                MessageBox.Show("编辑已退出，注意！双击修改将不会自动保存！");
            }
            else
            {
                编辑模式 = true;
                button6.Text = "退出编辑模式";
                MessageBox.Show("编辑模式下，双击需要修改的单元格即可自动保存");
            }
        }

        //删除
        private void button4_Click(object sender, EventArgs e)
        {
            //获取当前选中行
            int 删除行 = dataGridView1.CurrentCell.RowIndex;
            //获取选中的编号
            int 编号= int.Parse(dataGridView1.Rows[删除行].Cells[0].Value.ToString());
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            //sql语句
            String sql = "DELETE FROM commodity WHERE id="+编号;
            MessageBox.Show(sql);
            //执行
            MySqlCommand command = new MySqlCommand(sql, cnn);
            command.ExecuteNonQuery();
            cnn.Close();
            //重新显示数据
            显示数据();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //如果不是编辑模式或查询模式就刷新数据
            if(!编辑模式&&!查询模式)
                显示数据();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new 添加数据().Show();
        }

        //数量筛选
        private void button7_Click(object sender, EventArgs e)
        {
            查询模式 = true;
            //获取属性
            String 类型 = "price";
            switch (数量类别.SelectedIndex)
            {
                case 0:
                    类型 = "price";
                    break;
                case 1:
                    类型 = "sales";
                    break;
                case 2:
                    类型 = "sum";
                    break;
            }
            //获取条件
            String 条件 = "=";
            switch (数量条件.SelectedIndex)
            {
                case 0:
                    条件 = "=";
                    break;
                case 1:
                    条件 = ">=";
                    break;
                case 2:
                    条件 = "<=";
                    break;
            }
            //获取目标
            String 数 = 数量.Text.Trim().ToString();
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            //sql语句
            String sql = "SELECT * FROM commodity WHERE " + 类型+条件+数;
            //执行
            MySqlCommand command = new MySqlCommand(sql, cnn);
            //读取
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            //建立本地的数据流
            DataSet ds = new DataSet();
            //把数据放入ds中
            adapter.Fill(ds);
            //关闭数据链接
            cnn.Close();
            //显示数据 从 ds---》DataGridView
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            //标题栏
            dataGridView1.Columns["id"].HeaderText = "编号";
            dataGridView1.Columns["Barcode"].HeaderText = "条码";
            dataGridView1.Columns["name"].HeaderText = "名称";
            dataGridView1.Columns["factory"].HeaderText = "生产厂家";
            dataGridView1.Columns["category"].HeaderText = "类别";
            dataGridView1.Columns["price"].HeaderText = "价格";
            dataGridView1.Columns["sales"].HeaderText = "销量";
            dataGridView1.Columns["sum"].HeaderText = "库存";
        }

        //属性筛选
        private void button8_Click(object sender, EventArgs e)
        {
            查询模式 = true;
            //获取属性
            String 属性 = "Barcode";
            switch (属性类别.SelectedIndex)
            {
                case 0:
                    属性 = "Barcode";
                    break;
                case 1:
                    属性 = "name";
                    break;
                case 2:
                    属性 = "factory";
                    break;
                case 3:
                    属性 = "category";
                    break;
            }
            //获取数值
            String 值 = "'%" + 属性值.Text.Trim() + "%'";
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            //sql语句
            String sql = "SELECT * FROM commodity WHERE "+属性+"  LIKE  "+值 ;
            MessageBox.Show(sql);
            //执行
            MySqlCommand command = new MySqlCommand(sql, cnn);
            //读取
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            //建立本地的数据流
            DataSet ds = new DataSet();
            //把数据放入ds中
            adapter.Fill(ds);
            //关闭数据链接
            cnn.Close();
            //显示数据 从 ds---》DataGridView
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            //标题栏
            dataGridView1.Columns["id"].HeaderText = "编号";
            dataGridView1.Columns["Barcode"].HeaderText = "条码";
            dataGridView1.Columns["name"].HeaderText = "名称";
            dataGridView1.Columns["factory"].HeaderText = "生产厂家";
            dataGridView1.Columns["category"].HeaderText = "类别";
            dataGridView1.Columns["price"].HeaderText = "价格";
            dataGridView1.Columns["sales"].HeaderText = "销量";
            dataGridView1.Columns["sum"].HeaderText = "库存";
        }
    }
}
