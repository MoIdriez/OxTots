using OxTots.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace OxTots.Data
{
    /// <summary>
    /// Defines the database
    /// </summary>
    public class SiteContext : DbContext
    {
        public SiteContext() : base("SiteContextDB")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDetail> CategoryDetails { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureDetail> FeatureDetails { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceDetail> ResourceDetails { get; set; }
        public DbSet<ResourceFeature> ResourceFeatures { get; set; }

        public DbSet<Submission> Submissions { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}