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
        double 合计 = 0.0;
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

        //回到首页
        private void button6_Click(object sender, EventArgs e)
        {
            用户点击关闭 = false;
            上个页面.Show();
            this.Close();
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
            try
            {
                添加数据();
            }
            catch (Exception)
            {
                MessageBox.Show("添加异常,请检测填写是否正确");
            }
        }

        //删除
        private void button3_Click(object sender, EventArgs e)
        {
            //获取选中项
            listView1.Items.Remove(listView1.FocusedItem);
            显示金额();
        }

        //归零
        private void button5_Click(object sender, EventArgs e)
        {
            价格.Text = String.Format("{0:N2}", 合计);
            收款.Text = String.Format("{0:N2}", 0.00);
            找零.Text = String.Format("{0:N2}", 0.00);
            钱.Text = "";
            编号.Text = "";
        }

        //修改数量
        private void button7_Click(object sender, EventArgs e)
        {
            //获取选中项
            int i = listView1.Items.IndexOf(listView1.FocusedItem);
            int sum = int.Parse(数量.Text);
            listView1.Items[i].SubItems[4].Text = sum.ToString();
            double money = sum * double.Parse(listView1.Items[i].SubItems[3].Text);
            listView1.Items[i].SubItems[5].Text = money.ToString();
            显示金额();
        }

        //清空
        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            显示金额();
            钱.Text = "";
        }

        //确认
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                提交订单();
            }
            catch (Exception)
            {
                MessageBox.Show("提交异常,请检测填写是否正确");
            }
        }

       

        //添加数据
        private void 添加数据()
        {
            //获取编号和数量
            商品 sp = new 商品();
            sp.编号 = int.Parse(编号.Text.ToString());
            int sum = int.Parse(数量.Text.ToString());
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            string sql = "SELECT * FROM commodity WHERE id=" + sp.编号;
            //执行
            MySqlCommand command = new MySqlCommand(sql, cnn);
            MySqlDataReader sdr = command.ExecuteReader();
            if (sdr.Read())
            {
                sp.库存 = sdr.GetInt32("sum");
                sp.名称 = sdr.GetString("name");
                sp.厂家 = sdr.GetString("factory");
                sp.类别 = sdr.GetString("category");
                sp.价格 = sdr.GetDouble("price");
                if(sp.库存>=sum)
                    加入商品(sp, sum);
                else
                {
                    MessageBox.Show("库存不足");
                    return;
                }
            }
            else
            {
                MessageBox.Show("商品不存在");
            }
            //关闭数据链接
            cnn.Close();
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
        
        //提交订单
        private void 提交订单()
        {
            Double money = Double.Parse(钱.Text.ToString());
            收款.Text = String.Format("{0:N2}", money);
            Double change = money - 合计;
            找零.Text = String.Format("{0:N2}", change);
            //打开链接
            MySqlConnection cnn = 系统.链接();
            cnn.Open();
            //修改库存
            string sql = "UPDATE commodity SET sales = sales+{0},sum=sum-{0} WHERE id={1}";
            string val = "";
            MySqlCommand command;
            foreach (ListViewItem item in listView1.Items)
            {
                val += item.SubItems[1].Text + "*" + item.SubItems[4].Text + "|";
                sql = String.Format(sql, item.SubItems[4].Text, item.SubItems[0].Text);
                //执行
                command = new MySqlCommand(sql, cnn);
                command.ExecuteNonQuery();
            }
            //写入数据
            sql = "INSERT INTO sales(val,amount,user_id,user) " +
                "VALUES ('{0}', {1}, {2},'{3}')";
            sql = String.Format(sql, val, 合计, 系统.获取登录用户().ID(), 系统.获取登录用户().姓名());
            command = new MySqlCommand(sql, cnn);
            command.ExecuteNonQuery();
            //关闭链接
            cnn.Close();
            //清空列表
            listView1.Items.Clear();
            合计 = 0.00;
        }

        private void 显示金额()
        {
            合计 = 0.0;
            foreach (ListViewItem ltem in listView1.Items)
            {
                合计 += double.Parse(ltem.SubItems[5].Text);
            }
            价格.Text = String.Format("{0:N2}", 合计);
            收款.Text = String.Format("{0:N2}", 0.00);
            找零.Text = String.Format("{0:N2}", 0.00);
            数量.Text = "1";
        }

        //选中
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            编号.Text = listView1.FocusedItem.SubItems[0].Text;
            数量.Text = listView1.FocusedItem.SubItems[4].Text;
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            编号.Text = listView1.FocusedItem.SubItems[0].Text;
            数量.Text = listView1.FocusedItem.SubItems[4].Text;
        }
    }
}
