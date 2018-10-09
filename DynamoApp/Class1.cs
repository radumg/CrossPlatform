using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform
{
    public static class DynamoApp
    {
        public static string WhoAmI()
        {
            return DateTime.Now.ToLongDateString();
        }
    }
}
