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

        public Item? Item { get; set; }

        public ViewProductModel(IDataService data)
        {
            _data = data;
            Departments = _data.GetDepartments();
        }

        public void OnGet(int? itemId)
        {
            if(itemId.HasValue)
            {
                Item = _data.GetItemByID(itemId.Value);
            }
        }
    }
}
