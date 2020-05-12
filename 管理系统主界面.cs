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
    public partial class 管理系统主界面 : Form
    {
        private Boolean 是否点关闭 = true;
        public 管理系统主界面()
        {
            InitializeComponent();
        }

        //初始化
        private void 管理系统主界面_Load(object sender, EventArgs e)
        {
            用户名.Text = 系统.获取登录用户().姓名();
            身份.Text = 系统.获取登录用户().身份();
        }

        

        //退出登录
        private void button1_Click(object sender, EventArgs e)
        {
            是否点关闭 = false;
            this.Close();
            系统.退出登录();
        }

        //回到主页
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("这就是主页");
        }

        //商品管理
        private void 商品管理按钮_Click(object sender, EventArgs e)
        {
            new 商品管理(this).Show();
            this.Hide();
        }

        //货物补充
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (系统.是管理员吗())
            {
                new 进货().Show();
            }
            else
                MessageBox.Show("权限不足！");
        }

        //销售面板
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new 收银台(this).Show();
            this.Hide();
        }

        //销售详情
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new 订单查询(this).Show();
            this.Hide();
        }

        //用户管理
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (系统.是管理员吗()) { 
            new 用户管理(this).Show();
            this.Hide();
            }else
                MessageBox.Show("权限不足！");

        }
        //关闭
        private void 管理系统主界面_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (是否点关闭)
                Application.Exit();
            else
                是否点关闭 = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new 关于软件().Show();
        }
    }
}
