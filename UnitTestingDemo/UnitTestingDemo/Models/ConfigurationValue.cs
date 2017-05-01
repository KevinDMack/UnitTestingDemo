using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDemo.Models
{
    [Table("tbl_Configuration")]
    public class ConfigurationValue : BaseModel
    {
        [MaxLength(50)]
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }


        public virtual AppEnvironment AppEnvironment { get; set; }
    }
}
