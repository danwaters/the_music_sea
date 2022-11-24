using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMusicSea.Services;

namespace TheMusicSea.Pages.Administration.Category
{
    public class AddUpdateCategoryModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public int? CategoryID { get; set; }

        private readonly IDataService _data;
        public AddUpdateCategoryModel(IDataService data)
        {
            _data = data;
        }
        public void OnGet(int? categoryId)
        {
            CategoryID = categoryId;

            if (CategoryID != null)
            {
                var cat = _data.GetCategoryById(CategoryID.Value);
                Name = cat.Name;
            }
        }

        public IActionResult OnPost()
        {
            if(CategoryID == null)
            {
                var cat = _data.AddCategory(Name);
            }
            else
            {
                _data.UpdateCategory(CategoryID.Value, Name);
            }

            return RedirectToPage("/Administration/Category/ListCategories");
        }
    }
}
