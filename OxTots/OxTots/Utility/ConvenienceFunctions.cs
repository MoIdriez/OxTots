using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OxTots.Models;
using OxTots.ViewModel;

namespace OxTots.Utility
{
    /// <summary>
    /// Several common convenience functions
    /// </summary>
    public static class ConvenienceFunctions
    {
        /// <summary>
        /// Method that gets a category detail of a category by the language id
        /// </summary>
        /// <param name="category"></param>
        /// <param name="languageID"></param>
        /// <returns></returns>
        public static CategoryDetail GetDetail(this Category category, int languageID)
        {
            return category.CategoryDetails.FirstOrDefault(c => c.Language.ID == languageID);
        }

        /// <summary>
        /// Method that gets a resource details of a resource by the language id
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="languageID"></param>
        /// <returns></returns>
        public static ResourceDetail GetDetail(this Resource resource, int languageID)
        {
            return resource.ResourceDetails.FirstOrDefault(c => c.Language.ID == languageID);
        }

        /// <summary>
        /// Method that gets a feature details of a feature by the language id
        /// </summary>
        /// <param name="feature"></param>
        /// <param name="languageID"></param>
        /// <returns></returns>
        public static FeatureDetail GetDetail(this Feature feature, int languageID)
        {
            return feature.FeatureDetails.FirstOrDefault(c => c.Language.ID == languageID);
        }

        /// <summary>
        /// Method that gets a specific page translation by the language id
        /// </summary>
        /// <param name="pages"></param>
        /// <param name="languageID"></param>
        /// <returns></returns>
        public static Page GetPage(this DbSet<Page> pages, int languageID)
        {
            return pages.FirstOrDefault(p => p.Language.ID == languageID);
        }

        /// <summary>
        /// Gets the map markers for a list of resources
        /// </summary>
        /// <param name="resources"></param>
        /// <param name="languageID"></param>
        /// <param name="dfLanguageID"></param>
        /// <returns></returns>
        public static List<MarkerViewModel> GetMarkerViewModels(this List<Resource> resources, int languageID, int dfLanguageID)
        {
            return resources.Select(r => r.GetMarkerViewModel(languageID, dfLanguageID)).ToList();
        }

        /// <summary>
        /// gets the map markers for a specific resource
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="languageID"></param>
        /// <param name="dfLanguageID"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Gets the resource filter view model used in the category and submission page
        /// </summary>
        /// <param name="resources"></param>
        /// <param name="languageID"></param>
        /// <param name="dfLanguageID"></param>
        /// <returns></returns>
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
                    Icon = r.MainCategory.Icon
                };
            }).ToList();
        }

        /// <summary>
        /// searches a list of resources by a query
        /// </summary>
        /// <param name="resources"></param>
        /// <param name="languageID"></param>
        /// <param name="dfLanguageID"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static List<Resource> SearchResources(this List<Resource> resources, int languageID, int dfLanguageID, string q)
        {
            q = q.Trim();
            return resources.Where(r =>
            {
                var resourceDetail = r.GetDetail(languageID) ?? r.GetDetail(dfLanguageID);
                return resourceDetail.Title.ToUpper().Contains(q.ToUpper()) 
                       || resourceDetail.Description.ToUpper().Contains(q.ToUpper())
                       || resourceDetail.Address.ToUpper().Contains(q.ToUpper())
                    ;
            }).ToList();
        }

        /// <summary>
        /// Casts a feature to a front end view model
        /// </summary>
        /// <param name="features"></param>
        /// <param name="languageID"></param>
        /// <param name="dfLanguageID"></param>
        /// <returns></returns>
        public static List<FeatureViewModel> ToViewModel(this List<Feature> features, int languageID, int dfLanguageID)
        {
            return features.Select(f =>
            {
                var featureDetail = f.GetDetail(languageID) ?? f.GetDetail(dfLanguageID);
                return new FeatureViewModel {ID = f.ID, Name = featureDetail.Title};
            }).ToList();
        }

        /// <summary>
        /// Cast a resource feature to a front end view model
        /// </summary>
        /// <param name="resourceFeature"></param>
        /// <param name="languageID"></param>
        /// <param name="dfLanguageID"></param>
        /// <returns></returns>
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