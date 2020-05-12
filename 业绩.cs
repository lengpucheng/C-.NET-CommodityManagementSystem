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
    public partial class 业绩 : Form
    {
        private Form 上个页面;
        private Boolean 用户点击关闭 = true;
        public 业绩(Form 父级)
        {
            InitializeComponent();
            上个页面 = 父级;
        }

        private void 业绩_Load(object sender, EventArgs e)
        {
            用户名.Text = 系统.获取登录用户().姓名();
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
    }
}
