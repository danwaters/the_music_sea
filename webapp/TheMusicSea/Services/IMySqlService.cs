using System.Data;

namespace TheMusicSea.Services
{
    public interface IMySqlService
    {
        DataTable ExecuteReaderCommand(string sql);
        int ExecuteInsert(string sql);
        int ExecuteMultiRowInsert(string sql);
        bool ExecuteUpdate(string sql);
        int ExecuteDelete(string sql);
    }
}
