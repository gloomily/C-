using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace ClassLibrary1
{

    [Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
         
            try
            {
                UIDocument uidoc = commandData.Application.ActiveUIDocument;
                Document doc = commandData.Application.ActiveUIDocument.Document;
                Reference reference = uidoc.Selection.PickObject(ObjectType.Element);
                Element elemen = doc.GetElement(reference.ElementId);//已获取到elemen
                
                Form1 form1 = new Form1(elemen);
                form1.Show();


                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }

        }
       
    }
}
