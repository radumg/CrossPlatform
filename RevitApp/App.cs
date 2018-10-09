#region Namespaces
using System;
using System.Collections.Generic;
using System.Reflection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace CrossPlatform
{
    class RevitApp : IExternalApplication
    {
        private const string tabName = "CrossPlatform";

        public Result OnStartup(UIControlledApplication app)
        {
            // create ribbon tab
            app.CreateRibbonTab(tabName);

            // create ribbon panels
            var cxBIMPanel = app.CreateRibbonPanel(tabName, "BIM");
            var cxGeomPanel = app.CreateRibbonPanel(tabName, "Geometry");
            var cxUtilsPanel = app.CreateRibbonPanel(tabName, "Utils");

            // create ribbon buttons
            PushButtonData whoamiButton = new PushButtonData(
                      "Who Am I ?", // buttonName
                      "Tell me who i am.", //buttonText
                      Assembly.GetExecutingAssembly().Location,
                      "CrossPlatform.Revit.WhoAmICommand" //className
                      );

            // add buttons to panels
            try
            {
                cxUtilsPanel.AddItem(whoamiButton);
            }
            catch (Exception)
            {
                TaskDialog.Show("Error", "Could not add buttons to ribbon.");
                return Result.Failed;
            }

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
