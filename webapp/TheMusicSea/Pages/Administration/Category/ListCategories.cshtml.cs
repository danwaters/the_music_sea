using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheMusicSea.Entities;
using TheMusicSea.Services;

namespace TheMusicSea.Pages.Administration.Category
{
    public class ListCategoriesModel : PageModel
    {
        private readonly IDataService _data;
        private readonly List<Entities.Category> _categories;
        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public int? SelectedCategoryID { get; private set; }

        public ListCategoriesModel(IDataService data)
        {
            this._data = data;
            _categories = this._data.GetCategories();

            Options = _categories.Select(c => new SelectListItem {
                Value = c.ID.ToString(),
                Text = c.Name }).ToList();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int? categoryId)
        {
            return RedirectToPage("/Administration/Category/AddUpdateCategory", new { categoryId = categoryId });
        }
    }
}
