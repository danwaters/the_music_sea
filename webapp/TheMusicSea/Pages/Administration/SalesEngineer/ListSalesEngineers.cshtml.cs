using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheMusicSea.Services;

namespace TheMusicSea.Pages.Administration.SalesEngineer
{
    public class ListSalesEngineersModel : PageModel
    {
        private readonly IDataService _data;
        private readonly List<Entities.SalesEngineer> _engineers;
        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public int? SelectedEngineerID { get; private set; }
        public ListSalesEngineersModel(IDataService data)
        {
            this._data = data;
            _engineers = this._data.GetSalesEngineers();

            Options = _engineers.Select(e => new SelectListItem
            {
                Value = e.ID.ToString(),
                Text = $"{e.LastName}, {e.FirstName}"
            }).ToList();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int? engineerId)
        {
            return RedirectToPage("/Administration/SalesEngineer/AddUpdateSalesEngineer", new { engineerId = engineerId });
        }
    }
}
