using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestingDemo.Models;
using UnitTestingDemo.Providers;

namespace UnitTestingDemo.Tests
{
    [TestClass]
    public class ConfigurationProviderTests : EFTestClass
    {
        [TestMethod]
        public void ConfigurationProvider_GetSetting()
        {
            var environment = new AppEnvironment() { ID = 1, Name = "Dev", ReferenceKey = "Dev" };

            var configData = new List<ConfigurationValue>
            {
                new ConfigurationValue() { ConfigKey = "Config.Test", ConfigValue = "Test Result", ID = 1, AppEnvironment = environment }
            };

            var mockSetConfigValues = GetDBSet<ConfigurationValue>(configData);

            var mockContext = new Mock<InventoryContext>();
            mockContext.Setup(c => c.ConfigurationValue).Returns(mockSetConfigValues.Object);

            var context = mockContext.Object;

            var mockAppSettingsProvider = new Mock<IAppSettingProvider>();
            mockAppSettingsProvider.Setup(a => a.GetSetting(Constants.AppSettings.EnvironmentKey)).Returns("Dev");
            var appSettingsProvider = mockAppSettingsProvider.Object;

            var configurationProvider = new ConfigurationProvider(context, appSettingsProvider);

            var setting = configurationProvider.GetConfigSetting("Config.Test");

            Assert.AreEqual("Test Result", setting);
        }

        [TestMethod]
        public void ConfigurationProvider_NoEnvironmentKey()
        {
            var environment = new AppEnvironment() { ID = 1, Name = "Dev", ReferenceKey = "Dev" };

            var configData = new List<ConfigurationValue>
            {
                new ConfigurationValue() { ConfigKey = "Config.Test", ConfigValue = "Test Result", ID = 1, AppEnvironment = environment }
            };

            var mockSetConfigValues = GetDBSet<ConfigurationValue>(configData);

            var mockContext = new Mock<InventoryContext>();
            mockContext.Setup(c => c.ConfigurationValue).Returns(mockSetConfigValues.Object);

            var context = mockContext.Object;

            var mockAppSettingsProvider = new Mock<IAppSettingProvider>();
            mockAppSettingsProvider.Setup(a => a.GetSetting(Constants.AppSettings.EnvironmentKey)).Returns(string.Empty);
            var appSettingsProvider = mockAppSettingsProvider.Object;

            var configurationProvider = new ConfigurationProvider(context, appSettingsProvider);

            var msg = string.Empty;
            try
            {
                var setting = configurationProvider.GetConfigSetting("Config.Test");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                msg = ex.Message;
            }

            Assert.AreNotEqual(string.Empty, msg);
        }

        [TestMethod]
        public void ConfigurationProvider_NoKey()
        {
            var environment = new AppEnvironment() { ID = 1, Name = "Dev", ReferenceKey = "Dev" };

            var configData = new List<ConfigurationValue>
            {
                new ConfigurationValue() { ConfigKey = "Config.Test", ConfigValue = "Test Result", ID = 1, AppEnvironment = environment }
            };

            var mockSetConfigValues = GetDBSet<ConfigurationValue>(configData);

            var mockContext = new Mock<InventoryContext>();
            mockContext.Setup(c => c.ConfigurationValue).Returns(mockSetConfigValues.Object);

            var context = mockContext.Object;

            var mockAppSettingsProvider = new Mock<IAppSettingProvider>();
            mockAppSettingsProvider.Setup(a => a.GetSetting(Constants.AppSettings.EnvironmentKey)).Returns("Dev");
            var appSettingsProvider = mockAppSettingsProvider.Object;

            var configurationProvider = new ConfigurationProvider(context, appSettingsProvider);

            var msg = string.Empty;
            var setting = string.Empty;
            try
            {
                setting = configurationProvider.GetConfigSetting("Config.NoKey");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                msg = ex.Message;
            }

            Assert.AreNotEqual(string.Empty, msg);
            Assert.AreEqual(string.Empty, setting);
        }
    }
}
