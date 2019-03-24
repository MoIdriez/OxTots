using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OxTots.ViewModel
{
    public class SubmissionViewModel
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Name { get; set; }
        public string NamePlaceholder { get; set; }
        public string Email { get; set; }
        public string EmailPlaceholder { get; set; }
        public string ResourceName { get; set; }
        public string ResourceNamePlaceholder { get; set; }
        public string ResourceAddress { get; set; }
        public string ResourceAddressPlaceholder { get; set; }
        public string ResourceDescription { get; set; }
        public string ResourceDescriptionPlaceholder { get; set; }

        public string PersonalInformationTitle { get; set; }
        public string ResourceInformationTitle { get; set; }
        public string ResourceCategoryTitle { get; set; }
        public string ResourceFeatureTitle { get; set; }
        public string ExtraInformationText { get; set; }
        public string SubmitButtonText { get; set; }
        
        public string ResourcePhone { get; set; }
        public string ResourcePhonePlaceholder { get; set; }
        public string ResourceEmail { get; set; }
        public string ResourceEmailPlaceholder { get; set; }
        public string ResourceWebsite { get; set; }
        public string ResourceWebsitePlaceholder { get; set; }

        public int SelectedCategoryID { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}