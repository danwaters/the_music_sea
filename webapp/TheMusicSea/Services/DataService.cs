using Microsoft.AspNetCore.Http.Features;
using System.Data;
using TheMusicSea.Entities;
using System.Linq;
using Org.BouncyCastle.Asn1;
using System.Xml.Linq;
using System.Globalization;

namespace TheMusicSea.Services
{
    public interface IDataService
    {
        List<Department> GetDepartments();
        List<Category> GetCategories();
        List<SalesEngineer> GetSalesEngineers();
        List<Item> GetItems();
        List<Item> GetItemsByDepartment(int departmentId);
        Department GetDepartmentById(int departmentId);
        Category GetCategoryById(int categoryId);
        SalesEngineer GetSalesEngineerById(int engineerId);
        Item GetItemByID(int itemId);
        List<ItemCategory> GetItemCategoriesByItemID(int itemId);
        Department AddDepartment(string name, string description);
        Category AddCategory(string name);
        SalesEngineer AddSalesEngineer(string firstName, string lastName, string email, string phone, int specialtyDepartmentId, string photoUri);
        Item AddItem(string sku, string name, string description, double msrp, double price, string photoUri, int inventoryCount, int departmentId, List<int> categoryIds);
        Department UpdateDepartment(int id, string name, string description);
        Category UpdateCategory(int id, string name);
        SalesEngineer UpdateSalesEngineer(int id, string firstName, string lastName, string email, string phone, int specialtyDepartmentId, string photoUri);
        Item UpdateItem(int id, string sku, string name, string description, double msrp, double price, string photoUri, int inventoryCount, int departmentId, List<int> categoryIds);
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
                departments.Add(Department.FromDataRow(row));
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
                categories.Add(Category.FromDataRow(row));
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
                engineers.Add(SalesEngineer.FromDataRow(row));
            }

            return engineers;
        }

        public List<Item> GetItems()
        {
            string sql = "SELECT ID, SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID FROM Item;";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var items = new List<Item>();
            foreach (DataRow row in dt.Rows)
            {
                items.Add(Item.FromDataRow(row));
            }

            return items;
        }

        public List<ItemCategory> GetItemCategoriesByItemID(int itemId)
        {
            string sql = $"SELECT ID, ItemID, CategoryID FROM ItemCategory WHERE ItemID = {itemId};";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var itemCategories = new List<ItemCategory>();
            foreach(DataRow row in dt.Rows)
            {
                itemCategories.Add(ItemCategory.FromDataRow(row));
            }

            return itemCategories;
        }


        public Department GetDepartmentById(int departmentId)
        {
            string sql = $"SELECT * FROM Department WHERE ID = {departmentId};";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var row = dt.Rows[0];

            return Department.FromDataRow(row);
        }

        public Category GetCategoryById(int categoryId)
        {
            string sql = $"SELECT * FROM Category WHERE ID = {categoryId};";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var row = dt.Rows[0];

            return Category.FromDataRow(row);
        }

        public SalesEngineer GetSalesEngineerById(int engineerId)
        {
            string sql = $"SELECT ID, FirstName, LastName, Email, Phone, SpecialtyDepartmentID, PhotoURI FROM SalesEngineer WHERE ID = {engineerId};";

            var dt = _mysql.ExecuteReaderCommand(sql);

            var row = dt.Rows[0];
            return SalesEngineer.FromDataRow(row);
        }

        public List<Item> GetItemsByDepartment(int departmentId)
        {
            string sql = $"SELECT * FROM Item WHERE DepartmentID = {departmentId}";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var items = new List<Item>();
            foreach(DataRow row in dt.Rows)
            {
                items.Add(Item.FromDataRow(row));
            }

            return items;
        }
        public Item GetItemByID(int itemId)
        {
            string sql = $"SELECT ID, SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID FROM Item WHERE ID = {itemId}";
            var dt = _mysql.ExecuteReaderCommand(sql);

            var row = dt.Rows[0];
            return Item.FromDataRow(row);
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
        public Item AddItem(string sku, string name, string description, double msrp, double price, string photoUri, int inventoryCount, int departmentId, List<int> categoryIds)
        {
            string sql = $"INSERT INTO Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID) VALUES ('{sku}', '{name}', '{description}', {msrp}, {price}, '{photoUri}', {inventoryCount}, {departmentId});";
            int id = _mysql.ExecuteInsert(sql);

            // Update category mappings
            string deleteCategoriesSql = $"DELETE FROM ItemCategory WHERE ItemID = {id}";
            int affected = _mysql.ExecuteDelete(deleteCategoriesSql);

            // Build insert SQL for the category mappings - multiple row insert
            if (categoryIds.Count() > 0)
            {
                var insertCategoriesSql = "INSERT INTO ItemCategory (ItemID, CategoryID) VALUES ";
                for(int c = 0; c < categoryIds.Count(); c++)
                {
                    insertCategoriesSql += $"({id}, {categoryIds[c]})";
                    if (c < categoryIds.Count() - 1)
                        insertCategoriesSql += ", ";
                    else
                        insertCategoriesSql += ";";
                }
                _mysql.ExecuteMultiRowInsert(insertCategoriesSql);
            }
            return new Item(id, sku, name, description, msrp, price, photoUri, inventoryCount, departmentId);
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
        public Item UpdateItem(int id, string sku, string name, string description, double msrp, double price, string photoUri, int inventoryCount, int departmentId, List<int> categoryIds)
        {
            // Update the main item metadata
            string sql = $"UPDATE Item SET SKU = '{sku}', Name = '{name}', Description = '{description}', MSRP = {msrp}, Price = {price}, PhotoURI = '{photoUri}', InventoryCount = {inventoryCount}, DepartmentID = {departmentId};";
            _mysql.ExecuteUpdate(sql);

            // Update the item categories
            // Update category mappings
            string deleteCategoriesSql = $"DELETE FROM ItemCategory WHERE ItemID = {id}";
            int affected = _mysql.ExecuteDelete(deleteCategoriesSql);

            // Build insert SQL for the category mappings - multiple row insert
            if (categoryIds.Count() > 0)
            {
                var insertCategoriesSql = "INSERT INTO ItemCategory (ItemID, CategoryID) VALUES ";
                for (int c = 0; c < categoryIds.Count(); c++)
                {
                    insertCategoriesSql += $"({id}, {categoryIds[c]})";
                    if (c < categoryIds.Count() - 1)
                        insertCategoriesSql += ", ";
                    else
                        insertCategoriesSql += ";";
                }
                _mysql.ExecuteMultiRowInsert(insertCategoriesSql);
            }

            return new Item(id, sku, name, description, msrp, price, photoUri, inventoryCount, departmentId);
        }
    }
}
