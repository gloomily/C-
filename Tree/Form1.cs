using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tree
{
    public partial class Form1 : Form
    {
        public List<string> textList;
       
        
        public Form1()
        {
            textList = new List<string>();
           
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)//添加根节点
        {


            string s = Interaction.InputBox("请输入根节点的名称", "添加根节点", "默认内容", -1, -1);
            Text = s;

          
            //TreeNodeCollection:当前树状菜单节点的集合 所有的数据都要添加到这个集合下
            treeView1.Nodes.Add(s);
        }

        private void button3_Click(object sender, EventArgs e)//添加子节点
        {

            string s = Interaction.InputBox("请输入子节点的名称", "添加子节点", "默认内容", -1, -1);
            Text = s;
            //获得要添加子节点的根节点
            //获得当前选中的节点
            TreeNode tn = treeView1.SelectedNode;
            //每一个节点都可以看做是一个节点集合 也可以无限的向下添加子节点
            if (tn == null)
            {
                return;
            }
            tn.Nodes.Add(s);  //添加子节点

        }

        private void button1_Click(object sender, EventArgs e)//用Listbox显示选中的内容
        {
            

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNodeCollection tnc = treeView1.Nodes;//获取treeview的子节点的集合
            TreeNode treeNode = e.Node;
            treeView1.AfterCheck -= new TreeViewEventHandler(treeView1_AfterSelect);// 代码设置父子关系时候,禁止冒泡事件
            SetSonCheckState(treeNode);
            SetParentCheckedState(treeNode);
            treeView1.AfterCheck += new TreeViewEventHandler(treeView1_AfterSelect);

            textList.Clear();
            listBox1.Items.Clear();

            
            if (e.Node.Nodes.Count == 0)
            {
                textList.Add(treeNode.Text);
            }
            treeNode = tnc[0];
            //if (treeNode.Checked(true))
            //{

            //}
            if (e.Node.Parent != null)
            {
                for (int i=0;i< e.Node.Parent.Nodes.Count;i++)
                {
                    if (e.Node.Parent.Nodes[i].Checked)
                    {
                        listBox1.Items.Add(e.Node.Parent.Nodes[i].Text);
                    }
                }
            }
            
            //for (int i = 0; i < textList.Count; i++)
            //{

            //    listBox1.Items.Add(textList[i]);
            //}
        }
        public void addChildText (TreeNodeCollection Nodes)//遍历节点
        {
            for (int i=0;i<Nodes.Count;i++)
            {
                if (Nodes[i].Nodes.Count == 0)
                {
                    
                    textList.Add(Nodes[i].Text);
                }
                addChildText(Nodes[i].Nodes);
            }
        }
        protected void SetSonCheckState(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.Checked = treeNode.Checked;
                SetSonCheckState(tn);
            }
        }

        /// <summary>        
        /// 根据子节点状态设置父节点的状态         
        /// </summary>         
        /// <param name="childNode"></param>        
        protected void SetParentCheckedState(TreeNode childNode)
        {
            TreeNode parentNode = childNode.Parent;
            if (parentNode != null)
            {
                if (!parentNode.Checked && childNode.Checked)
                {
                    int numChecks = 0;
                    for (int i = 0; i < parentNode.Nodes.Count; i++)
                    {
                        TreeNode tn = parentNode.Nodes[i];
                        if (tn.Checked)
                        {
                            numChecks++;
                        }
                    }
                    //此子节点和它所有兄弟节点都选中了
                    if (numChecks == parentNode.Nodes.Count)
                    {
                        parentNode.Checked = true;
                        SetParentCheckedState(parentNode);
                    }
                }
                else if (parentNode.Checked && !childNode.Checked)
                {

                    parentNode.Checked = false;
                    SetParentCheckedState(parentNode);
                }
            }


        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Remove(treeView1.SelectedNode);
        }
    }
}