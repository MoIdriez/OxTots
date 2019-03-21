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

                HomeSearch = "What are you looking for?",
                HomeSearchError = "Search text required",
                HomeTitle = "HomeTitle",
                HomeDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",
                HomeCategoriesText = "Or Browse The Categories",

                SearchTitle = "SearchTitle",
                SearchDescription = "SearchDescription",
                SearchNotFound = "SearchNotFound",
                SearchPlaceHolder = "SearchPlaceHolder",
                SearchError = "SearchError",
                SearchResultsFound = "Results found",

                CategoryResultsFound = "Resources available",
                CategoryFilterDescription = "CategoryFilterDescription",

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
                Language = languages.First(l => l.CountryCode == "en-GB"),
            };
            context.Pages.Add(page);

            var contact = new Contact { Name = "Bobby", Email = "bob@bob.bob", Message = "Important stuff" };
            context.Contacts.Add(contact);

            var categories = new List<Category>
            {
                new Category { Name = "Category 1", Icon = "flaticon-chef" },
                new Category { Name = "Category 2", Icon = "flaticon-dish" },
                new Category { Name = "Category 3", Icon = "flaticon-supermarket" },
                new Category { Name = "Category 4", Icon = "flaticon-musical-note" },
                new Category { Name = "Category 5", Icon = "flaticon-coffee-cup" },
                new Category { Name = "Category 6", Icon = "flaticon-hotel" }
            };
            context.Categories.AddRange(categories);

            var categoryDetails = new List<CategoryDetail>
            {
                new CategoryDetail
                {
                    Title = "Category 1",
                    Description = "Description",
                    ShortDescription = "ShortDescription",
                    Language = languages.First(l => l.CountryCode == "en-GB"),
                    Category = categories.First()
                },
                new CategoryDetail
                {
                    Title = "Category 2",
                    Description = "Description",
                    ShortDescription = "ShortDescription",
                    Language = languages.First(l => l.CountryCode == "en-GB"),
                    Category = categories.First(c => c.Name == "Category 2")
                },
                new CategoryDetail
                {
                    Title = "Category 3",
                    Description = "Description",
                    ShortDescription = "ShortDescription",
                    Language = languages.First(l => l.CountryCode == "en-GB"),
                    Category = categories.First(c => c.Name == "Category 3")
                },
                new CategoryDetail
                {
                    Title = "Category 4",
                    Description = "Description",
                    ShortDescription = "ShortDescription",
                    Language = languages.First(l => l.CountryCode == "en-GB"),
                    Category = categories.First(c => c.Name == "Category 4")
                },
                new CategoryDetail
                {
                    Title = "Category 5",
                    Description = "Description",
                    ShortDescription = "ShortDescription",
                    Language = languages.First(l => l.CountryCode == "en-GB"),
                    Category = categories.First(c => c.Name == "Category 5")
                },
                new CategoryDetail
                {
                    Title = "Category 6",
                    Description = "Description",
                    ShortDescription = "ShortDescription",
                    Language = languages.First(l => l.CountryCode == "en-GB"),
                    Category = categories.First(c => c.Name == "Category 6")
                }

            };
            context.CategoryDetails.AddRange(categoryDetails);

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
                new FeatureDetail { Title = "Feature 1 Title", Feature = features.First(f => f.Name == "Feature 1"), Language = languages.First(l => l.CountryCode == "en-GB") },
                new FeatureDetail { Title = "Feature 2 Title", Feature = features.First(f => f.Name == "Feature 2"), Language = languages.First(l => l.CountryCode == "en-GB") },
                new FeatureDetail { Title = "Feature 3 Title", Feature = features.First(f => f.Name == "Feature 3"), Language = languages.First(l => l.CountryCode == "en-GB") },
                new FeatureDetail { Title = "Feature 4 Title", Feature = features.First(f => f.Name == "Feature 4"), Language = languages.First(l => l.CountryCode == "en-GB") },
                new FeatureDetail { Title = "Feature 5 Title", Feature = features.First(f => f.Name == "Feature 5"), Language = languages.First(l => l.CountryCode == "en-GB") },
                new FeatureDetail { Title = "Feature 6 Title", Feature = features.First(f => f.Name == "Feature 6"), Language = languages.First(l => l.CountryCode == "en-GB") },
            };
            context.FeatureDetails.AddRange(featureDetails);

            var resources = new List<Resource>
            {
                new Resource {
                    Name = "Resource 1",
                    Address = "Address",
                    GPSLong = -1.25785,
                    GPSLat = 51.752013,
                    Phone = "Phone",
                    Email = "Email",
                    Website = "Website",
                    Category = categories.First(),
                    Image = "/Images/listing/listing-1-1.jpg",
                    Icon = "/Images/map-marker.png"
                },
                new Resource
                {
                    Name = "Resource 2",
                    Address = "Address",
                    GPSLong = -1.25785,
                    GPSLat = 51.772013,
                    Phone = "Phone",
                    Email = "Email",
                    Website = "Website",
                    Category = categories.First(),
                    Image = "/Images/listing/listing-1-1.jpg",
                    Icon = "/Images/map-marker.png"
                },
                new Resource {
                    Name = "Resource 3",
                    Address = "Address",
                    GPSLong = -1.20785,
                    GPSLat = 51.772013,
                    Phone = "Phone",
                    Email = "Email",
                    Website = "Website",
                    Category = categories.First(),
                    Image = "/Images/listing/listing-1-1.jpg",
                    Icon = "/Images/map-marker.png"
                },
                new Resource
                {
                    Name = "Resource 4",
                    Address = "Address",
                    GPSLong = -1.25785,
                    GPSLat = 51.702013,
                    Phone = "Phone",
                    Email = "Email",
                    Website = "Website",
                    Category = categories.First(),
                    Image = "/Images/listing/listing-1-1.jpg",
                    Icon = "/Images/map-marker.png"
                }
            };
            context.Resources.AddRange(resources);

            var resourceDetails = new List<ResourceDetail>
            {
                new ResourceDetail
                {
                    Title = "Resource 1 Title",
                    Description = "Resource 1 Description",
                    ShortDescription = "Resource 1 ShortDescription",
                    OpeningHours = "Resource 1 OpeningHours",
                    Language = languages.First(l => l.CountryCode == "en-GB"),
                    Resource = resources.First(r => r.Name == "Resource 1")
                },
                new ResourceDetail
                {
                    Title = "Resource 2 Title",
                    Description = "Resource 2 Description",
                    ShortDescription = "Resource 2 ShortDescription",
                    OpeningHours = "Resource 2 OpeningHours",
                    Language = languages.First(l => l.CountryCode == "en-GB"),
                    Resource = resources.First(r => r.Name == "Resource 2")
                },
                new ResourceDetail
                {
                    Title = "Resource 3 Title",
                    Description = "Resource 3 Description",
                    ShortDescription = "Resource 3 ShortDescription",
                    OpeningHours = "Resource 3 OpeningHours",
                    Language = languages.First(l => l.CountryCode == "en-GB"),
                    Resource = resources.First(r => r.Name == "Resource 3")
                },
                new ResourceDetail
                {
                    Title = "Resource 4 Title",
                    Description = "Resource 4 Description",
                    ShortDescription = "Resource 4 ShortDescription",
                    OpeningHours = "Resource 4 OpeningHours",
                    Language = languages.First(l => l.CountryCode == "en-GB"),
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