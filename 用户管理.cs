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
    public partial class 用户管理 : Form
    {
        private Form 上个页面;
        public 用户管理(Form 父级)
        {
            InitializeComponent();
            上个页面 = 父级;
        }

        private void 用户管理_Load(object sender, EventArgs e)
        {

        }
    }
}
