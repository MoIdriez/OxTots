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

        public static ResourceDetail GetDetail(this Resource category)
        {
            var cc = CultureInfo.CurrentCulture;
            var cd = category.ResourceDetails.FirstOrDefault(c => c.Language.CountryCode == cc.Name);
            return cd ?? category.ResourceDetails.First(c => c.Language.CountryCode == DefaultLanguage);
        }

        public static Page GetPage(this DbSet<Page> pages)
        {
            var cc = CultureInfo.CurrentCulture;
            var page = pages.FirstOrDefault(p => p.Language.CountryCode == cc.Name);
            return page ?? pages.First(p => p.Language.CountryCode == DefaultLanguage);
        }

        public static List<MarkerViewModel> GetMarkers(this DbSet<Category> categories)
        {
            var resources = categories.SelectMany(c => c.Resources).ToList();
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
                    Icon = "/Images/map-marker.png"
                };
            }).ToList();
        }
    }
}