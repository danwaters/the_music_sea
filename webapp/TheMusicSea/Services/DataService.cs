using Microsoft.AspNetCore.Http.Features;
using System.Data;
using TheMusicSea.Entities;
using System.Linq;
using Org.BouncyCastle.Asn1;
using System.Xml.Linq;

namespace TheMusicSea.Services
{
    public interface IDataService
    {
        List<Department> GetDepartments();
        List<Category> GetCategories();
        List<SalesEngineer> GetSalesEngineers();
        List<Item> GetItemsByDepartment(int departmentId);
        Department GetDepartmentById(int departmentId);
        Category GetCategoryById(int categoryId);
        SalesEngineer GetSalesEngineerById(int engineerId);
        Department AddDepartment(string name, string description);
        Category AddCategory(string name);
        SalesEngineer AddSalesEngineer(string firstName, string lastName, string email, string phone, int specialtyDepartmentId, string photoUri);
        Department UpdateDepartment(int id, string name, string description);
        Category UpdateCategory(int id, string name);
        SalesEngineer UpdateSalesEngineer(int id, string firstName, string lastName, string email, string phone, int specialtyDepartmentId, string photoUri);

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
            string sql = "SELECT ID, Name, Description FROM Department;";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var departments = new List<Department>();
            foreach(DataRow row in dt.Rows)
            {
                departments.Add(new Department(
                    Convert.ToInt32(row["ID"]), 
                    row["Name"].ToString(), row["Description"].ToString()));
            }

            return departments;
        }

        public List<Category> GetCategories()
        {
            string sql = "SELECT ID, Name FROM Category;";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var categories = new List<Category>();
            foreach(DataRow row in dt.Rows)
            {
                categories.Add(new Category(
                    Convert.ToInt32(row["ID"]),
                    row["Name"].ToString()));
            }

            return categories;
        }

        public List<SalesEngineer> GetSalesEngineers()
        {
            string sql = "SELECT ID, FirstName, LastName, Email, Phone, SpecialtyDepartmentID, PhotoURI FROM SalesEngineer;";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var engineers = new List<SalesEngineer>();
            foreach (DataRow row in dt.Rows)
            {
                engineers.Add(new SalesEngineer(
                    Convert.ToInt32(row["ID"]),
                    row["FirstName"].ToString(),
                    row["LastName"].ToString(),
                    row["Email"].ToString(),
                    row["Phone"].ToString(),
                    Convert.ToInt32(row["SpecialtyDepartmentID"]),
                    row["PhotoURI"].ToString()));
            }

            return engineers;
        }

        public Department GetDepartmentById(int departmentId)
        {
            string sql = $"SELECT * FROM Department WHERE ID = {departmentId};";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var row = dt.Rows[0];

            return new Department(
                Convert.ToInt32(row["ID"]),
                row["Name"].ToString(),
                row["Description"].ToString());
        }

        public Category GetCategoryById(int categoryId)
        {
            string sql = $"SELECT * FROM Category WHERE ID = {categoryId};";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var row = dt.Rows[0];

            return new Category(
                Convert.ToInt32(row["ID"]),
                row["Name"].ToString());
        }

        public SalesEngineer GetSalesEngineerById(int engineerId)
        {
            string sql = $"SELECT ID, FirstName, LastName, Email, Phone, SpecialtyDepartmentID, PhotoURI FROM SalesEngineer WHERE ID = {engineerId};";

            var dt = _mysql.ExecuteReaderCommand(sql);

            var row = dt.Rows[0];
            return new SalesEngineer(
                Convert.ToInt32(row["ID"]),
                row["FirstName"].ToString(),
                row["LastName"].ToString(),
                row["Email"].ToString(),
                row["Phone"].ToString(),
                Convert.ToInt32(row["SpecialtyDepartmentID"]),
                row["PhotoURI"].ToString());
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
        public Category AddCategory(string name)
        {
            string sql = $"INSERT INTO Category (Name) VALUES ('{name}');";
            int id = _mysql.ExecuteInsert(sql);
            return new Category(id, name);
        }

        public SalesEngineer AddSalesEngineer(string firstName, string lastName, string email, string phone, int specialtyDepartmentId, string photoUri)
        {
            string sql = $"INSERT INTO SalesEngineer (FirstName, LastName, Email, Phone, SpecialtyDepartmentID, PhotoURI) VALUES ('{firstName}', '{lastName}', '{email}', '{phone}', {specialtyDepartmentId}, '{photoUri}');";
            int id = _mysql.ExecuteInsert(sql);
            return new SalesEngineer(id, firstName, lastName, email, phone, specialtyDepartmentId, photoUri);
        }
        public Department UpdateDepartment(int id, string name, string description)
        {
            string sql = $"UPDATE Department SET Name = '{name}', Description = '{description}' WHERE ID = {id};";
            _mysql.ExecuteUpdate(sql);
            return new Department(id, name, description);
        }

        public Category UpdateCategory(int id, string name)
        {
            string sql = $"UPDATE Category SET Name = '{name}' WHERE ID = {id};";
            _mysql.ExecuteUpdate(sql);
            return new Category(id, name);
        }
        public SalesEngineer UpdateSalesEngineer(int id, string firstName, string lastName, string email, string phone, int specialtyDepartmentId, string photoUri)
        {
            string sql = $"UPDATE SalesEngineer SET FirstName = '{firstName}', LastName = '{lastName}', Email = '{email}', Phone = '{phone}', SpecialtyDepartmentID = {specialtyDepartmentId}, PhotoURI = '{photoUri}';";
            _mysql.ExecuteUpdate(sql);
            return new SalesEngineer(id, firstName, lastName, email, phone, specialtyDepartmentId, photoUri);
        }
    }
}
