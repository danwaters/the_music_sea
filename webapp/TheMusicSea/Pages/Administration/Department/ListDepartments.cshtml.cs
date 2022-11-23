using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheMusicSea.Entities;
using TheMusicSea.Services;

namespace TheMusicSea.Pages.Administration.Department
{
    public class ListDepartmentsModel : PageModel
    {
        private readonly IDataService _data;
        private readonly List<Entities.Department> _departments;
        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public int? SelectedDepartmentID { get; private set; }
        public ListDepartmentsModel(IDataService data)
        {
            this._data = data;
            _departments = this._data.GetDepartments();

            Options = _departments.Select(d => new SelectListItem { 
                Value = d.ID.ToString(), 
                Text = d.Name }).ToList();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int? departmentId)
        {
            return RedirectToPage("/Administration/Department/AddUpdateDepartment", new { departmentId = departmentId });
        }
    }
}
