using System;
using System.Reflection;
using Autodesk.Revit.UI;

namespace CrossPlatform
{
    public class RevitApp : IExternalApplication
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
            var cxUtilsPanel = app.CreateRibbonPanel(tabName, "Utils");

            // create ribbon buttons
            PushButtonData whoamiButton = new PushButtonData(
                      " Who Am I ? ", // buttonName
                      "Tell me who i am.", //buttonText
                      Assembly.GetExecutingAssembly().Location,
                      "CrossPlatform.Revit.WhoAmICommand" //className
                      );

            PushButtonData exportWallButton = new PushButtonData(
                      " Pick a wall and export it to JSON ", // buttonName
                      " Export wall ", //buttonText
                      Assembly.GetExecutingAssembly().Location,
                      "CrossPlatform.Revit.ExportWallCommand" //className
                      );

            // add buttons to panels
            cxUtilsPanel.AddItem(whoamiButton);
            cxBIMPanel.AddItem(exportWallButton);
        }

    }
}
