using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMusicSea.Entities;
using TheMusicSea.Services;

namespace TheMusicSea.Pages
{
    public class ViewOrdersModel : PageModel
    {
        public List<CustomerOrder> Orders { get; set; }
        private readonly IDataService _data;

        public ViewOrdersModel(IDataService data)
        {
            _data = data;
        }
        public void OnGet()
        {
            this.Orders = _data.GetOrdersByCustomerId(Customer.DefaultCustomerID);
        }
    }
}
