using System;
using System.Collections.Generic;
using System.Data.Entity;
using OxTots.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace OxTots.Data
{
    public class SiteContext : DbContext
    {
        public SiteContext() : base("SiteContextDB")
        {
        }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}