using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform
{
    public static class DynamoApp
    {
        public static string WhoAmI => WhoIAmNodeOutput();

        private static string WhoIAmNodeOutput()
        {
            var who = new CrossPlatform.Library.Utils.WhoAmI(
                            Assembly.GetEntryAssembly().FullName,
                            Dynamo.Utilities.AssemblyHelper.GetDynamoVersion().ToString()
                        );
           return who.Format();
        }
    }
}
