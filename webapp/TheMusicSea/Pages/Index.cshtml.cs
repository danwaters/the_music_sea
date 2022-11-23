using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data;
using System.Data;
using TheMusicSea.Entities;
using TheMusicSea.Services;

namespace TheMusicSea.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMySqlService _mysql;
        private readonly IDataService _data;

        public readonly List<Department> Departments;

        public IndexModel(ILogger<IndexModel> logger, IMySqlService mysql, IDataService data)
        {
            _logger = logger;
            _mysql = mysql;
            _data = data;

            Departments = _data.GetDepartments();
        }

        public void OnGet()
        {
            
        }
    }
}