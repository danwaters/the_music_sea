using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMusicSea.Services;

namespace TheMusicSea.Pages.Administration.Department
{
    public class AddUpdateDepartmentModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Description { get; set; }

        public readonly IDataService _data;
        [BindProperty]
        public int? DepartmentID { get; set; }

        public AddUpdateDepartmentModel(IDataService data)
        {
            _data = data;
        }

        public void OnGet(int? departmentId)
        {
            DepartmentID = departmentId;

            if (DepartmentID != null)
            {
                var dept = _data.GetDepartmentById(DepartmentID.Value);
                Name = dept.Name;
                Description = dept.Description;
            }
        }

        public IActionResult OnPost()
        {
            if (DepartmentID == null)
            {
                var dept = _data.AddDepartment(Name, Description);
            }
            else
            {
                _data.UpdateDepartment(DepartmentID.Value, Name, Description);
            }

            return RedirectToPage("/Administration/Department/ListDepartments");
        }
    }
}
