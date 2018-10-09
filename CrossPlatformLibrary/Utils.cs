using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.Library
{
    public static class Utils
    {
        public static string WhoAmI()
        {
            return
                "This is the information I have on you : " + Environment.NewLine +
                "user    : " + Environment.UserName + Environment.NewLine +
                "domain  : " + Environment.UserDomainName + Environment.NewLine +
                "machine : " + Environment.MachineName + Environment.NewLine +
                "OS      : " + Environment.OSVersion;
        }
    }
}
