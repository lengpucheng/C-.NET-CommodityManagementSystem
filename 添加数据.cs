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
    public partial class 添加数据 : Form
    {
        public 添加数据()
        {
            InitializeComponent();
        }

        private void 添加数据_Load(object sender, EventArgs e)
        {

        }


        //保存
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                添加();
            }
            catch (Exception)
            {
                MessageBox.Show("添加异常！请检测数据格式是否正确");
            }

        }



        //添加数据
        private void 添加()
        {
            //获取数据
            商品 sp = new 商品();
            sp.条码 = 条码.Text.Trim().ToString();
            sp.名称 = 名称.Text.Trim().ToString();
            sp.厂家 = 厂家.Text.Trim().ToString();
            sp.类别 = 类别.Text.Trim().ToString();
            sp.价格 = Double.Parse(价格.Text.Trim().ToString());
            sp.库存 = int.Parse(数量.Text.Trim().ToString());
            //sql语句
            String sql = "INSERT INTO commodity(Barcode, name, factory, category, price,sum) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', {4},{5});";
            sql = String.Format(sql, sp.条码, sp.名称, sp.厂家, sp.类别, sp.价格, sp.库存);
            MessageBox.Show(sql);

            //建立链接
            string strConn = "server=sql.hll520.cn;user=lpc_kshcxsj;password=Kshcxsj_lpc;Port=3306;database=kcsj_kshcxsj";
            MySqlConnection cnn = new MySqlConnection(strConn);
            cnn.Open();
            //执行
            MySqlCommand command = new MySqlCommand(sql, cnn);
            command.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("添加成功");
            this.Close();
        }
    }
}
