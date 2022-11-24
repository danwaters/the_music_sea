using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheMusicSea.Services;

namespace TheMusicSea.Pages.Administration.Item
{
    public class ListItemsModel : PageModel
    {
        private readonly IDataService _data;
        private readonly List<Entities.Item> _items;
        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public int? SelectedItemID { get; private set; }

        public ListItemsModel(IDataService data)
        {
            this._data = data;
            _items = this._data.GetItems();

            Options = _items.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int? itemId)
        {
            return RedirectToPage("/Administration/Item/AddUpdateItem", new { itemId = itemId });
        }
    }
}
