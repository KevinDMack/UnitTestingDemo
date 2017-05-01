using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UnitTestingDemo.Models;

namespace UnitTestingDemo.Providers
{
    public interface IEmailProvider
    {
        bool SendEmail(EmailModel model);
    }
    public class EmailProvider : IEmailProvider
    {
        private IConfigurationProvider configurationProvider;
        private ISmtpAdapter smtpAdapter;

        public EmailProvider(IConfigurationProvider configurationProvider, ISmtpAdapter smtpAdapter)
        {
            this.configurationProvider = configurationProvider;
            this.smtpAdapter = smtpAdapter;
        }

        public virtual bool SendEmail(EmailModel model)
        {

            try
            {
                int port = 25;

                int.TryParse(configurationProvider.GetConfigSetting(Constants.ConfigKeys.EmailPort), out port);
                var host = configurationProvider.GetConfigSetting(Constants.ConfigKeys.EmailServer);

                var fromAddress = configurationProvider.GetConfigSetting(Constants.ConfigKeys.EmailFromAddress);

                var mail = new MailMessage(fromAddress, model.EmailAddress, model.EmailSubject, model.EmailBody);
                mail.IsBodyHtml = true;

                smtpAdapter.SendEmail(host, port, mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
