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

        public ViewProductModel(IDataService data)
        {
            _data = data;
            Departments = _data.GetDepartments();
        }

        public void OnGet(int itemId)
        {
            Item = _data.GetItemByID(itemId);
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
