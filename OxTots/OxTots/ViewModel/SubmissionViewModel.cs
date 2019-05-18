using System.Collections.Generic;
using OxTots.Models;

namespace OxTots.ViewModel
{
    public class SubmissionViewModel
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string SelectedType { get; set; }
        public string ActionNew { get; set; }
        public string ActionTranslate { get; set; }

        public string LanguageTitle { get; set; }
        public int SelectedLanguageID { get; set; }
        public List<Language> Languages { get; set; }

        public string PersonalTitle { get; set; }
        public string PersonalName { get; set; }
        public string PersonalNamePlaceholder { get; set; }
        public string PersonalEmail { get; set; }
        public string PersonalEmailPlaceholder { get; set; }

        public string ResourceTitle { get; set; }
        public string ResourceName { get; set; }
        public string ResourceNamePlaceholder { get; set; }
        public string ResourceEmail { get; set; }
        public string ResourceEmailPlaceholder { get; set; }
        public string ResourceWebsite { get; set; }
        public string ResourceWebsitePlaceholder { get; set; }
        public string ResourceAddress { get; set; }
        public string ResourceAddressPlaceholder { get; set; }
        public string ResourceDescription { get; set; }
        public string ResourceDescriptionPlaceholder { get; set; }


        public string GDPRText { get; set; }
        public string SubmitButtonText { get; set; }

        public string AssociatedResourceTitle { get; set; }
        public int SelectedResourceID { get; set; }
        public List<Resource> Resources { get; set; }
    }
}