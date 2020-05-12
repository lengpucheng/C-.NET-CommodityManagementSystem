using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace 商品管理系统
{
    public partial class 登陆界面 : Form
    {
        private 用户 user = new 用户();
        public 登陆界面()
        {
            InitializeComponent();
        }

        private void logo_Click(object sender, EventArgs e)
        {
            user.set用户名(textBox1.Text);
            user.set密码(textBox2.Text);
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            string sql = "SELECT  * FROM user WHERE uname='" + user.用户名() + "' AND password='" + user.密码() + "' AND role='" + user.身份() + "'";
            //执行
            MySqlCommand command = new MySqlCommand(sql, cnn);
            MySqlDataReader sdr = command.ExecuteReader();
            if (sdr.Read())
            {
                user.set姓名(sdr.GetString("name"));
                user.setID(sdr.GetInt32("_id"));
                MessageBox.Show("欢迎" + user.姓名());
                管理系统主界面 主界面 = new 管理系统主界面();
                //写入数据
                系统.startApp(this);
                系统.setUser(user);
                //启动主界面
                主界面.Show();
                //隐藏线程
                this.Hide();
               
            }
            else
                MessageBox.Show("用户名或密码错误或身份不正确");
            //关闭数据链接
            cnn.Close();
        }

        private void 登陆界面_Load(object sender, EventArgs e)
        {
            //默认选择第一个
            用户.Select();
        }

        private void 管理员被选中(object sender, EventArgs e)
        {
            user.set身份管理员();
        }

        private void 用户被选中(object sender, EventArgs e)
        {
            user.set身份用户();
        }

        private void zhuche_Click(object sender, EventArgs e)
        {
            new 注册界面().Show();
        }

        //忘记密码
        private void fogrpss_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("请类型管理员");
        }

        //显示密码
        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.PasswordChar = '\0';
        }

        //移开
        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
