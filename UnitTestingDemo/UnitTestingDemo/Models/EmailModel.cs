using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDemo.Models
{
    public class EmailModel : BaseViewModel
    {
        /// <summary>
        /// The email address of the signer for this document that is being emailed.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The body of the email from contents of the database.
        /// </summary>
        public string EmailBody { get; set; }

        /// <summary>
        /// The subject for the email message
        /// </summary>
        public string EmailSubject { get; set; }
    }
}
