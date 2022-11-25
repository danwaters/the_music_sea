using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMusicSea.Services;
using TheMusicSea.Entities;

namespace TheMusicSea.Pages
{
    public class OrderThankYouModel : PageModel
    {
        private readonly IDataService _data;
        public SalesEngineer SalesEngineer { get; set; }
        public string SalesEngineerFullName
        {
            get
            {
                return SalesEngineer.FirstName + " " + SalesEngineer.LastName;
            }
        }
        public OrderThankYouModel(IDataService data)
        {
            _data = data;
        }
        public void OnGet()
        {
            var customer = _data.GetCustomerById(Customer.DefaultCustomerID);
            SalesEngineer = _data.GetSalesEngineerById(customer.SalesEngineerID);
        }
    }
}
