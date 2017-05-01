using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

namespace UnitTestingDemo.Models
{
    public class InventoryContext : DbContext
    {
        public virtual DbSet<AppEnvironment> AppEnvironment { get; set; }
        public virtual DbSet<ConfigurationValue> ConfigurationValue { get; set; }

        public InventoryContext() : base("Default")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppEnvironment>();
            modelBuilder.Entity<ConfigurationValue>();
        }
    }
}
