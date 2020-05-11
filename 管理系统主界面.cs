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

        private void 管理系统主界面_Load(object sender, EventArgs e)
        {
            用户名.Text = 系统.获取登录用户().姓名();
        }


        private void 商品管理按钮_Click(object sender, EventArgs e)
        {
            new 商品管理(this).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            是否点关闭 = false;
            this.Close();
            系统.退出登录();
        }

        private void 管理系统主界面_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (是否点关闭)
                Application.Exit();
            else
                是否点关闭 = true;
        }
    }
}
