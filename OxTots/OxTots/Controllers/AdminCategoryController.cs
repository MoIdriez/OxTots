using System.Linq;
using System.Web.Mvc;
using OxTots.Models;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    /// <summary>
    /// partial admin page - category page information
    /// </summary>
    public partial class AdminController
    {
        /// <summary>
        /// Displays the admin category page
        /// </summary>
        /// <returns></returns>
        public ActionResult Category()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var model = new AdminCategoryViewModel
            {
                Categories = Db.Categories.ToList()
            };
            return View(model);
        }

        /// <summary>
        /// Method is called to add a new category
        /// </summary>
        /// <param name="model">viewmodel with category name and icon</param>
        /// <returns>back to category method</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryAdd(AdminCategoryViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var c = new Category
            {
                Name = model.Name,
                Icon = model.Icon
            };
            Db.Categories.Add(c);
            Db.SaveChanges();
            return RedirectToAction("Category");
        }

        /// <summary>
        /// Method to edit the selected category by ID
        /// </summary>
        /// <param name="model">viewmodel with category name, icon, id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryEdit(AdminCategoryViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");
            var c = new Category
            {
                ID = model.ID,
                Name = model.Name,
                Icon = model.Icon
            };
            Db.Entry(Db.Categories.First(ct => ct.ID == model.ID)).CurrentValues.SetValues(c);
            Db.SaveChanges();
            return RedirectToAction("Category");
        }

        /// <summary>
        /// Remove category
        /// </summary>
        /// <param name="id">category id</param>
        /// <returns></returns>
        public ActionResult CategoryRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var c = Db.Categories.Single(s => s.ID == id);
            Db.Categories.Remove(c);
            Db.SaveChanges();
            return RedirectToAction("Category");
        }

        /// <summary>
        /// Displays a category's detail page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CategoryDetail(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var c = Db.Categories.Single(s => s.ID == id);
            var model = new AdminCategoryDetailViewModel
            {
                CategoryID = id,
                Languages = Db.Languages.ToList(),
                CategoryDetails = c.CategoryDetails.ToList()
            };
            return View(model);
        }

        /// <summary>
        /// Adds a new category detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryDetailAdd(AdminCategoryDetailViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var cd = new CategoryDetail
            {
                Title = model.Title,
                Description = model.Description,
                Language = Db.Languages.Single(l => l.ID == model.LanguageID),
                Category = Db.Categories.Single(c => c.ID == model.CategoryID)
            };
            Db.CategoryDetails.Add(cd);
            Db.SaveChanges();
            return RedirectToAction("CategoryDetail", new {id = model.CategoryID});
        }

        /// <summary>
        /// Edits a new category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryDetailEdit(AdminCategoryDetailViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");
            var c = new CategoryDetail
            {
                ID = model.ID,
                Title = model.Title,
                Description = model.Description
                
            };
            var categoryDetail = Db.CategoryDetails.First(ct => ct.ID == model.ID);
            categoryDetail.Language = Db.Languages.Single(l => l.ID == model.LanguageID);
            Db.Entry(categoryDetail).CurrentValues.SetValues(c);
            Db.SaveChanges();
            return RedirectToAction("CategoryDetail", new { id = model.CategoryID });
        }

        /// <summary>
        /// Remove a category detail
        /// </summary>
        /// <param name="id">id of the category detail to be removed</param>
        /// <returns></returns>
        public ActionResult CategoryDetailRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var c = Db.CategoryDetails.Single(s => s.ID == id);
            var cid = c.Category.ID;
            Db.CategoryDetails.Remove(c);
            Db.SaveChanges();
            return RedirectToAction("CategoryDetail", new { id = cid });
        }
    }
}