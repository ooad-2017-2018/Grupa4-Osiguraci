using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace E_Dernek.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("AzureConnection") { }
        public DbSet<Lokal> Lokal { get; set; }
        public DbSet<Dernek> Dernek { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}