using System.Data;

namespace TheMusicSea.Services
{
    public interface IMySqlService
    {
        DataTable ExecuteReaderCommand(string sql);
    }
}
