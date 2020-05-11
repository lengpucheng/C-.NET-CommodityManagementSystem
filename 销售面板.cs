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
    public partial class 销售面板 : Form
    {
        private Form 上个页面;
        private Boolean 用户点击关闭=true;
        public 销售面板(Form 父级)
        {
            InitializeComponent();
            上个页面 = 父级;
        }
        //初始化
        private void 销售面板_Load(object sender, EventArgs e)
        {
            数量.Text = "1";
            用户名.Text = 系统.获取登录用户().姓名();
            ColumnHeader ch = new ColumnHeader();
            //名称，列宽度，对齐方式
            this.listView1.Columns.Add("编号", 100, HorizontalAlignment.Left); 
            this.listView1.Columns.Add("名称", 100, HorizontalAlignment.Left); 
            this.listView1.Columns.Add("类别", 100, HorizontalAlignment.Left); 
            this.listView1.Columns.Add("单价", 100, HorizontalAlignment.Left); 
            this.listView1.Columns.Add("数量", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("小计", 100, HorizontalAlignment.Left);
        }

        //关闭页面
        private void button6_Click(object sender, EventArgs e)
        {
            上个页面.Show();
            this.Close();
            用户点击关闭 = false;
        }
        //关闭监听
        private void 销售面板_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(用户点击关闭)
                系统.关闭软件();
            else
                用户点击关闭 = true;
        }


        //添加
        private void button1_Click(object sender, EventArgs e)
        {
            //获取编号和数量
            商品 sp = new 商品();
            sp.编号= int.Parse(编号.Text.ToString());
            int sum = int.Parse(数量.Text.ToString());
            //打开链接
            string strConn = "server=sql.hll520.cn;user=lpc_kshcxsj;password=Kshcxsj_lpc;Port=3306;database=kcsj_kshcxsj";
            MySqlConnection cnn = new MySqlConnection(strConn);
            cnn.Open();
            string sql = "SELECT * FROM commodity WHERE id="+sp.编号;
            //执行
            MySqlCommand command = new MySqlCommand(sql, cnn);
            MySqlDataReader sdr = command.ExecuteReader();
            if (sdr.Read())
            {
                sp.名称 = sdr.GetString("name");
                sp.厂家 = sdr.GetString("factory");
                sp.类别 = sdr.GetString("category");
                sp.价格 = sdr.GetDouble("price");
                加入商品(sp, sum);
            }
            else
            {
                MessageBox.Show("商品不存在");
            }
            //关闭数据链接
            cnn.Close();
        }

        //删除
        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Remove(listView1.FocusedItem);
            显示金额();
        }

        //清空
        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            显示金额();
        }

        private void 显示金额()
        {
            double 合计 = 0.0;
            foreach (ListViewItem ltem in listView1.Items){
                合计 += double.Parse(ltem.SubItems[5].Text);
            }
            价格.Text = 合计.ToString();
        }



        //加入商品
        private void 加入商品(商品 sp,int sum)
        {
            ListViewItem ltem = new ListViewItem();
            //首列名
            ltem.Text = sp.编号.ToString();
            ltem.SubItems.Add(sp.名称);
            ltem.SubItems.Add(sp.类别);
            ltem.SubItems.Add(sp.价格.ToString());
            ltem.SubItems.Add(sum.ToString());//数量
            double money = sum * sp.价格;
            ltem.SubItems.Add(money.ToString());//合计
            this.listView1.Items.Add(ltem);
            显示金额();
        }
    }
}
