using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnitTestingDemo.Providers;

namespace UnitTestingDemo.Controllers.API
{
    public class ConfigurationController : ApiController
    {
        private IConfigurationProvider _configurationProvider;
        public ConfigurationController(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public string Get(string id)
        {
            return _configurationProvider.GetConfigSetting(id);
        }
    }
}
