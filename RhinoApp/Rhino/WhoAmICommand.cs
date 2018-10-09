using CrossPlatform.Library.Utils;
using Rhino;
using Rhino.Commands;

namespace CrossPlatform.Rhino
{
    public class WhoAmICommand : Command
    {
        public WhoAmICommand()
        {
            Instance = this;
        }

        public static WhoAmICommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "WhoAmI"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            var identity = new WhoAmI(
                                    RhinoApp.Name,
                                    RhinoApp.Version.ToString()
                                    );

            RhinoApp.WriteLine(identity.Format());
            return Result.Success;
        }
    }
}
