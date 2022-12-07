namespace Tree
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点13");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点14");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点15");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点4", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点3", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点8");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("节点11");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("节点12");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("节点2", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点13";
            treeNode1.Text = "节点13";
            treeNode2.Name = "节点14";
            treeNode2.Text = "节点14";
            treeNode3.Name = "节点15";
            treeNode3.Text = "节点15";
            treeNode4.Name = "节点4";
            treeNode4.Text = "节点4";
            treeNode5.Name = "节点5";
            treeNode5.Text = "节点5";
            treeNode6.Name = "节点9";
            treeNode6.Text = "节点9";
            treeNode7.Name = "节点3";
            treeNode7.Text = "节点3";
            treeNode8.Name = "节点0";
            treeNode8.Text = "节点0";
            treeNode9.Name = "节点6";
            treeNode9.Text = "节点6";
            treeNode10.Name = "节点7";
            treeNode10.Text = "节点7";
            treeNode11.Name = "节点8";
            treeNode11.Text = "节点8";
            treeNode12.Name = "节点1";
            treeNode12.Text = "节点1";
            treeNode13.Name = "节点10";
            treeNode13.Text = "节点10";
            treeNode14.Name = "节点11";
            treeNode14.Text = "节点11";
            treeNode15.Name = "节点12";
            treeNode15.Text = "节点12";
            treeNode16.Name = "节点2";
            treeNode16.Text = "节点2";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode12,
            treeNode16});
            this.treeView1.Size = new System.Drawing.Size(216, 450);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(394, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(406, 450);
            this.listBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(271, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 60);
            this.button1.TabIndex = 2;
            this.button1.Text = "转移";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(271, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 65);
            this.button2.TabIndex = 3;
            this.button2.Text = "添加根";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(271, 215);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 64);
            this.button3.TabIndex = 4;
            this.button3.Text = "添加子";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(271, 316);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 61);
            this.button4.TabIndex = 5;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
    }
}

