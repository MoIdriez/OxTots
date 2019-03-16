using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace OxTots.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<CategoryDetail> CategoryDetails { get; set; }

        public CategoryDetail GetDetails()
        {
            var cc = CultureInfo.CurrentCulture;
            var cd = CategoryDetails.FirstOrDefault(c => c.Language.CountryCode == cc.Name);
            return cd ?? CategoryDetails.First(c => c.Language.CountryCode == "en");
        }
    }
}