using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Xml.Linq;
using TheMusicSea.Entities;
using TheMusicSea.Services;

namespace TheMusicSea.Pages.Administration.SalesEngineer
{
    public class AddUpdateSalesEngineerModel : PageModel
    {
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public int SpecialtyDepartmentID { get; set; }
        [BindProperty]
        public string PhotoURI { get; set; }
        [BindProperty]
        public int? SalesEngineerID { get; set; }

        public List<SelectListItem> DepartmentOptions { get; set; }

        private readonly IDataService _data;

        public AddUpdateSalesEngineerModel(IDataService data)
        {
            _data = data;
            var departments = _data.GetDepartments();

            DepartmentOptions = departments.Select(d => new SelectListItem
            {
                Value = d.ID.ToString(),
                Text = d.Name
            }).ToList();
            SpecialtyDepartmentID = departments.First().ID;
        }

        public void OnGet(int? engineerId)
        {
            SalesEngineerID = engineerId;

            if (SalesEngineerID != null)
            {
                var dept = _data.GetSalesEngineerById(SalesEngineerID.Value);

                FirstName = dept.FirstName;
                LastName = dept.LastName;
                Email = dept.Email;
                Phone = dept.Phone;
                SpecialtyDepartmentID = dept.SpecialtyDepartmentID;
                PhotoURI = dept.PhotoURI;
            }
        }

        public IActionResult OnPost()
        {
            if (SalesEngineerID == null)
            {
                var dept = _data.AddSalesEngineer(FirstName, LastName, Email, Phone, SpecialtyDepartmentID, PhotoURI);
            }
            else
            {
                _data.UpdateSalesEngineer(SalesEngineerID.Value, FirstName, LastName, Email, Phone, SpecialtyDepartmentID, PhotoURI);
            }

            return RedirectToPage("/Administration/SalesEngineer/ListSalesEngineers");
        }
    }
}
