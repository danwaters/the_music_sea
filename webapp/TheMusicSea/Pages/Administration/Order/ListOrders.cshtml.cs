using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheMusicSea.Entities;
using TheMusicSea.Services;

namespace TheMusicSea.Pages.Administration.Order
{
    public class ListOrdersModel : PageModel
    {
        private readonly IDataService _data;
        public List<CustomerOrder> Orders { get; set; }
        public List<SelectListItem> OrderStatusOptions { get; set; }
        public ListOrdersModel(IDataService data)
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
            Orders = _data.GetOrders();
        }
    }
}
