using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDemo.Providers
{
    public class Constants
    {
        public class AppSettings
        {
            public const string EnvironmentKey = "EnvironmentKey";
        }

        public class ConfigKeys
        {
            public const string EmailServer = "eSignature.Email.Server";
            public const string EmailPort = "eSignature.Email.Port";
            public const string EmailSubject = "eSignature.Email.Subject";
            public const string EmailBody = "eSignature.Email.Body";
            public const string EmailFromAddress = "eSignature.Email.FromAddress";
        }
    }
}
