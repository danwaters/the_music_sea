using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheMusicSea.Entities;
using TheMusicSea.Services;

namespace TheMusicSea.Pages.Administration.Item
{
    public class AddUpdateItemModel : PageModel
    {
        [BindProperty]
        public string SKU { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public double MSRP { get; set; }
        [BindProperty]
        public double Price { get; set; }
        [BindProperty]
        public string PhotoURI { get; set; }
        [BindProperty]
        public int InventoryCount { get; set; }
        [BindProperty]
        public int DepartmentID { get; set; }
        [BindProperty]
        public List<int> CategoryIDs { get; set; }
        [BindProperty]
        public int? ItemID { get; set; }

        public List<SelectListItem> DepartmentOptions { get; set; }
        public List<SelectListItem> CategoryOptions { get; set; }

        private readonly IDataService _data;

        public AddUpdateItemModel(IDataService data)
        {
            _data = data;
            var departments = _data.GetDepartments();
            var categories = _data.GetCategories();

            DepartmentOptions = departments.Select(d => new SelectListItem
            {
                Value = d.ID.ToString(),
                Text = d.Name
            }).ToList();
            DepartmentID = departments.First().ID;

            CategoryOptions = categories.OrderBy(c => c.Name).Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList();
            CategoryIDs = new List<int>();
        }
        public void OnGet(int? itemId)
        {
            ItemID = itemId;

            if (ItemID != null)
            {
                var item = _data.GetItemByID(ItemID.Value);

                SKU = item.SKU;
                Name = item.Name;
                Description = item.Description;
                MSRP = item.MSRP;
                Price = item.Price;
                PhotoURI = item.PhotoURI;
                InventoryCount = item.InventoryCount;
                DepartmentID = item.DepartmentID;
                CategoryIDs = _data.GetItemCategoriesByItemID(ItemID.Value).Select(c => c.CategoryID).ToList();
            }
        }

        public IActionResult OnPost()
        {
            if (ItemID == null)
            {
                var item = _data.AddItem(SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID, CategoryIDs);
            }
            else
            {
                _data.UpdateItem(ItemID.Value, SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID, CategoryIDs);
            }

            return RedirectToPage("/Administration/Item/ListItems");
        }
    }
}
