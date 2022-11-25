using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMusicSea.Entities;
using TheMusicSea.Services;

namespace TheMusicSea.Pages
{
    public class ViewCartModel : PageModel
    {
        [BindProperty]
        public int CartID { get; set; }
        public List<CartItem> CartItems { get; set; }

        public double Subtotal
        {
            get
            {
                return CartItems.Sum(c => c.Quantity * c.Item.Price);
            }
        }

        public double Tax
        {
            get
            {
                return 0.0825;
            }
        }

        public double TaxAmount
        {
            get
            {
                return Subtotal * Tax;
            }
        }

        public double Total
        {
            get
            {
                return Subtotal + TaxAmount;
            }
        }

        private readonly IDataService _data;
        public ViewCartModel(IDataService data)
        {
            _data = data;
        }
        public void OnGet(int customerId)
        {
            var cartId = _data.GetCartByCustomerID(customerId).ID;
            CartID = cartId;
            CartItems = _data.GetCartItemsByCartId(cartId);
        }

        public IActionResult OnPost()
        {
            CartItems = _data.GetCartItemsByCartId(CartID);
            var customer = _data.GetCustomerById(Customer.DefaultCustomerID);
            var order = _data.AddCustomerOrder(customer.ID, customer.SalesEngineerID, DateTime.Now, null, (int)OrderStatusEnum.Initiated, Subtotal, TaxAmount, Total, "");
            return RedirectToPage("/OrderThankYou");
        }

        public IActionResult OnGetRemoveCartItem(int id)
        {
            CartItems = _data.DeleteCartItemById(id);
            return Page();
        }

        private string GenerateTrackingCode()
        {
            var possibleChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var fakeTrackingCode = "1z";
            Random rnd = new Random();
            for(int i = 0; i < 16; i++)
            {
                fakeTrackingCode += possibleChars[rnd.Next(possibleChars.Length)];
            }
            return fakeTrackingCode;
        }
    }
}
