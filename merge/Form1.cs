using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using ComboBox = System.Windows.Forms.ComboBox;
using Form = System.Windows.Forms.Form;


namespace merge
{
    public partial class Form1 : Form
    {
        public List<string> textList;

        static SynchronizationContext synt; //线程切换，异步执行要用到

        public Element SelectedElement { get; set; }


        public Form1(Element elem)
        {
            synt = SynchronizationContext.Current; //不能在申明时初始化
            textList = new List<string>();
            InitializeComponent();
            SelectedElement = elem;
        }
        private void Form1_Load(object sender, EventArgs e)
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
            if (e.Node.Parent != null)
            {
                for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                {
                    if (e.Node.Parent.Nodes[i].Checked)
                    {
                        listBox1.Items.Add(e.Node.Parent.Nodes[i].Text);
                    }
                }
            }
        }
        public void addChildText(TreeNodeCollection Nodes)//遍历节点
        {
            for (int i = 0; i < Nodes.Count; i++)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string craft = " ";
            string Safetyinspection = " ";
            string Securitymanagementessentials = " ";

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        craft += "\n\t" + listBox1.Items[i].ToString();
                    }
                    if (SelectedElement == null)
                    {
                        return;
                    }
                    Parameter par_craft = SelectedElement.LookupParameter("工艺做法");
                    TaskDialog.Show("确认：", craft);
                    if (par_craft == null)
                    {
                        return;
                    }
                    par_craft.Set(craft);
                    break;
                case 1:
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        Safetyinspection += "\n\t" + listBox1.Items[i].ToString();
                    }
                    if (SelectedElement == null)
                    {
                        return;
                    }
                    Parameter par_Safety = SelectedElement.LookupParameter("安全巡检");
                    TaskDialog.Show("确认：", Safetyinspection);
                    if (par_Safety == null)
                    {
                        return;
                    }
                    par_Safety.Set(Safetyinspection);
                    break;
                case 2:
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        Securitymanagementessentials += "\n\t" + listBox1.Items[i].ToString();
                    }
                    if (SelectedElement == null)
                    {
                        return;
                    }
                    Parameter par_Security = SelectedElement.LookupParameter("安全管理要点");
                    TaskDialog.Show("确认：", Securitymanagementessentials);
                    if (par_Security == null)
                    {
                        return;
                    }
                    par_Security.Set(Securitymanagementessentials);
                    break;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //获取开始和完成所选择的时间
            String start = dateTimePicker1.Value.ToString();
            String end = dateTimePicker2.Value.ToString();
            //将获取的两个时间分别插入对应的参数值中            

            if (SelectedElement == null)
            {
                return;
            }


            Parameter par_start = SelectedElement.LookupParameter("开始时间");
            string text1 = start.ToString();
            TaskDialog.Show("确认时间为：", text1);
            par_start.Set(text1);
            Parameter par_end = SelectedElement.LookupParameter("完成时间");
            string text2 = end.ToString();
            TaskDialog.Show("确认时间为：", text2);
            par_end.Set(text2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("请输入根节点的名称", "添加根节点", "默认内容", -1, -1);
            Text = s;


            //TreeNodeCollection:当前树状菜单节点的集合 所有的数据都要添加到这个集合下
            treeView1.Nodes.Add(s);
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Remove(treeView1.SelectedNode);
        }
    }
}
