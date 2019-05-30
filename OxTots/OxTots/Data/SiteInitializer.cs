using System.Collections.Generic;
using System.Linq;
using OxTots.Models;

namespace OxTots.Data
{
    public class SiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteContext>
    {
        protected override void Seed(SiteContext context)
        {
            // Get all the languages 
            var languages = new List<Language>
            {
                new Language { Name = "English", Icon = "united-kingdom.png" },
                new Language { Name = "عربي", Icon = "saudi-arabia.png", InverseDirection = true }
            };
            context.Languages.AddRange(languages);

            context.Pages.Add(GetEnglishPage(languages));
            context.Pages.Add(GetArabicPage(languages));

            var features = new List<string>
            {
                "Health visitor", "Breastfeeding support", "Stay and play", "Free", "Baby changing", "Refreshments provided", "Outdoors", "Buggy-friendly", "Learning", "Music", "Weekday", "Weekend"
            }.Select(f => new Feature
                {
                    Name = f,
                    FeatureDetails = new List<FeatureDetail>
                    {
                        new FeatureDetail { Title = f, Language = languages.First()}
                    }
                }
            ).ToList();

            context.Features.AddRange(features);

            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Health and Breastfeeding Support",
                    Icon = "fas fa-heartbeat"
                },
                new Category { Name = "Playgroups", Icon = "fas fa-child" },
                new Category { Name = "Activities", Icon = "fas fa-futbol" },
                new Category { Name = "For parents", Icon = "fas fa-users" }
            };


            var categoryDetails = new List<CategoryDetail>
            {
                new CategoryDetail
                {
                    Title = "Health and Breastfeeding Support",
                    Description = "Health and Breastfeeding Support Description",
                    ShortDescription = "Health and Breastfeeding Support Short Description",
                    Language = languages.First(),
                    Category = categories.First()
                },
                new CategoryDetail
                {
                    Title = "دعم الصحة والرضاعة الطبيعية",
                    Description = "وصف دعم الصحة والرضاعة الطبيعية",
                    ShortDescription = "وصف دعم الصحة والرضاعة الطبيعية",
                    Language = languages.Last(),
                    Category = categories.First()
                },
                new CategoryDetail
                {
                    Title = "Playgroups Support",
                    Description = "Playgroups Description",
                    ShortDescription = "Playgroups Description",
                    Language = languages.First(),
                    Category = categories.First(c => c.Name == "Playgroups")
                },
                new CategoryDetail
                {
                    Title = "Activities Support",
                    Description = "Activities Description",
                    ShortDescription = "Activities Description",
                    Language = languages.First(),
                    Category = categories.First(c => c.Name == "Activities")
                },
                new CategoryDetail
                {
                    Title = "For parents Support",
                    Description = "For parents Description",
                    ShortDescription = "For parents Description",
                    Language = languages.First(),
                    Category = categories.First(c => c.Name == "For parents")
                }
            };
            context.Categories.AddRange(categories);
            context.CategoryDetails.AddRange(categoryDetails);

            var resources = new List<Resource>
            {
                new Resource
                {
                    Name = "Health visitor - Grandpont",
                    GPSLong = -1.2619519,
                    GPSLat = 51.7430529,
                    Phone = "",
                    Email = "",
                    Website = "www.sofr.org.uk",
                    MainCategory = categories.First(),
                    Image = "/Images/listing/listing-1-1.jpg",
                    Icon = "/Images/map-marker.png",
                    ResourceDetails = new List<ResourceDetail> {
                        new ResourceDetail {
                            Title = "Health visitor - Grandpont",
                            Description = "Oxfordshire Breastfeeding Support, health visitor, and stay and play",
                            ShortDescription = "Oxfordshire Breastfeeding Support, health visitor, and stay and play",
                            Address = "South Oxford Family Room, Grandpont Nursery School and Children’s Centre, OX1 4QH",
                            OpeningHours = "Tuesday 10am - 12noon",
                            Language = languages.First()
                        }, new ResourceDetail {
                            Title = "زائر الصحة - Grandpont",
                            Description = "دعم أوكسفوردشاير للرضاعة الطبيعية ، زائر صحي ، والبقاء واللعب",
                            ShortDescription = "دعم أوكسفوردشاير للرضاعة الطبيعية ، زائر صحي ، والبقاء واللعب",
                            Address = " غرفة عائلية بجنوب أكسفورد ، مدرسة حضانة Grandpont ومركز الأطفال ، OX1 4QH",
                            OpeningHours = "الثلاثاء 10:00 حتي 12 ظهرا",
                            Language = languages.Last()
                        }
                    },
                    ResourceFeatures = new List<ResourceFeature>
                    {
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Health visitor"),
                            Enabled = true
                        },
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Breastfeeding support"),
                            Enabled = true
                        },
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Stay and play"),
                            Enabled = true
                        },
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Free"),
                            Enabled = true
                        }
                    }
                },
                new Resource
                {
                    Name = "Health visitor - Jericho",
                    GPSLong = -1.2679139,
                    GPSLat = 51.7600863,
                    Phone = "01865 559742",
                    Email = "",
                    Website = "",
                    MainCategory = categories.First(),
                    Image = "/Images/listing/listing-1-1.jpg",
                    Icon = "/Images/map-marker.png",
                    ResourceDetails = new List<ResourceDetail> { new ResourceDetail
                    {
                        Title = "Health visitor - Jericho",
                        Description = "Oxfordshire Breastfeeding Support, health visitor",
                        ShortDescription = "Oxfordshire Breastfeeding Support, health visitor",
                        Address = "Jericho Health Centre New Radcliffe House Walton Street Oxford OX2 6NW",
                        OpeningHours = "Wednesday 12noon - 2pm",
                        Language = languages.First()
                    }},
                    ResourceFeatures = new List<ResourceFeature>
                    {
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Health visitor"),
                            Enabled = true
                        },
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Breastfeeding support"),
                            Enabled = true
                        },
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Free"),
                            Enabled = true
                        }
                    }
                },
                new Resource
                {
                    Name = "Health visitor clinic - East Oxford",
                    GPSLong = -1.2346703,
                    GPSLat = 51.7472588,
                    Phone = "",
                    Email = "",
                    Website = "",
                    MainCategory = categories.First(),
                    Image = "/Images/listing/listing-1-1.jpg",
                    Icon = "/Images/map-marker.png",
                    ResourceDetails = new List<ResourceDetail> {
                        new ResourceDetail {
                            Title = "Health visitor - East Oxford",
                            Description = "Health visitor clinic",
                            ShortDescription = "Health visitor clinic",
                            Address = "East Oxford Health Centre, Manzil Way, Cowley Road, OX4 1XD",
                            OpeningHours = "Wednesday 11am - 12noon",
                            Language = languages.First()
                        },
                        new ResourceDetail {
                            Title = "زائر صحي - شرق أكسفورد",
                            Description = "عيادة الزائر الصحي",
                            ShortDescription = "عيادة الزائر الصحي",
                            Address = "مركز شرق أوكسفورد الصحي ، طريق المنزل ، طريق كاولي ، OX4 1XD",
                            OpeningHours = "الأربعاء 11:00 حتي 12 ظهرا",
                            Language = languages.Last()
                        }

                    },
                    ResourceFeatures = new List<ResourceFeature>
                    {
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Health visitor"),
                            Enabled = true
                        },
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Free"),
                            Enabled = true
                        }
                    }
                },
                new Resource
                {
                    Name = "Breastfeeding support - East Oxford",
                    GPSLong = -1.2370894,
                    GPSLat = 51.7481535,
                    Phone = "01865 248729",
                    Email = "",
                    Website = "",
                    MainCategory = categories.First(),
                    Image = "/Images/listing/listing-1-1.jpg",
                    Icon = "/Images/map-marker.png",
                    ResourceDetails = new List<ResourceDetail> { new ResourceDetail
                    {
                        Title = "Breastfeeding support - East Oxford",
                        Description = "Oxfordshire Breastfeeding Support",
                        ShortDescription = "Oxfordshire Breastfeeding Support",
                        Address = "East Oxford Children's Centre Collins Street Oxford OX4 1EE",
                        OpeningHours = "Thursday 1pm-3pm",
                        Language = languages.First()
                    }},
                    ResourceFeatures = new List<ResourceFeature>
                    {
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Breastfeeding support"),
                            Enabled = true
                        },
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Free"),
                            Enabled = true
                        }
                    }
                },
                new Resource
                {
                    Name = "Breastfeeding Support - Donnington",
                    GPSLong = -1.2389885,
                    GPSLat = 51.7367842,
                    Phone = "01865 727721",
                    Email = "",
                    Website = "",
                    MainCategory = categories.First(),
                    Image = "/Images/listing/listing-1-1.jpg",
                    Icon = "/Images/map-marker.png",
                    ResourceDetails = new List<ResourceDetail> { new ResourceDetail
                    {
                        Title = "Breastfeeding Support - Donnington",
                        Description = "Oxfordshire Breastfeeding Support",
                        ShortDescription = "Oxfordshire Breastfeeding Support",
                        Address = "Donnington Doorstep Family Centre Townsend Square Oxford OX4 4BB ",
                        OpeningHours = "Friday 12noon - 2pm",
                        Language = languages.First()
                    }},
                    ResourceFeatures = new List<ResourceFeature>
                    {
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Breastfeeding support"),
                            Enabled = true
                        },
                        new ResourceFeature
                        {
                            Feature = features.Single(f => f.Name == "Free"),
                            Enabled = true
                        }
                    }
                },
                new Resource
                {
                    Name = "Fit and Healthy Mums",
                    GPSLong = -1.2389885,
                    GPSLat = 51.7367842,
                    Phone = "",
                    Email = "",
                    Website = "http://www.fitandhealthymums.com/",
                    MainCategory = categories.First(),
                    Image = "/Images/listing/listing-1-1.jpg",
                    Icon = "/Images/map-marker.png",
                    ResourceDetails = new List<ResourceDetail> { new ResourceDetail
                    {
                        Title = "Fit and Healthy Mums",
                        Description = "Pre and post natal fitness, baby massage specialists",
                        ShortDescription = "Pre and post natal fitness, baby massage specialists",
                        Address = "Donnington Doorstep Family Centre Townsend Square Oxford OX4 4BB ",
                        OpeningHours = "",
                        Language = languages.First()
                    }}
                }
            };
            context.Resources.AddRange(resources);
            context.SaveChanges();
        }

        private static Page GetArabicPage(List<Language> languages)
        {
            return new Page
            {
                LayoutMenuListing = "الفئات",
                LayoutMenuSearch = "بحث",
                LayoutMenuSubmissions = "تقديم",
                LayoutMenuContact = "جهة الاتصال",
                LayoutMenuMap = "الخريطة",
                LayoutMenuAboutUs = "من نحن",

                LayoutFooterLink1 = "الخصوصية",
                LayoutFooterLink2 = "سياسة ملفات تعريف الارتباط",
                LayoutFooterLink1Content = "عن الأرضية ويكيبيديا غير, تطوير تغييرات هذا كل. أما ٣٠ يعادل الصفحة, في بعض وحلفاؤها الإنذار،, كلّ ثم الأول فرنسية ايطاليا،. رجوعهم المنتصر الدولارات بل حول, أن دنو جيوب قتيل، ارتكبها, هذا ٠٨٠٤ العالم قد. قبل ٣٠ عليها الوراء الدولارات, يبق ثم يعادل الإكتفاء.",
                LayoutFooterLink2Content = "عن الأرضية ويكيبيديا غير, تطوير تغييرات هذا كل. أما ٣٠ يعادل الصفحة, في بعض وحلفاؤها الإنذار،, كلّ ثم الأول فرنسية ايطاليا،. رجوعهم المنتصر الدولارات بل حول, أن دنو جيوب قتيل، ارتكبها, هذا ٠٨٠٤ العالم قد. قبل ٣٠ عليها الوراء الدولارات, يبق ثم يعادل الإكتفاء.",

                LayoutLanguagesTitle = "غير اللغة",
                LayoutLanguagesDescription = "عن الأرضية ويكيبيديا غير, تطوير تغييرات هذا كل. أما ٣٠ يعادل الصفحة, في بعض وحلفاؤها الإنذار،, كلّ ثم الأول فرنسية ايطاليا،. رجوعهم المنتصر الدولارات بل حول, أن دنو جيوب قتيل، ارتكبها, هذا ٠٨٠٤ العالم قد. قبل ٣٠ عليها الوراء الدولارات, يبق ثم يعادل الإكتفاء.",
                LayoutShareTitle = "مشاركة الصفحة",
                LayoutShareDescription = "عن الأرضية ويكيبيديا غير, تطوير تغييرات هذا كل. أما ٣٠ يعادل الصفحة, في بعض وحلفاؤها الإنذار،, كلّ ثم الأول فرنسية ايطاليا،. رجوعهم المنتصر الدولارات بل حول, أن دنو جيوب قتيل، ارتكبها, هذا ٠٨٠٤ العالم قد. قبل ٣٠ عليها الوراء الدولارات, يبق ثم يعادل الإكتفاء.",

                HomeSearch = "عما تبحث؟",
                HomeSearchError = "البحث عن النص المطلوب",
                HomeTitle = "عنوان المنزل",
                HomeDescription = "عن الأرضية ويكيبيديا غير, تطوير تغييرات هذا كل. أما ٣٠ يعادل الصفحة, في بعض وحلفاؤها الإنذار،, كلّ ثم الأول فرنسية ايطاليا،. رجوعهم المنتصر الدولارات بل حول, أن دنو جيوب قتيل، ارتكبها, هذا ٠٨٠٤ العالم قد. قبل ٣٠ عليها الوراء الدولارات, يبق ثم يعادل الإكتفاء.",
                HomeCategoriesText = "أو تصفح الفئات",

                Language = languages.Last()
            };
        }

        private static Page GetEnglishPage(List<Language> languages)
        {
            return new Page
            {
                LayoutGDPRTitle = "GDPR Notice",
                LayoutGDPRMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",
                LayoutGDPRButton = "Accept",
                LayoutMenuListing = "Categories",
                LayoutMenuSearch = "Search",
                LayoutMenuSubmissions = "Submission",
                LayoutMenuContact = "Contact",
                LayoutMenuMap = "Map",
                LayoutMenuAboutUs = "About Us",
                LayoutMainLogo = "/Images/logo.png",
                LayoutMainLogoAlt = "/Images/sticky-logo.png",

                LayoutLanguagesTitle = "Change Language",
                LayoutLanguagesDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",
                LayoutShareTitle = "Share Page",
                LayoutShareDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",

                LayoutFooterLink1 = "Privacy",
                LayoutFooterLink1Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",
                LayoutFooterLink2 = "Cookie Policy",
                LayoutFooterLink2Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",

                HomeImage = "/Images/figure/site-main-figure1.jpg",
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
                SearchGoToResource = "Go to this resource",
                SearchEmpty = "No search done",

                CategoryResultsFound = "Resources available",
                CategoryFilterDescription = "CategoryFilterDescription",
                CategoryGoToResource = "Go to this resource",

                SubmissionImage = "/Images/figure/site-main-figure1.jpg",
                SubmissionTitle = "Submission Title",
                SubmissionDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",
                SubmissionActionNew = "Enter a new resource",
                SubmissionActionTranslate = "Translate an existing resource",

                SubmissionLanguageTitle = "Please select the language associated with your submission",
                
                SubmissionFormPersonalTitle = "Please enter your contact information",
                SubmissionFormPersonalPlaceholderName = "Please enter your name",
                SubmissionFormPersonalPlaceholderEmail = "Please enter your email",

                SubmissionFormResourceTitle = "Please enter the resource information",
                SubmissionFormResourcePlaceholderName = "Enter name",
                SubmissionFormResourcePlaceholderDescription = "Enter description",
                SubmissionFormResourcePlaceholderEmail = "Enter email",
                SubmissionFormResourcePlaceholderWebsite = "Enter website",
                SubmissionFormResourcePlaceholderAddress = "Enter Address",

                SubmissionAssociatedResourceTitle = "Selected associated resource",
                SubmissionDescriptionGDPRNotice = "Do you agree with out Privacy Policy",
                SubmissionFormSubmitButtonText = "SubmissionFormSubmitButtonText",
                
                ContactTitle = "ContactTitle",
                ContactHeading = "ContactHeading",
                ContactName = "ContactName",
                ContactEmail = "ContactEmail",
                ContactDescription = "ContactDescription",
                ContactNamePlaceHolder = "Name *",
                ContactEmailPlaceHolder = "Email *",
                ContactMessagePlaceHolder = "Message *",
                ContactGDPRMessage = "Please check this to agree with GDPR something",
                ContactSubmitButtonText = "Submit Message *",

                ResultFromContact = "ResultFromContact",
                ResultFromSubmission = "ResultFromSubmission",

                MapTitle = "MapTitle",
                MapDescription = "MapDescription",

                AboutUsTitle = "AboutUsTitle",
                AboutUsImage = "/Images/figure/site-main-figure1.jpg",
                AboutUsDescription = "AboutUsDescription",
                AboutUsDescription2 = "AboutUsDescription2",

                Error404Title = "Error404Title",
                Error404Description = "Error404Description",
                Error500Title = "Error500Title",
                Error500Description = "Error500Description",
                ResourceContactTitle = "ResourceContactTitle",
                Language = languages.First(),

                OgAboutUsUrl = "https://wwww.oxtots.co.uk/AboutUs/",
                OgAboutUsTitle = "Check out ",
                OgAboutUsImage = "https://wwww.oxtots.co.uk/Images/logo.png",
                OgAboutUsDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",

                OgCategoryUrl = "https://wwww.oxtots.co.uk/MainCategory/Index/",
                OgCategoryTitle = "Check out ",
                OgCategoryImage = "https://wwww.oxtots.co.uk/Images/logo.png",
                OgCategoryDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",

                OgContactUrl = "https://wwww.oxtots.co.uk/Contact/",
                OgContactTitle = "Check out ",
                OgContactImage = "https://wwww.oxtots.co.uk/Images/logo.png",
                OgContactDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",

                OgHomeUrl = "https://wwww.oxtots.co.uk/",
                OgHomeTitle = "Check out ",
                OgHomeImage = "https://wwww.oxtots.co.uk/Images/logo.png",
                OgHomeDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",

                OgMapUrl = "https://wwww.oxtots.co.uk/Map/",
                OgMapTitle = "Check out ",
                OgMapImage = "https://wwww.oxtots.co.uk/Images/logo.png",
                OgMapDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",

                OgResourceUrl = "https://wwww.oxtots.co.uk/Resource/Index/",
                OgResourceTitle = "Check out ",
                OgResourceImage = "https://wwww.oxtots.co.uk/Images/logo.png",
                OgResourceDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",

                OgSearchUrl = "https://wwww.oxtots.co.uk/Search/",
                OgSearchTitle = "Check out ",
                OgSearchImage = "https://wwww.oxtots.co.uk/Images/logo.png",
                OgSearchDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",

                OgSubmissionUrl = "https://wwww.oxtots.co.uk/Submission/",
                OgSubmissionTitle = "Check out ",
                OgSubmissionImage = "https://wwww.oxtots.co.uk/Images/logo.png",
                OgSubmissionDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultricies et tortor a mattis. Mauris congue consequat luctus. Cras pellentesque consectetur nunc nec aliquam. Aenean vitae tortor enim. Ut in tellus vitae leo aliquam accumsan eget vitae libero. Nam pretium posuere urna, vitae maximus purus facilisis a.",
            };
        }
    }
}