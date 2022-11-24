using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMusicSea.Entities;
using TheMusicSea.Services;

namespace TheMusicSea.Pages
{
    public class BrowseDepartmentModel : PageModel
    {
        private readonly IDataService _data;
        public List<Item> Items { get; set; }

        public readonly List<Department> Departments;

        public Department? Department { get; private set; }

        public BrowseDepartmentModel(IDataService data)
        {
            this._data = data;
            this.Departments = _data.GetDepartments();
        }
        public void OnGet(int departmentId)
        {
            this.Department = _data.GetDepartmentById(departmentId);

            this.Items = _data.GetItemsByDepartment(departmentId);
        }
    }
}
