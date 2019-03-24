﻿namespace OxTots.Models
{
    public class Page
    {
        public int ID { get; set; }

        public string LayoutCookieTitle { get; set; }
        public string LayoutCookieDescription { get; set; }

        public string LayoutMainLogo { get; set; }
        public string LayoutMainLogoAlt { get; set; }

        public string LayoutMenuListing { get; set; }
        public string LayoutMenuSearch { get; set; }
        public string LayoutMenuSubmissions { get; set; }
        public string LayoutMenuContact { get; set; }
        public string LayoutMenuMap { get; set; }
        public string LayoutMenuAboutUs { get; set; }

        public string LayoutFooterLink1 { get; set; }
        public string LayoutFooterLink1Content { get; set; }
        public string LayoutFooterLink2 { get; set; }
        public string LayoutFooterLink2Content { get; set; }

        public string HomeImage { get; set; }
        public string HomeSearch { get; set; }
        public string HomeSearchError { get; set; }
        public string HomeTitle { get; set; }
        public string HomeDescription { get; set; }
        public string HomeCategoriesText { get; set; }

        public string SearchTitle { get; set; }
        public string SearchDescription { get; set; }
        public string SearchNotFound { get; set; }
        public string SearchPlaceHolder { get; set; }
        public string SearchError { get; set; }
        public string SearchResultsFound { get; set; }
        public string SearchGoToResource { get; set; }

        public string CategoryResultsFound { get; set; }
        public string CategoryFilterDescription { get; set; }
        public string CategoryGoToResource { get; set; }

        public string SubmissionImage { get; set; }
        public string SubmissionTitle { get; set; }
        public string SubmissionDescription { get; set; }
        public string SubmissionFormPersonalInformationTitle { get; set; }
        public string SubmissionFormResourceInformationTitle { get; set; }
        public string SubmissionFormResourceCategoryTitle { get; set; }
        public string SubmissionFormResourceFeatureTitle { get; set; }
        public string SubmissionFormExtraInformationText { get; set; }
        public string SubmissionFormSubmitButtonText { get; set; }
        public string SubmissionFormNamePlaceholder { get; set; }
        public string SubmissionFormEmailPlaceholder { get; set; }
        public string SubmissionFormResourceNamePlaceholder { get; set; }
        public string SubmissionFormResourceAddressPlaceholder { get; set; }
        public string SubmissionFormResourceDescriptionPlaceholder { get; set; }
        public string SubmissionFormResourcePhonePlaceholder { get; set; }
        public string SubmissionFormResourceEmailPlaceholder { get; set; }
        public string SubmissionFormResourceWebsitePlaceholder { get; set; }

        public string ContactTitle { get; set; }
        public string ContactHeading { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactDescription { get; set; }
        public string ContactNamePlaceHolder { get; set; }
        public string ContactEmailPlaceHolder { get; set; }
        public string ContactMessagePlaceHolder { get; set; }
        public string ContactSubmitButtonText { get; set; }

        public string ResultFromContact { get; set; }
        public string ResultFromSubmission { get; set; }

        public string MapTitle { get; set; }
        public string MapDescription { get; set; }

        public string AboutUsTitle { get; set; }
        public string AboutUsImage { get; set; }
        public string AboutUsDescription { get; set; }
        public string AboutUsDescription2 { get; set; }

        public string Error404Title { get; set; }
        public string Error404Description { get; set; }
        public string Error500Title { get; set; }
        public string Error500Description { get; set; }

        public string ResourceContactTitle { get; set; }


        public virtual Language Language { get; set; }
        
    }
}