using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UnitTestingDemo.Models;

namespace UnitTestingDemo.Providers
{
    public interface IConfigurationProvider
    {
        string GetConfigSetting(string key);
    }

    public class ConfigurationProvider : IConfigurationProvider, IDisposable
    {
        private InventoryContext _inventoryContext;
        private IAppSettingProvider _appSettingsProvider;

        public ConfigurationProvider()
        {
            
        }
        public ConfigurationProvider(InventoryContext inventoryContext, IAppSettingProvider appSettingsProvider)
        {
            _inventoryContext = inventoryContext;
            _appSettingsProvider = appSettingsProvider;
        }

        public virtual string GetConfigSetting(string key)
        {
            var environmentKey = _appSettingsProvider.GetSetting(Constants.AppSettings.EnvironmentKey);

            if (String.IsNullOrEmpty(environmentKey))
                throw new ArgumentOutOfRangeException(Constants.AppSettings.EnvironmentKey);

            var record = _inventoryContext.ConfigurationValue.SingleOrDefault(c => c.ConfigKey == key && (c.AppEnvironment.ReferenceKey == environmentKey));

            if (record != null)
            {
                return record.ConfigValue;
            }
            else
            {
                throw new ArgumentOutOfRangeException("ConfigKey:" + key);
            }
        }

        public void Dispose()
        {
            _inventoryContext.Dispose();
        }

    }
}
