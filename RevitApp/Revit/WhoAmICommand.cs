using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

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
            MessageBox.Show(CrossPlatform.Library.Utils.WhoAmI());

            return Result.Succeeded;
        }
    }
}
