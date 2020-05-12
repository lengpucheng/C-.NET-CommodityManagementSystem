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
    public partial class 注册界面 : Form
    {
        private Boolean 是否修改 = false;
        private 用户 user=new 用户();
        public 注册界面()
        {
            InitializeComponent();
        }

        public 注册界面(用户 user)
        {
            InitializeComponent();
            是否修改 = true;
            this.user = user;
        }

        //加载
        private void 注册界面_Load(object sender, EventArgs e)
        {
            if (是否修改)
            {
                标题.Text = "编辑资料";
                确认.Text = "保存";
                if (user.身份().Equals("用户"))
                    yh.Checked = true;
                else
                    gly.Checked = true;
                name.Text = user.姓名();
                yhm.Text = user.用户名();
                mm.Text = user.密码();
                qrmm.Text= user.密码();
            }
            else { 
                yh.Checked = true;
                gly.Enabled = false;
            }
        }

        //确认
        private void 确认_Click(object sender, EventArgs e)
        {
            try
            {
                if (是否修改) {
                    修改用户();
                }
                else
                    用户注册();
            }
            catch (Exception)
            {
                MessageBox.Show("用户名重复！");
            }
        }
        //修改用户
        private void 修改用户()
        {
            if (!正则检验())
                return;
            user.set姓名(name.Text.Trim());
            user.set用户名(yhm.Text.Trim());
            if (yh.Checked)
                user.set身份用户();
            else
                user.set身份管理员();
            String sql = "UPDATE user SET name = '{0}', uname = '{1}', password = '{2}', role = '{3}' WHERE _id = {4};";
            sql = String.Format(sql, user.姓名(), user.用户名(), user.密码(), user.身份(),user.ID());
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            //执行
            MySqlCommand command = new MySqlCommand(sql, cnn);
            command.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("保存成功");
            this.Close();
        }

        //用户注册
        private void 用户注册()
        {
            if (!正则检验())
                return;
            user = new 用户();
            user.set姓名(name.Text.Trim());
            user.set用户名(yhm.Text.Trim());
            if (yh.Checked)
                user.set身份用户();
            else
                user.set身份管理员();
            String sql = "INSERT INTO user(name, uname, password, role) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}');";
            sql = String.Format(sql, user.姓名(), user.用户名(), user.密码(), user.身份());
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            //执行
            MySqlCommand command = new MySqlCommand(sql, cnn);
            command.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("注册成功");
            this.Close();
        }

        //正则检验
        private Boolean 正则检验()
        {
            if (name.Text.Trim().Length < 3)
            {
                MessageBox.Show("用户名不能低于3位");
                return false;
            }
            if(mm.Text.Trim().Length<5)
            {
                MessageBox.Show("密码不能低于5位");
                return false;
            }
            user.set密码(mm.Text.Trim());
            if(!user.密码().Equals(qrmm.Text.Trim()))
             {
                MessageBox.Show("两次密码不一致");
                return false;
            }
            if (!"emsf".Equals(yzm.Text.Trim()))
            {
                MessageBox.Show("验证码错误！");
                return false;
            }
            return true;
        }

        //清空
        private void button3_Click(object sender, EventArgs e)
        {
            name.Text = "";
            yhm.Text = "";
            mm.Text = "";
            qrmm.Text = "";
            yzm.Text = "";
        }
    }
}
