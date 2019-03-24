using System.Collections.Generic;

namespace OxTots.ViewModel
{
    public class HomeViewModel
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SearchError { get; set; }
        public string CategoriesText { get; set; }
        public string SearchPlaceHolder { get; set; }
        public List<MarkerViewModel> Markers { get; set; }
        public List<HomeCategoryViewModel> Categories { get; set; }
    }

    public class HomeCategoryViewModel
    {
        public int ID { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
    }
}