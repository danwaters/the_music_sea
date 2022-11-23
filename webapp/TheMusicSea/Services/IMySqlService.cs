using System.Data;

namespace TheMusicSea.Services
{
    public interface IMySqlService
    {
        DataTable ExecuteReaderCommand(string sql);
        int ExecuteInsert(string sql);
        bool ExecuteUpdate(string sql);
    }
}
