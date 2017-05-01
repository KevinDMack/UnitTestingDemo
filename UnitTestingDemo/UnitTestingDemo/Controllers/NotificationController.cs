using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestingDemo.Models;
using UnitTestingDemo.Providers;

namespace UnitTestingDemo.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IEmailProvider _emailProvider;
        // GET: Notification
        public ActionResult Index()
        {
            var model = new EmailModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                _emailProvider.SendEmail(model);
                model.isValid = true;
                return View(model);
            }
            else
            {
                model.isValid = false;
            }

            return View(model);
        }
    }
}