using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTestingDemo.Providers
{
    public class TestConfigurationProvider : ConfigurationProvider, IConfigurationProvider
    {
        public override string GetConfigSetting(string key)
        {
            return key;
        }
    }
}