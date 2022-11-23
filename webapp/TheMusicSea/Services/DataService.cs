using Microsoft.AspNetCore.Http.Features;
using System.Data;
using TheMusicSea.Entities;
using System.Linq;

namespace TheMusicSea.Services
{
    public interface IDataService
    {
        List<Department> GetDepartments();
        List<Item> GetItemsByDepartment(int departmentId);
        Department GetDepartmentById(int departmentId);
        Department AddDepartment(string name, string description);
        Department UpdateDepartment(int id, string name, string description);
    }
    public class DataService : IDataService
    {
        public readonly IMySqlService _mysql;
        public DataService(IMySqlService mysql)
        {
            _mysql = mysql;
        }

        public List<Department> GetDepartments()
        {
            string sql = "SELECT ID, Name, Description FROM Department";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var departments = new List<Department>();
            foreach(DataRow row in dt.Rows)
            {
                departments.Add(new Department(Convert.ToInt32(row["ID"]), 
                    row["Name"].ToString(), row["Description"].ToString()));
            }

            return departments;
        }

        public Department GetDepartmentById(int departmentId)
        {
            string sql = $"SELECT * FROM Department WHERE ID = {departmentId}";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var row = dt.Rows[0];

            return new Department(
                Convert.ToInt32(row["ID"]),
                row["Name"].ToString(),
                row["Description"].ToString());
        }

        public List<Item> GetItemsByDepartment(int departmentId)
        {
            string sql = $"SELECT * FROM Item WHERE DepartmentID = {departmentId}";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var items = new List<Item>();
            foreach(DataRow row in dt.Rows)
            {
                items.Add(new Item(
                    Convert.ToInt32(row["SKU"]),
                    row["Name"].ToString(),
                    row["Description"].ToString(),
                    Convert.ToDouble(row["MSRP"]),
                    Convert.ToDouble(row["Price"]),
                    row["PhotoURI"].ToString(),
                    departmentId)
               );
            }

            return items;
        }

        public Department AddDepartment(string name, string description)
        {
            string sql = $"INSERT INTO Department (Name, Description) VALUES ('{name}', '{description}');";
            int id = _mysql.ExecuteInsert(sql);
            return new Department(id, name, description);
        }

        public Department UpdateDepartment(int id, string name, string description)
        {
            string sql = $"UPDATE Department SET Name = '{name}', Description = '{description}' WHERE ID = {id};";
            _mysql.ExecuteUpdate(sql);
            return new Department(id, name, description);
        }
    }
}
