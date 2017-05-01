using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDemo.Models
{
    public class AppEnvironment : BaseModel
    {
        public string Name { get; set; }

        public string ReferenceKey { get; set; }

        public virtual List<ConfigurationValue> ConfigurationValues { get; set; }
    }
}
