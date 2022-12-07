using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using Autodesk.Revit;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.Attributes;

namespace ClassLibrary1
{
    [Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    internal class Display_parameters : IExternalCommand//窗口中显示出需要显示的构件参数
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Autodesk.Revit.ApplicationServices.Application app = commandData.Application.Application;
            Document doc = commandData.Application.ActiveUIDocument.Document;
            UIApplication uiapp = commandData.Application;
            UIDocument uiDoc = uiapp.ActiveUIDocument;
            Selection selection = uiDoc.Selection;
            ICollection<ElementId> selectedIds = uiDoc.Selection.GetElementIds();
            if (0 == selectedIds.Count)
            {
                // 如果没有选择元素
                TaskDialog.Show("显示框", "请先选择一个构件");
            }
            else
            {
                String info = "";
                foreach (ElementId id in selectedIds)
                {
                    Element element = doc.GetElement(id);
                    info += "\n\t开始时间:" + element.LookupParameter("开始时间").AsString();
                    info += "\n\t完成时间:" + element.LookupParameter("完成时间").AsString();
 //                   info += "\n\t安全巡检:" + element.LookupParameter("安全巡检").AsString();
                    info += "\n\t工艺做法:" + element.LookupParameter("工艺做法").AsString();
                    info += "\n\t安全管理要点:" + element.LookupParameter("安全管理要点").AsString();
                }
                TaskDialog.Show("开发提示框", info);
            }
            return Result.Succeeded;
        }
       
    }
}
