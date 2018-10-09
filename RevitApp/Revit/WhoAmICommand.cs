using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CrossPlatform.Library.Utils;

namespace CrossPlatform.Revit
{
    [Transaction(TransactionMode.Manual)]
    public class WhoAmICommand : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            var identity = new WhoAmI(
                commandData.Application.Application.VersionName,
                commandData.Application.Application.VersionNumber
                );

            MessageBox.Show(identity.Format());

            return Result.Succeeded;
        }
    }
}
