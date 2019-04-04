using System.Collections.Generic;
using OxTots.Models;

namespace OxTots.ViewModel
{
    public class AdminCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public List<Category> Categories { get; set; }
    }
}