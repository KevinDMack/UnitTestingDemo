using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyIoC;
using UnitTestingDemo.Providers;

namespace UnitTestingDemo.DI
{
    public class Bootstrap
    {
        private static Bootstrap _instance;

        public static Bootstrap Instance
        {
            get { return _instance ?? (_instance = new Bootstrap()); }
        }

        public void Register()
        {

            TinyIoCContainer.Current.Register<IConfigurationProvider, ConfigurationProvider>().AsPerRequestSingleton();
            TinyIoCContainer.Current.Register<IEmailProvider, EmailProvider>().AsPerRequestSingleton();
            TinyIoCContainer.Current.Register<ISmtpAdapter, SmtpAdapter>().AsPerRequestSingleton();
        }
    }
}
