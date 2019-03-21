using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using OxTots.Models;
using OxTots.ViewModel;

namespace OxTots.Utility
{
    public static class ConvenienceFunctions
    {
        private static string DefaultLanguage => "en-GB";
        public static CategoryDetail GetDetail(this Category category)
        {
            var cc = CultureInfo.CurrentCulture;
            var cd = category.CategoryDetails.FirstOrDefault(c => c.Language.CountryCode == cc.Name);
            return cd ?? category.CategoryDetails.First(c => c.Language.CountryCode == DefaultLanguage);
        }

        public static ResourceDetail GetDetail(this Resource resource)
        {
            var cc = CultureInfo.CurrentCulture;
            var cd = resource.ResourceDetails.FirstOrDefault(c => c.Language.CountryCode == cc.Name);
            return cd ?? resource.ResourceDetails.First(c => c.Language.CountryCode == DefaultLanguage);
        }

        public static FeatureDetail GetDetail(this Feature feature)
        {
            var cc = CultureInfo.CurrentCulture;
            var cd = feature.FeatureDetails.FirstOrDefault(c => c.Language.CountryCode == cc.Name);
            return cd ?? feature.FeatureDetails.First(c => c.Language.CountryCode == DefaultLanguage);
        }

        public static Page GetPage(this DbSet<Page> pages)
        {
            var cc = CultureInfo.CurrentCulture;
            var page = pages.FirstOrDefault(p => p.Language.CountryCode == cc.Name);
            return page ?? pages.First(p => p.Language.CountryCode == DefaultLanguage);
        }

        public static List<MarkerViewModel> GetMarkerViewModels(this DbSet<Category> categories, string q = "")
        {
            var resources = SearchResources(categories, q);
            return resources.Select(r =>
            {
                var rd = r.GetDetail();
                return new MarkerViewModel
                {
                    ID = r.ID,
                    Title = rd.Title,
                    Description = rd.Description,
                    Long = r.GPSLong,
                    Lat = r.GPSLat,
                    Icon = r.Icon
                };
            }).ToList();
        }

        public static List<MarkerViewModel> GetMarkerViewModels(this List<Resource> resources)
        {
            return resources.Select(r =>
            {
                var rd = r.GetDetail();
                return new MarkerViewModel
                {
                    ID = r.ID,
                    Title = rd.Title,
                    Description = rd.Description,
                    Long = r.GPSLong,
                    Lat = r.GPSLat,
                    Icon = r.Icon
                };
            }).ToList();
        }

        public static List<MarkerViewModel> GetMarkerViewModels(this Category category)
        {
            var resources = category.Resources;
            return resources.Select(r =>
            {
                var rd = r.GetDetail();
                return new MarkerViewModel
                {
                    ID = r.ID,
                    Title = rd.Title,
                    Description = rd.Description,
                    Long = r.GPSLong,
                    Lat = r.GPSLat,
                    Icon = r.Icon
                };
            }).ToList();
        }

        public static List<ResourceFilterViewModel> GetResourceFilterViewModel(this DbSet<Category> categories, string q = "")
        {
            var resources = SearchResources(categories, q);
            return resources.Select(r =>
            {
                var rd = r.GetDetail();
                return new ResourceFilterViewModel
                {
                    ID = r.ID,
                    Title = rd.Title,
                    Description = rd.Description,
                    Image = r.Image,
                    Icon = r.Category.Icon
                };
            }).ToList();
        }

        public static List<ResourceFilterViewModel> GetResourceFilterViewModel(this List<Resource> resources)
        {
            return resources.Select(r =>
            {
                var rd = r.GetDetail();
                return new ResourceFilterViewModel
                {
                    ID = r.ID,
                    Title = rd.Title,
                    Description = rd.Description,
                    Image = r.Image,
                    Icon = r.Category.Icon
                };
            }).ToList();
        }

        public static List<ResourceFilterViewModel> GetResourceFilterViewModel(this Category category)
        {
            return category.Resources.Select(r =>
            {
                var rd = r.GetDetail();
                return new ResourceFilterViewModel
                {
                    ID = r.ID,
                    Title = rd.Title,
                    Description = rd.Description,
                    Image = r.Image,
                    Icon = r.Category.Icon
                };
            }).ToList();
        }

        private static IEnumerable<Resource> SearchResources(DbSet<Category> categories, string q)
        {
            q = q.Trim();
            var resources = categories.SelectMany(c => c.Resources).ToList().Where(r =>
            {
                var resourceDetail = r.GetDetail();
                return resourceDetail.Title.ToUpper().Contains(q.ToUpper()) || resourceDetail.Description.ToUpper().Contains(q.ToUpper());
            });
            return resources;
        }

        public static List<FeatureViewModel> ToViewModel(this ICollection<Feature> features)
        {
            return features.Select(f => new FeatureViewModel {ID = f.ID, Name = f.GetDetail().Title}).ToList();
        }
    }
}