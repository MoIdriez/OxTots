using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OxTots.Models;

namespace OxTots.Data
{
    public class SiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteContext>
    {
        protected override void Seed(SiteContext context)
        {
            var contacts = new List<Contact>
            {
                new Contact {Name = "Bobby", Email = "bob@bob.bob", Message = "Important stuff"}
            };

            contacts.ForEach(c => context.Contacts.Add(c));
            context.SaveChanges();
        }
    }
}