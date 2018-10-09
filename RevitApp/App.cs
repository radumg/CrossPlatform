#region Namespaces
using System;
using System.Reflection;
using Autodesk.Revit.UI;
using CrossPlatform.Revit;
#endregion

namespace CrossPlatform
{
    class RevitApp : IExternalApplication
    {
        private const string tabName = "CrossPlatform";

        public Result OnStartup(UIControlledApplication app)
        {
            try
            {
                CreateRibbonItems(app);
            }
            catch (Exception)
            {
                TaskDialog.Show("Error", "Could not add buttons to ribbon.");
                return Result.Failed;
            }

            try
            {
                Revit.EventHandlers.RegisterEvents(app);
            }
            catch (Exception)
            {
                TaskDialog.Show("Error", "Could not register event handlers.");
                return Result.Failed;
            }

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication app)
        {
            Revit.EventHandlers.DeregisterEvents(app);
            return Result.Succeeded;
        }

        public void CreateRibbonItems(UIControlledApplication app)
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
            cxUtilsPanel.AddItem(whoamiButton);
        }

    }
}
