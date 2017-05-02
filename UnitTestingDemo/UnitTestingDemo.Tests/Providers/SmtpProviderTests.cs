using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestingDemo.Models;
using UnitTestingDemo.Providers;

namespace UnitTestingDemo.Tests.Providers
{
    [TestClass]
    public class SmtpProviderTests : EFTestClass
    {
        [TestMethod]
        public void SendEmail()
        {
            var mockConfiguration = new Mock<ConfigurationProvider>();
            mockConfiguration.Setup(c => c.GetConfigSetting(Constants.ConfigKeys.EmailPort)).Returns("25");
            mockConfiguration.Setup(c => c.GetConfigSetting(Constants.ConfigKeys.EmailServer)).Returns("localhost");
            mockConfiguration.Setup(c => c.GetConfigSetting(Constants.ConfigKeys.EmailFromAddress)).Returns("test@test.com");

            var emailModel = new EmailModel()
            {
                EmailAddress = "kevin@test.com",
                EmailBody = "Hello World!",
                EmailSubject = "Hi!",
                isValid = true
            };

            var mockSmtpAdapter = new Mock<SmtpAdapter>();
            mockSmtpAdapter.Setup(m => m.SendEmail("localhost", 25, new MailMessage()
            {
                Body = emailModel.EmailBody,
                Subject = emailModel.EmailSubject,
                To = {new MailAddress(emailModel.EmailAddress)},
                From = new MailAddress("test@test.com")
            })).Returns("Email Sent");

            var provider = new EmailProvider(mockConfiguration.Object, mockSmtpAdapter.Object);

            var result = provider.SendEmail(emailModel);

            Assert.IsTrue(result);
        }
    }
}
