using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMusicSea.Entities;
using TheMusicSea.Services;

namespace TheMusicSea.Pages
{
    public class ViewProductModel : PageModel
    {
        public readonly List<Department> Departments;
        private readonly IDataService _data;

        public Item Item { get; set; }
        [BindProperty]
        public int ItemID { get; set; }
        [BindProperty]
        public int Quantity { get; set; }
        public List<string> Categories { get; set; }
        public bool InStock
        {
            get
            {
                return Item.InventoryCount > 0;
            }
        }
        public string StockMessage
        {
            get
            {
                if (InStock)
                    return $"In stock ({Item.InventoryCount} remaining)";
                return "Out of stock.";
            }
        }

        public bool LowStock
        {
            get
            {
                return Item.InventoryCount < 3;
            }
        }

        public string LowStockMessage
        {
            get
            {
                return $"Only {Item.InventoryCount} left in stock. Order soon!";
            }
        }

        public ViewProductModel(IDataService data)
        {
            _data = data;
            Departments = _data.GetDepartments();
            Categories = new List<string>();
        }

        public void OnGet(int itemId)
        {
            Item = _data.GetItemByID(itemId);
            var categories = _data.GetItemCategoriesByItemID(itemId);
            foreach (var c in categories)
            {
                Categories.Add(_data.GetCategoryById(c.CategoryID).Name.ToString());
            }
            ItemID = itemId;
        }

        public IActionResult OnPost()
        {
            var customer = _data.GetCustomerById(Customer.DefaultCustomerID);
            var cartId = _data.GetCartByCustomerID(customer.ID).ID; // TODO: Support more users
            _data.AddItemToCart(cartId, ItemID, Quantity);
            return RedirectToPage("/ViewCart", new { customerId = customer.ID });
        }
    }
}
