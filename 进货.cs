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
    public partial class 进货 : Form
    {
        public 进货()
        {
            InitializeComponent();
        }

        private void 进货_Load(object sender, EventArgs e)
        {
            //名称，列宽度，对齐方式
            this.listView1.Columns.Add("编号", 80, HorizontalAlignment.Left);
            this.listView1.Columns.Add("条码", 80, HorizontalAlignment.Left);
            this.listView1.Columns.Add("名称", 80, HorizontalAlignment.Left);
            this.listView1.Columns.Add("厂家", 80, HorizontalAlignment.Left);
            this.listView1.Columns.Add("添加数量", 80, HorizontalAlignment.Left);
            this.listView1.Columns.Add("现有库存", 80, HorizontalAlignment.Left);
        }

        //确认
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                添加库存();
            }
            catch (Exception)
            {
                MessageBox.Show("添加异常！请确认格式！");
            }

        }


        //添加库存
        private void 添加库存()
        {
            商品 sp = new 商品();
            sp.编号 = int.Parse(编号.Text.ToString());
            sp.条码 = 编号.Text.ToString();
            int sum = int.Parse(数量.Text.ToString());
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            string sql = "SELECT * FROM commodity WHERE id=" + sp.编号+ " or Barcode='"+sp.条码+"'";
            //执行
            MySqlCommand command = new MySqlCommand(sql, cnn);
            MySqlDataReader sdr = command.ExecuteReader();
            if (sdr.Read())
            {
                sp.编号 = sdr.GetInt32("id");
                sp.条码 = sdr.GetString("Barcode");
                sp.库存 = sdr.GetInt32("sum");
                sp.名称 = sdr.GetString("name");
                sp.厂家 = sdr.GetString("factory");
                ListViewItem ltem = new ListViewItem();
                //首列名
                ltem.Text = sp.编号.ToString();
                ltem.SubItems.Add(sp.条码);
                ltem.SubItems.Add(sp.名称);
                ltem.SubItems.Add(sp.厂家);
                ltem.SubItems.Add(sum.ToString());//数量
                sum = sum + sp.库存;
                ltem.SubItems.Add(sum.ToString());//库存
                this.listView1.Items.Add(ltem);
                cnn.Close();
            }
            else
            {
                MessageBox.Show("商品不存在");
                return;
            }
            sql = "UPDATE commodity SET sum="+sum+" WHERE id ="+sp.编号;
            //打开链接
            MySqlConnection cnn2 = 系统.链接();
            cnn2.Open();
            //执行
            MySqlCommand command2 = new MySqlCommand(sql, cnn2);
            command2.ExecuteNonQuery();
            //关闭数据链接
            cnn2.Close();
        }

        //判断是否还在
        private void timer1_Tick(object sender, EventArgs e)
        {
            //不是管理员自动退出
            if (!系统.是管理员吗())
            {
                MessageBox.Show("用户已退出！");
                this.Close();
            }
        }
    }
}
