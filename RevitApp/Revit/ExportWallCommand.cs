#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace CrossPlatform.Revit
{
    [Transaction(TransactionMode.Manual)]
    public class ExportWallCommand : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // get selected element
            var elementRef = uidoc.Selection.PickObject(ObjectType.Element);
            var element = doc.GetElement(elementRef.ElementId);

            // convert element to CrossPlatform one
            var cxWall = new CrossPlatform.BIM.Wall();
            var wall = cxWall.FromRevit(element as Wall);

            // write to json on desktop
            var filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "exportedWall.json");
            var exported = Library.IO.Json.ToJsonFile(cxWall, filepath);

            // inform user
            if(exported) TaskDialog.Show("Success", "Saved the JSON file here :" + Environment.NewLine + filepath);
            else TaskDialog.Show("Failed", "Failed to export the JSON file.");

            return exported ? Result.Succeeded : Result.Failed;
        }
    }
}
