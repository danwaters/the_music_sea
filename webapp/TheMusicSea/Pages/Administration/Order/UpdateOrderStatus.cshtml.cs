using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMusicSea.Services;
using TheMusicSea.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TheMusicSea.Pages.Administration.Order
{
    public class UpdateOrderStatusModel : PageModel
    {
        private readonly IDataService _data;
        public CustomerOrder Order { get; set; }
        public List<SelectListItem> OrderStatusOptions { get; set; }
        [BindProperty]
        public int OrderStatusID { get; set; }
        public UpdateOrderStatusModel(IDataService data)
        {
            _data = data;

            var orderStatuses = _data.GetOrderStatuses();
            OrderStatusOptions = orderStatuses.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Status
            }).ToList();
        }
        public void OnGet(int orderId)
        {
            Order = _data.GetOrderById(orderId);
            OrderStatusID = Order.OrderStatusID;
        }

        public IActionResult OnPost(int orderId)
        {
            Order = _data.GetOrderById(orderId);

            if(Order.OrderStatusID != OrderStatusID && OrderStatusID == (int)OrderStatusEnum.Shipped)
            {
                Order.TrackingCode = GenerateTrackingCode();
                Order.ShippedDate = DateTime.Now;
            }

            Order.OrderStatusID = OrderStatusID;

            _data.UpdateOrder(orderId, Order.ShippedDate, Order.OrderStatusID, Order.TrackingCode);

            return RedirectToPage("/Administration/Order/ListOrders");
        }

        private string GenerateTrackingCode()
        {
            var possibleChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var fakeTrackingCode = "1z";
            Random rnd = new Random();
            for (int i = 0; i < 16; i++)
            {
                fakeTrackingCode += possibleChars[rnd.Next(possibleChars.Length)];
            }
            return fakeTrackingCode;
        }
    }
}
