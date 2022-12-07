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
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using ComboBox = System.Windows.Forms.ComboBox;
using Form = System.Windows.Forms.Form;

namespace ClassLibrary1
{
    public partial class Form1 : Form
    {
        static SynchronizationContext synt; //线程切换，异步执行要用到
        
        private string[] names; //定义三个私有数组，分别为工艺，安全巡检，安全管理要点
        private string[] nums;
        private string[] mark;

        
        public Element SelectedElement { get; set; }

        public Form1()
        {
            synt = SynchronizationContext.Current; //不能在申明时初始化

            InitializeComponent();          


        }
        public Form1(Element elem)
        {
            synt = SynchronizationContext.Current; //不能在申明时初始化

            InitializeComponent();
            SelectedElement = elem;
            

        }
        /// <summary>
        /// 分类内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            names = new string[] { "技术交底", "泵送砼倾落高度", "养护", "品种、规格", "数量、位置", "连接方式、接头位置、接头数量、接头面积百分率", "接缝/浇水湿润", "脱模隔离剂", "大跨度构件起拱1/1000~3/1000", "拆模强度要求/需技术负责人批准" };  //工艺做法
            nums = new string[] { "每周" };  //安全巡检
            mark = new string[] { "机械设备检查", "用电检查", "高处作业防护", "避免集中荷载", "垫木应为木垫板", "上下立柱须对正", "堆载不得超过设计值", "恶劣天气时应停止吊运", "拆模须强度达到要求/技术负责人批准" }; //安全管理要点
            this.checkedListBox1.Items.AddRange(names); //将数组names数据添加到checkedListBox1“选择栏”中
            this.comboBox1.SelectedIndex = 0;   //定义打开软件时初显第1个下拉框的信息，即：names工艺
        }
        

        /// <summary>
        /// 窗口选择赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) //参数按钮
        {
            int count = this.checkedListBox1.CheckedItems.Count;
            if (this.checkedListBox1.Items.Count == 0)     //当只选择一个下拉框里的信息时，正常返回。
            {
                return;    //一个方法中也可以出现多个return，但只有一个会执行。当return语句后面什么都不加时，返回的类型为void。
            }
            if (this.checkedListBox1.Items.Count == -1)     //当一个下拉框里的内容都没选，提示用户选择。
            {
                MessageBox.Show("请在\"选择栏\"中选择要添加的项。");
                return;
            }
            for (int i = 0; i < count; i++)  //在listBox1显示栏显示checkedListBox1选择栏中被选中的内容。
            {
                this.listBox1.Items.Add(this.checkedListBox1.CheckedItems[i]);
            }
            MessageBox.Show("选定的项已被移到\"显示栏\"中");
            //定位赋值功能
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
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cd = (ComboBox)sender; //定义选择comboBox1“信息栏”中的选项，【0，1，2】等于comboBox1-SelectedIndex中[工艺，安全巡检，安全管理要点]，并将选择的值赋予cd
            switch (cd.SelectedIndex)   //选择：工艺，安全巡检，安全管理要点，相应栏，在checkedListBox1“选择栏”出现相应的信息。
            {
                case 0:
                    this.checkedListBox1.Items.Clear();
                    this.checkedListBox1.Items.AddRange(names);
                    break;
                case 1:
                    this.checkedListBox1.Items.Clear();
                    this.checkedListBox1.Items.AddRange(nums);
                    break;
                case 2:
                    this.checkedListBox1.Items.Clear();
                    this.checkedListBox1.Items.AddRange(mark);
                    break;
            }
            this.listBox1.Items.Clear(); //清空listBox1“显示栏”中显示的内容。
        }
        #region 获取时间并写入
        /// <summary>
        /// 获取时间并写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //获取开始和完成所选择的时间
            String start = dateTimePicker1.Value.ToString();
            String end = dateTimePicker2.Value.ToString();
            //将获取的两个时间分别插入对应的参数值中            
            
            if (SelectedElement==null)
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
        #endregion
    }
}
