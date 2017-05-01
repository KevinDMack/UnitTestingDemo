using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TinyIoC;
using UnitTestingDemo.Models;
using UnitTestingDemo.Providers;

namespace UnitTestingDemo.Controllers.API
{
    public class EmailController : ApiController
    {

        private readonly IEmailProvider _emailProvider;

        public EmailController()
        {
            _emailProvider = TinyIoCContainer.Current.Resolve<IEmailProvider>();
        }

        [HttpPost]
        public bool Post(EmailModel model)
        {
            return _emailProvider.SendEmail(model);
        }
    }
}
