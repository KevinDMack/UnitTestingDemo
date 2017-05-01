using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDemo
{
    public interface IAppSettingProvider
    {
        string GetSetting(string key);
    }

    public class AppSettingProvider : IAppSettingProvider
    {
        public string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
