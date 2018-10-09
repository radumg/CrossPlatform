using System;

namespace CrossPlatform.Library.Utils
{
    public class WhoAmI
    {
        public string UserName { get; set; }
        public string UserDomainName { get; set; }
        public string MachineName { get; set; }
        public string OSVersion { get; set; }
        public string HostApp { get; set; }
        public string HostAppVersion { get; set; }

        public WhoAmI(string hostApp, string hostAppVersion)
        {
            UserName = Environment.UserName;
            UserDomainName = Environment.UserDomainName;
            MachineName = Environment.MachineName;
            OSVersion = Environment.OSVersion.ToString();
            HostApp = hostApp ?? string.Empty;
            HostAppVersion = hostAppVersion ?? string.Empty;
        }

        public string Format()
        {
            return IO.Json.ToJson(this);
        }
    }
}
