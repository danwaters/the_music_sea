using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheMusicSea.Entities;
using TheMusicSea.Services;

namespace TheMusicSea.Pages
{
    public class ViewOrdersModel : PageModel
    {
        public List<CustomerOrder> Orders { get; set; }
        private readonly IDataService _data;
        public List<SelectListItem> OrderStatusOptions { get; set; }

        public ViewOrdersModel(IDataService data)
        {
            _data = data;
            var orderStatuses = _data.GetOrderStatuses();
            OrderStatusOptions = orderStatuses.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.Status
            }).ToList();
        }
        public void OnGet()
        {
            this.Orders = _data.GetOrdersByCustomerId(Customer.DefaultCustomerID);
        }
    }
}
