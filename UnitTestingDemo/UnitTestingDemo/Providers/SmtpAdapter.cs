using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDemo.Providers
{
    public interface ISmtpAdapter
    {
        string SendEmail(string host, int port, MailMessage message);
    }

    public class SmtpAdapter : ISmtpAdapter
    {
        protected SmtpClient client;
        public SmtpAdapter()
        {
            client = new SmtpClient();
        }

        public virtual string SendEmail(string host, int port, MailMessage message)
        {
            try
            {
                client.Host = host;
                client.Port = port;

                client.Send(message);

                return "Email Sent";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
