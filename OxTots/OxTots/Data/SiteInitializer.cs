using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OxTots.Models;

namespace OxTots.Data
{
    public class SiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteContext>
    {
        protected override void Seed(SiteContext context)
        {
            // Get all the languages 
            var languages = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures).Select(
                ci => new Language
                {
                    Name = ci.DisplayName,
                    CountryCode = ci.Name
                }).ToList();
            context.Languages.AddRange(languages);

            var page = new Page
            {
                LayoutCookieTitle = "LayoutCookieTitle",
                LayoutCookieDescription = "LayoutCookieDescription",

                LayoutMenuHome = "LayoutMenuHome",
                LayoutMenuListing = "LayoutMenuListing",
                LayoutMenuSearch = "LayoutMenuSearch",
                LayoutMenuSubmissions = "LayoutMenuSubmissions",
                LayoutMenuContact = "LayoutMenuContact",
                LayoutMenuMap = "LayoutMenuMap",

                LayoutFooterLink1 = "LayoutFooterLink1",
                LayoutFooterLink1Description = "LayoutFooterLink1Description",
                LayoutFooterLink2 = "LayoutFooterLink2",
                LayoutFooterLink2Description = "LayoutFooterLink2Description",

                HomeSearch = "HomeSearch",
                HomeTitle = "HomeTitle",
                HomeDescription = "HomeDescription",

                SearchTitle = "SearchTitle",
                SearchDescription = "SearchDescription",
                SearchNotFound = "SearchNotFound",

                SubmissionTitle = "SubmissionTitle",
                SubmissionDescription = "SubmissionDescription",
                SubmissionFormTitle = "SubmissionFormTitle",
                SubmissionFormDescription = "SubmissionFormDescription",
                SubmissionFormAddress = "SubmissionFormAddress",
                SubmissionFormWebsite = "SubmissionFormWebsite",
                SubmissionFormCategory = "SubmissionFormCategory",
                SubmissionFormFeature = "SubmissionFormFeature",
                SubmissionFormPhone = "SubmissionFormPhone",
                SubmissionFormEmail = "SubmissionFormEmail",

                ContactTitle = "ContactTitle",
                ContactHeading = "ContactHeading",
                ContactName = "ContactName",
                ContactEmail = "ContactEmail",
                ContactDescription = "ContactDescription",

                ResultFromContact = "ResultFromContact",
                ResultFromSubmission = "ResultFromSubmission",

                MapTitle = "MapTitle",
                MapDescription = "MapDescription",

                Error404Title = "Error404Title",
                Error404Description = "Error404Description",
                Error500Title = "Error500Title",
                Error500Description = "Error500Description",
                Language = languages.First(l => l.CountryCode == "en"),
            };
            context.Pages.Add(page);

            var contact = new Contact {Name = "Bobby", Email = "bob@bob.bob", Message = "Important stuff"};
            context.Contacts.Add(contact);

            var categories = new List<Category>
            {
                new Category { Name = "Category 1" },
                new Category { Name = "Category 2" },
                new Category { Name = "Category 3" },
                new Category { Name = "Category 4" },
                new Category { Name = "Category 5" },
                new Category { Name = "Category 6" }
            };
            context.Categories.AddRange(categories);

            var categoryDetail = new CategoryDetail
            {
                Title = "Title",
                Description = "Description",
                ShortDescription = "ShortDescription",
                Language = languages.First(l => l.CountryCode == "en"),
                Category = categories.First()
            };
            context.CategoryDetails.Add(categoryDetail);

            var features = new List<Feature>
            {
                new Feature { Name = "Feature 1", Category = categories.First() },
                new Feature { Name = "Feature 2", Category = categories.First() },
                new Feature { Name = "Feature 3", Category = categories.First() },
                new Feature { Name = "Feature 4", Category = categories.First() },
                new Feature { Name = "Feature 5", Category = categories.First() },
                new Feature { Name = "Feature 6", Category = categories.First() }
            };
            context.Features.AddRange(features);

            var featureDetails = new List<FeatureDetail>
            {
                new FeatureDetail { Title = "Feature 1 Title", Feature = features.First(f => f.Name == "Feature 1"), Language = languages.First(l => l.CountryCode == "en") },
                new FeatureDetail { Title = "Feature 2 Title", Feature = features.First(f => f.Name == "Feature 2"), Language = languages.First(l => l.CountryCode == "en") },
                new FeatureDetail { Title = "Feature 3 Title", Feature = features.First(f => f.Name == "Feature 3"), Language = languages.First(l => l.CountryCode == "en") },
                new FeatureDetail { Title = "Feature 4 Title", Feature = features.First(f => f.Name == "Feature 4"), Language = languages.First(l => l.CountryCode == "en") },
                new FeatureDetail { Title = "Feature 5 Title", Feature = features.First(f => f.Name == "Feature 5"), Language = languages.First(l => l.CountryCode == "en") },
                new FeatureDetail { Title = "Feature 6 Title", Feature = features.First(f => f.Name == "Feature 6"), Language = languages.First(l => l.CountryCode == "en") },
            };
            context.FeatureDetails.AddRange(featureDetails);

            var resources = new List<Resource>
            {
                new Resource { Name = "Resource 1", Category = categories.First() },
                new Resource { Name = "Resource 2", Category = categories.First() },
                new Resource { Name = "Resource 3", Category = categories.First() },
                new Resource { Name = "Resource 4", Category = categories.First() }
            };
            context.Resources.AddRange(resources);

            var resourceDetails = new List<ResourceDetail>
            {
                new ResourceDetail
                {
                    Title = "Title",
                    Description = "Description",
                    ShortDescription = "ShortDescription",
                    Address = "Address",
                    GPSLong = -1.25785,
                    GPSLat = 51.752013,
                    Phone = "Phone",
                    Email = "Email",
                    Website = "Website",
                    OpeningHours = "OpeningHours",
                    Language = languages.First(l => l.CountryCode == "en"),
                    Resource = resources.First(r => r.Name == "Resource 1")
                },
                new ResourceDetail
                {
                    Title = "Title",
                    Description = "Description",
                    ShortDescription = "ShortDescription",
                    Address = "Address",
                    GPSLong = -1.25785,
                    GPSLat = 51.772013,
                    Phone = "Phone",
                    Email = "Email",
                    Website = "Website",
                    OpeningHours = "OpeningHours",
                    Language = languages.First(l => l.CountryCode == "en"),
                    Resource = resources.First(r => r.Name == "Resource 2")
                },
                new ResourceDetail
                {
                    Title = "Title",
                    Description = "Description",
                    ShortDescription = "ShortDescription",
                    Address = "Address",
                    GPSLong = -1.20785,
                    GPSLat = 51.772013,
                    Phone = "Phone",
                    Email = "Email",
                    Website = "Website",
                    OpeningHours = "OpeningHours",
                    Language = languages.First(l => l.CountryCode == "en"),
                    Resource = resources.First(r => r.Name == "Resource 3")
                },
                new ResourceDetail
                {
                    Title = "Title",
                    Description = "Description",
                    ShortDescription = "ShortDescription",
                    Address = "Address",
                    GPSLong = -1.25785,
                    GPSLat = 51.702013,
                    Phone = "Phone",
                    Email = "Email",
                    Website = "Website",
                    OpeningHours = "OpeningHours",
                    Language = languages.First(l => l.CountryCode == "en"),
                    Resource = resources.First(r => r.Name == "Resource 4")
                }
            };
            context.ResourceDetails.AddRange(resourceDetails);

            var resourceFeatures = new List<ResourceFeature>
            {
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 1"), Feature = features.First(f => f.Name == "Feature 1"), Enabled = true }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 1"), Feature = features.First(f => f.Name == "Feature 2"), Enabled = false }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 1"), Feature = features.First(f => f.Name == "Feature 3"), Enabled = false }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 1"), Feature = features.First(f => f.Name == "Feature 4"), Enabled = true }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 1"), Feature = features.First(f => f.Name == "Feature 5"), Enabled = false }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 1"), Feature = features.First(f => f.Name == "Feature 6"), Enabled = true }, 

                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 2"), Feature = features.First(f => f.Name == "Feature 1"), Enabled = false }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 2"), Feature = features.First(f => f.Name == "Feature 2"), Enabled = true }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 2"), Feature = features.First(f => f.Name == "Feature 3"), Enabled = true }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 2"), Feature = features.First(f => f.Name == "Feature 4"), Enabled = false }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 2"), Feature = features.First(f => f.Name == "Feature 5"), Enabled = true }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 2"), Feature = features.First(f => f.Name == "Feature 6"), Enabled = true }, 

                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 3"), Feature = features.First(f => f.Name == "Feature 1"), Enabled = true }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 3"), Feature = features.First(f => f.Name == "Feature 2"), Enabled = false }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 3"), Feature = features.First(f => f.Name == "Feature 3"), Enabled = false }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 3"), Feature = features.First(f => f.Name == "Feature 4"), Enabled = true }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 3"), Feature = features.First(f => f.Name == "Feature 5"), Enabled = true }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 3"), Feature = features.First(f => f.Name == "Feature 6"), Enabled = false }, 

                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 4"), Feature = features.First(f => f.Name == "Feature 1"), Enabled = false }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 4"), Feature = features.First(f => f.Name == "Feature 2"), Enabled = true }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 4"), Feature = features.First(f => f.Name == "Feature 3"), Enabled = false }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 4"), Feature = features.First(f => f.Name == "Feature 4"), Enabled = true }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 4"), Feature = features.First(f => f.Name == "Feature 5"), Enabled = true }, 
                new ResourceFeature { Resource = resources.First(r => r.Name == "Resource 4"), Feature = features.First(f => f.Name == "Feature 6"), Enabled = false }, 
            };
            context.ResourceFeatures.AddRange(resourceFeatures);



            context.SaveChanges();
        }
    }
}