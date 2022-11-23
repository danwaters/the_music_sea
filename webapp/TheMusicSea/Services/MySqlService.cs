using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace TheMusicSea.Services
{
    public class MySqlService : IMySqlService
    {
        public readonly IConfiguration _configuration;
        private string _connectionString = "";
        public MySqlService(IConfiguration configuration)
        {
            _configuration = configuration;
            this._connectionString = _configuration["MySqlConnection"];
        }

        public DataTable ExecuteReaderCommand(string sql)
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var cmd = new MySqlCommand(sql, conn);
            var dt = new DataTable();
            using (var reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }
            conn.Close();

            return dt;
        }
    }
}
