using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 商品管理系统
{
    public class 用户
    {
        private int id = 0;
        private String uname = "";
        private String password = "";
        private String role = "用户";
        private String name = "未命名";


        public void setID(int id)
        {
            this.id = id;
        }
        public void set用户名(String uname)
        {
            this.uname = uname;
        }
        public void set密码(String passwrod)
        {
            this.password = passwrod;
        }
        public void set姓名(String name)
        {
            this.name = name;
        }
        public void set身份用户() { this.role = "用户"; }
        public void set身份管理员() { this.role = "管理员"; }

       
        //获取
        public String 用户名() { return uname; }
        public String 密码() { return password; }
        public String 身份() { return role; }
        public String 姓名() { return name; }
        public int ID() { return id; }
    }
}
