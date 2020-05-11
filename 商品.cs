using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 商品管理系统
{
    public class 商品
    {
        public int 编号 = 0;
        public String 条码 = "0";
        public String 名称 = "未命名";
        public String 厂家 = "未知";
        public String 类别 = "未知";
        public double 价格 = 0.0;
        public int 销量 = 0;
        public int 库存 = 0;

        public String toString()
        {
            return "编号："+编号+"\n条码："+条码 + "\n名称："+名称+"\n厂家："+厂家
                +"\n类别："+类别+"\n价格："+价格+"\n销量："+销量+"\n库存："+库存;
        }
    }
}
