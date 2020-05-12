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
    public partial class 用户管理 : Form
    {
        private Form 上个页面;
        private Boolean 用户点击关闭=true;
        public 用户管理(Form 父级)
        {
            InitializeComponent();
            上个页面 = 父级;
        }

        private void 用户管理_Load(object sender, EventArgs e)
        {
            用户名.Text = 系统.获取登录用户().姓名();
            显示数据();
        }

        private void 显示数据()
        {
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            String sql = "SELECT * FROM user";
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
            dataGridView1.Columns["_id"].HeaderText = "用户编号";
            dataGridView1.Columns["uname"].HeaderText = "用户名";
            dataGridView1.Columns["password"].HeaderText = "密码";
            dataGridView1.Columns["name"].HeaderText = "用户姓名";
            dataGridView1.Columns["role"].HeaderText = "权限";
            dataGridView1.Columns["Sales"].HeaderText = "销售额";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            用户点击关闭 = false;
            上个页面.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            用户点击关闭 = false;
            this.Close();
            系统.退出登录();
        }

        private void 用户管理_FormClosing(object sender, FormClosingEventArgs e)
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
                金额筛选();
            }
            catch (Exception)
            {
                MessageBox.Show("查询失败！请检测输入格式！\n注意：金额需为数字");
            }
        }

      

        //查询
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                模糊查询();
            }
            catch (Exception)
            {
                MessageBox.Show("查询失败！请检测输入格式！");
            }
        }
        //模糊查询
        private void 模糊查询()
        {

            //获取属性
            String 类型 = "name";
            switch (属性类别.SelectedIndex)
            {
                case 0:
                    类型 = "name";
                    break;
                case 1:
                    类型 = "role";
                    break;
                case 2:
                    类型 = "uname";
                    break;
                case 3:
                    类型 = "_id";
                    break;
            }
            //获取目标
            String 属性 = 属性值.Text.Trim().ToString();
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            //sql语句
            String sql = "SELECT * FROM user WHERE " + 类型 + " LIKE '%" + 属性 + "%'";
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
            dataGridView1.Columns["_id"].HeaderText = "用户编号";
            dataGridView1.Columns["uname"].HeaderText = "用户名";
            dataGridView1.Columns["password"].HeaderText = "密码";
            dataGridView1.Columns["name"].HeaderText = "用户姓名";
            dataGridView1.Columns["role"].HeaderText = "权限";
            dataGridView1.Columns["Sales"].HeaderText = "销售额";
        }
        //金额筛选
        private void 金额筛选()
        {
            //获取属性
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
            String sql = "SELECT * FROM user WHERE Sales" + 条件 + "'" + 数 + "'";
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
            dataGridView1.Columns["_id"].HeaderText = "用户编号";
            dataGridView1.Columns["uname"].HeaderText = "用户名";
            dataGridView1.Columns["password"].HeaderText = "密码";
            dataGridView1.Columns["name"].HeaderText = "用户姓名";
            dataGridView1.Columns["role"].HeaderText = "权限";
            dataGridView1.Columns["Sales"].HeaderText = "销售额";
        }

        //显示全部
        private void button5_Click(object sender, EventArgs e)
        {
            显示数据();
        }

        //编辑
        private void button6_Click(object sender, EventArgs e)
        {
            用户 user = new 用户();
            user.setID(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            user.set用户名((string)dataGridView1.CurrentRow.Cells[1].Value.ToString());
            user.set密码((string)dataGridView1.CurrentRow.Cells[2].Value.ToString());
            user.set姓名((string)dataGridView1.CurrentRow.Cells[3].Value.ToString());
            if ("管理员".Equals((string)dataGridView1.CurrentRow.Cells[4].Value.ToString()))
                user.set身份管理员();
            else
                user.set身份用户();
            new 注册界面(user).Show();
        }

        //添加用户
        private void button3_Click(object sender, EventArgs e)
        {
            new 注册界面().Show();
        }

        //删除
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                删除用户();
            }
            catch (Exception)
            {
                MessageBox.Show("删除失败！");
            }
        }

        //删除用户
        private void 删除用户()
        {
            用户 user = new 用户();
            user.setID(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            string sql = "DELETE FROM user WHERE _id=" + user.ID();
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            //执行
            MySqlCommand command = new MySqlCommand(sql, cnn);
            command.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("删除成功");
            显示数据();
        }

        //刷新
        private void timer1_Tick(object sender, EventArgs e)
        {
            //不是管理员自动退出
            if (!系统.是管理员吗())
            {
                MessageBox.Show("用户已退出！");
                用户点击关闭 = false;
                this.Close();
                系统.退出登录();
            }

        }
    }
}
