using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OxTots.Models;
using OxTots.ViewModel;

namespace OxTots.Utility
{
    public static class ConvenienceFunctions
    {
        public static CategoryDetail GetDetail(this Category category, int languageID)
        {
            return category.CategoryDetails.FirstOrDefault(c => c.Language.ID == languageID);
        }

        public static ResourceDetail GetDetail(this Resource resource, int languageID)
        {
            return resource.ResourceDetails.FirstOrDefault(c => c.Language.ID == languageID);
        }

        public static FeatureDetail GetDetail(this Feature feature, int languageID)
        {
            return feature.FeatureDetails.FirstOrDefault(c => c.Language.ID == languageID);
        }

        public static Page GetPage(this DbSet<Page> pages, int languageID)
        {
            return pages.FirstOrDefault(p => p.Language.ID == languageID);
        }

        public static List<MarkerViewModel> GetMarkerViewModels(this List<Category> categories, int languageID, int dfLanguageID, string q = "")
        {
            var resources = SearchResources(categories, languageID, dfLanguageID, q);
            return resources.Select(r =>
            {
                var rd = r.GetDetail(languageID) ?? r.GetDetail(dfLanguageID);
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

        public static List<MarkerViewModel> GetMarkerViewModels(this List<Resource> resources, int languageID, int dfLanguageID)
        {
            return resources.Select(r =>
            {
                var rd = r.GetDetail(languageID) ?? r.GetDetail(dfLanguageID);
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

        public static List<MarkerViewModel> GetMarkerViewModels(this Category category, int languageID, int dfLanguageID)
        {
            var resources = category.Resources;
            return resources.Select(r =>
            {
                var rd = r.GetDetail(languageID) ?? r.GetDetail(dfLanguageID);
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

        public static MarkerViewModel GetMarkerViewModel(this Resource resource, int languageID, int dfLanguageID)
        {
            var rd = resource.GetDetail(languageID) ?? resource.GetDetail(dfLanguageID);
            return new MarkerViewModel
                {
                    ID = resource.ID,
                    Title = rd.Title,
                    Description = rd.Description,
                    Long = resource.GPSLong,
                    Lat = resource.GPSLat,
                    Icon = resource.Icon
                };
        }

        public static List<ResourceFilterViewModel> GetResourceFilterViewModel(this List<Category> categories, int languageID, int dfLanguageID, string q = "")
        {
            var resources = SearchResources(categories, languageID, dfLanguageID, q);
            return resources.Select(r =>
            {
                var rd = r.GetDetail(languageID) ?? r.GetDetail(dfLanguageID);
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

        public static List<ResourceFilterViewModel> GetResourceFilterViewModel(this List<Resource> resources, int languageID, int dfLanguageID)
        {
            return resources.Select(r =>
            {
                var rd = r.GetDetail(languageID) ?? r.GetDetail(dfLanguageID);
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

        public static List<ResourceFilterViewModel> GetResourceFilterViewModel(this Category category, int languageID, int dfLanguageID)
        {
            return category.Resources.Select(r =>
            {
                var rd = r.GetDetail(languageID) ?? r.GetDetail(dfLanguageID);
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

        private static IEnumerable<Resource> SearchResources(List<Category> categories, int languageID, int dfLanguageID, string q)
        {
            q = q.Trim();
            var resources = categories.SelectMany(c => c.Resources).ToList().Where(r =>
            {
                var resourceDetail = r.GetDetail(languageID) ?? r.GetDetail(dfLanguageID);
                return resourceDetail.Title.ToUpper().Contains(q.ToUpper()) 
                       || resourceDetail.Description.ToUpper().Contains(q.ToUpper())
                       || resourceDetail.Address.ToUpper().Contains(q.ToUpper())
                    ;
            });
            return resources;
        }

        public static List<FeatureViewModel> ToViewModel(this List<Feature> features, int languageID, int dfLanguageID)
        {
            return features.Select(f =>
            {
                var featureDetail = f.GetDetail(languageID) ?? f.GetDetail(dfLanguageID);
                return new FeatureViewModel {ID = f.ID, Name = featureDetail.Title};
            }).ToList();
        }

        public static List<FeatureViewModel> ToViewModel(this List<ResourceFeature> resourceFeature, int languageID, int dfLanguageID)
        {
            return resourceFeature.Select(rf =>
            {
                var featureDetail = rf.Feature.GetDetail(languageID) ?? rf.Feature.GetDetail(dfLanguageID);
                return new FeatureViewModel
                {
                    Name = featureDetail.Title,
                    IsSelected = rf.Enabled
                };
            }).ToList();
        }
    }
}