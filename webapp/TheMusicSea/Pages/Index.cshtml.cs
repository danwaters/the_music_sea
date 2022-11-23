using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data;
using System.Data;
using TheMusicSea.Services;

namespace TheMusicSea.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMySqlService _mysql;

        public IndexModel(ILogger<IndexModel> logger, IMySqlService mysql)
        {
            _logger = logger;
            _mysql = mysql;
        }

        public void OnGet()
        {
            var dt = _mysql.ExecuteReaderCommand("SELECT * FROM Department");
            foreach (DataRow row in dt.Rows)
            {
                _logger.LogInformation(row["Name"].ToString());
            }
        }
    }
}