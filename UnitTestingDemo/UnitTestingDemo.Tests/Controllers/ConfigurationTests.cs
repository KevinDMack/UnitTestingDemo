using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestingDemo.Controllers;
using UnitTestingDemo.Controllers.API;
using UnitTestingDemo.Providers;

namespace UnitTestingDemo.Tests.Controllers
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void Get()
        {
            var mockConfiguration = new Mock<ConfigurationProvider>();
            mockConfiguration.Setup(c => c.GetConfigSetting("test")).Returns("test value");
            
            // Arrange
            ConfigurationController controller = new ConfigurationController(mockConfiguration.Object);

            // Act
            string result = controller.Get("test");

            // Assert
            Assert.AreEqual("test value",result);
        }
    }
}
