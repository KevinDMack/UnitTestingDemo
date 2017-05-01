using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TinyIoC;
using UnitTestingDemo.DI;

namespace UnitTestingDemo.App_Start
{
    public class DIConfig
    {
        public static void Register()
        {
            var container = TinyIoCContainer.Current;

            DependencyResolver.SetResolver(new TinyIocDependencyResolver(container));
        }
    }
}
