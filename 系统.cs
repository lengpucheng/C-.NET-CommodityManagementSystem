using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 商品管理系统
{
    class 系统
    {
        private static Form 登录界面;
        private static 用户 登录用户;
        public static void startApp(Form 线程) { 登录界面 = 线程; }
        public static void setUser(用户 user) { 登录用户 = user; }
        public static Form 获取登录界面() { return 登录界面; }
        public static 用户 获取登录用户() { return 登录用户; }
        public static void 退出登录() { 登录用户 = new 用户(); 
            登录用户.set用户名("ccpp不在线了:4408");
            登录界面.Show();
        }
        public static void 关闭软件() { 登录界面.Close(); }
        //判断是否
        public static Boolean 是管理员吗()
        {
            return 登录用户.身份().Equals("管理员");
        }
        public static Boolean 还在线吗()
        {
            return !登录用户.用户名().Equals("ccpp不在线了:4408");
        }

        //获取链接
        public static MySqlConnection 链接()
        {
            string strConn = "server=sql.hll520.cn;user=lpc_kshcxsj;password=Kshcxsj_lpc;Port=3306;database=kcsj_kshcxsj";
            MySqlConnection cnn = new MySqlConnection(strConn);
            return cnn;
        }

    }

}
