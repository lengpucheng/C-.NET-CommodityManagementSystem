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
    public partial class 订单查询 : Form
    {
        private Form 上个页面;
        private Boolean 用户点击关闭 = true;
        public 订单查询(Form 父级)
        {
            InitializeComponent();
            上个页面 = 父级;
        }

        private void 业绩_Load(object sender, EventArgs e)
        {
            用户名.Text = 系统.获取登录用户().姓名();
            数量类别.SelectedIndex = 0;
            数量条件.SelectedIndex = 0;
            属性类别.SelectedIndex = 0;
            显示数据();
        }



        private void 显示数据()
        {
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            String sql = "SELECT * FROM sales";
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
            dataGridView1.Columns["id"].HeaderText = "订单编号";
            dataGridView1.Columns["val"].HeaderText = "订单详情";
            dataGridView1.Columns["amount"].HeaderText = "订单金额";
            dataGridView1.Columns["user_id"].HeaderText = "操作编号";
            dataGridView1.Columns["user"].HeaderText = "收银员姓名";
            dataGridView1.Columns["time"].HeaderText = "时间";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            用户点击关闭 = false;
            this.Close();
            系统.退出登录();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            用户点击关闭 = false;
            上个页面.Show();
            this.Close();
            
        }

        private void 业绩_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (用户点击关闭)
                系统.关闭软件();
            else
                用户点击关闭 = true;
        }


        //筛选
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                数量筛选();
            }
            catch (Exception)
            {
                MessageBox.Show("查询失败！请检测输入格式是否正确\n" +
                    "时间格式为 YYYY-MM-DD或YYYY-MM-DD HH:MM:SS");
            }
        }
        //模糊查询
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                模糊查询();
            }
            catch (Exception)
            {
                MessageBox.Show("查询失败！请检测输入格式是否正确");
            }
        }

        //显示全部
        private void button3_Click(object sender, EventArgs e)
        {
            显示数据();
        }
        //数量筛选mpl
        private void 数量筛选()
        {
            //获取属性
            String 类型 = "amount";
            switch (数量类别.SelectedIndex)
            {
                case 0:
                    类型 = "amount";
                    break;
                case 1:
                    类型 = "time";
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
            String sql = "SELECT * FROM sales WHERE " + 类型 + 条件 +"'"+ 数+"'";
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
            dataGridView1.Columns["id"].HeaderText = "订单编号";
            dataGridView1.Columns["val"].HeaderText = "订单详情";
            dataGridView1.Columns["amount"].HeaderText = "订单金额";
            dataGridView1.Columns["user_id"].HeaderText = "操作编号";
            dataGridView1.Columns["user"].HeaderText = "收银员姓名";
            dataGridView1.Columns["time"].HeaderText = "时间";
        }

        //模糊查询mpl
        private void 模糊查询()
        {
            //获取属性
            String 类型 = "id";
            switch (属性类别.SelectedIndex)
            {
                case 0:
                    类型 = "id";
                    break;
                case 1:
                    类型 = "val";
                    break;
                case 2:
                    类型 = "user";
                    break;
                case 3:
                    类型 = "user_id";
                    break;
            }
            //获取目标
            String 属性 = 属性值.Text.Trim().ToString();
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            //sql语句
            String sql = "SELECT * FROM sales WHERE " + 类型 + " LIKE '%" + 属性 + "%'";
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
            dataGridView1.Columns["id"].HeaderText = "订单编号";
            dataGridView1.Columns["val"].HeaderText = "订单详情";
            dataGridView1.Columns["amount"].HeaderText = "订单金额";
            dataGridView1.Columns["user_id"].HeaderText = "操作编号";
            dataGridView1.Columns["user"].HeaderText = "收银员姓名";
            dataGridView1.Columns["time"].HeaderText = "时间";
        }

        //定时更新
        private void timer1_Tick(object sender, EventArgs e)
        {
            //是否还在线
            if (!系统.还在线吗())
            {
                MessageBox.Show("用户已退出！");
                用户点击关闭 = false;
                this.Close();
                系统.退出登录();
            }
        }
    }
}
