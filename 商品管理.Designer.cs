namespace 商品管理系统
{
    partial class 商品管理
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.用户名 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.数量类别 = new System.Windows.Forms.ComboBox();
            this.数量条件 = new System.Windows.Forms.ComboBox();
            this.数量 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.属性值 = new System.Windows.Forms.TextBox();
            this.属性类别 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.用户名);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1378, 161);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("一纸情书", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "零售店商品管理系统";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(231)))), ((int)(((byte)(245)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button1.Location = new System.Drawing.Point(1099, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "退出登录";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(231)))), ((int)(((byte)(245)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button2.Location = new System.Drawing.Point(985, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 37);
            this.button2.TabIndex = 5;
            this.button2.Text = "回到主页";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(980, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前用户：";
            // 
            // 用户名
            // 
            this.用户名.AutoSize = true;
            this.用户名.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.用户名.Location = new System.Drawing.Point(1103, 7);
            this.用户名.Name = "用户名";
            this.用户名.Size = new System.Drawing.Size(75, 28);
            this.用户名.TabIndex = 2;
            this.用户名.Text = "用户名";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(0, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1378, 583);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 664);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1378, 80);
            this.panel2.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(21, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 40);
            this.button3.TabIndex = 0;
            this.button3.Text = "添加";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(251, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 40);
            this.button4.TabIndex = 1;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(1011, 17);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(185, 40);
            this.button5.TabIndex = 2;
            this.button5.Text = "显示全部";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(473, 17);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(185, 40);
            this.button6.TabIndex = 3;
            this.button6.Text = "开启编辑模式";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(20, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "数量筛选";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.属性值);
            this.panel3.Controls.Add(this.属性类别);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.数量);
            this.panel3.Controls.Add(this.数量条件);
            this.panel3.Controls.Add(this.数量类别);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(-7, 108);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1383, 56);
            this.panel3.TabIndex = 7;
            // 
            // 数量类别
            // 
            this.数量类别.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.数量类别.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.数量类别.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.数量类别.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.数量类别.FormattingEnabled = true;
            this.数量类别.Items.AddRange(new object[] {
            "价格",
            "销量",
            "库存"});
            this.数量类别.Location = new System.Drawing.Point(136, 6);
            this.数量类别.Name = "数量类别";
            this.数量类别.Size = new System.Drawing.Size(121, 32);
            this.数量类别.TabIndex = 7;
            // 
            // 数量条件
            // 
            this.数量条件.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.数量条件.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.数量条件.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.数量条件.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.数量条件.FormattingEnabled = true;
            this.数量条件.Items.AddRange(new object[] {
            "=",
            "≥",
            "≤"});
            this.数量条件.Location = new System.Drawing.Point(263, 6);
            this.数量条件.Name = "数量条件";
            this.数量条件.Size = new System.Drawing.Size(84, 32);
            this.数量条件.TabIndex = 8;
            // 
            // 数量
            // 
            this.数量.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.数量.Location = new System.Drawing.Point(353, 6);
            this.数量.Name = "数量";
            this.数量.Size = new System.Drawing.Size(119, 31);
            this.数量.TabIndex = 9;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(231)))), ((int)(((byte)(245)))));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button7.Location = new System.Drawing.Point(478, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(95, 37);
            this.button7.TabIndex = 10;
            this.button7.Text = "筛选";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // 属性值
            // 
            this.属性值.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.属性值.Location = new System.Drawing.Point(858, 6);
            this.属性值.Name = "属性值";
            this.属性值.Size = new System.Drawing.Size(242, 31);
            this.属性值.TabIndex = 14;
            // 
            // 属性类别
            // 
            this.属性类别.BackColor = System.Drawing.Color.White;
            this.属性类别.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.属性类别.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.属性类别.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.属性类别.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.属性类别.FormattingEnabled = true;
            this.属性类别.Items.AddRange(new object[] {
            "条码",
            "名称",
            "厂家",
            "类别"});
            this.属性类别.Location = new System.Drawing.Point(731, 6);
            this.属性类别.Name = "属性类别";
            this.属性类别.Size = new System.Drawing.Size(121, 32);
            this.属性类别.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(615, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 31);
            this.label4.TabIndex = 11;
            this.label4.Text = "属性查询";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(231)))), ((int)(((byte)(245)))));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button8.Location = new System.Drawing.Point(1114, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(95, 37);
            this.button8.TabIndex = 15;
            this.button8.Text = "查询";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // 商品管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 744);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "商品管理";
            this.Text = "商品管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.商品管理_FormClosing);
            this.Load += new System.EventHandler(this.商品管理_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label 用户名;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox 属性值;
        private System.Windows.Forms.ComboBox 属性类别;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox 数量;
        private System.Windows.Forms.ComboBox 数量条件;
        private System.Windows.Forms.ComboBox 数量类别;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button8;
    }
}