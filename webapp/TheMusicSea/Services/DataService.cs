using Microsoft.AspNetCore.Http.Features;
using System.Data;
using TheMusicSea.Entities;
using System.Linq;
using Org.BouncyCastle.Asn1;
using System.Xml.Linq;
using System.Globalization;
using TheMusicSea.Helpers;

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
        Cart GetCartByCustomerID(int customerId);
        Cart GetCartByID(int cartId);
        List<CartItem> GetCartItemsByCartId(int cartId);
        CartItem GetCartItemById(int cartItemId);
        List<CustomerOrder> GetOrders();
        List<OrderStatus> GetOrderStatuses();
        List<CustomerOrder> GetOrdersByCustomerId(int customerId);
        CustomerOrder GetOrderById(int orderId);
        Customer GetCustomerById(int customerId);
        List<CartItem> DeleteCartItemById(int cartItemId);
        Cart EmptyCart(int cartId);
        Department AddDepartment(string name, string description);
        Category AddCategory(string name);
        SalesEngineer AddSalesEngineer(string firstName, string lastName, string email, string phone, int specialtyDepartmentId, string photoUri);
        Item AddItem(string sku, string name, string description, double msrp, double price, string photoUri, int inventoryCount, int departmentId, List<int> categoryIds);
        Cart AddItemToCart(int cartId, int itemId, int quantity);
        CustomerOrder AddCustomerOrder(int customerId, int salesEngineerId, DateTime placedDate, DateTime? shippedDate, int orderStatusId, double subtotal, double tax, double total, string trackingCode);
        Department UpdateDepartment(int id, string name, string description);
        Category UpdateCategory(int id, string name);
        SalesEngineer UpdateSalesEngineer(int id, string firstName, string lastName, string email, string phone, int specialtyDepartmentId, string photoUri);
        Item UpdateItem(int id, string sku, string name, string description, double msrp, double price, string photoUri, int inventoryCount, int departmentId, List<int> categoryIds);
        CustomerOrder UpdateOrder(int id, DateTime? shippedDate, int orderStatusId, string trackingCode);
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
        public Cart GetCartByCustomerID(int customerId)
        {
            string sql = $"SELECT ID, CustomerID FROM Cart WHERE CustomerID = {customerId}";
            var dt = _mysql.ExecuteReaderCommand(sql);
            var row = dt.Rows[0];
            return Cart.FromDataRow(row);
        }
        public Cart GetCartByID(int cartId)
        {
            string sql = $"SELECT ID, CustomerID FROM Cart WHERE ID = {cartId}";
            var dt = _mysql.ExecuteReaderCommand(sql);
            var row = dt.Rows[0];
            return Cart.FromDataRow(row);
        }
        public List<CartItem> GetCartItemsByCartId(int cartId)
        {
            // In this case we hydrate the Item itself to make it easier when we view the cart
            string sql = $"SELECT ID, CartID, ItemID, Quantity FROM CartItem WHERE CartID = {cartId}";
            var dt = _mysql.ExecuteReaderCommand(sql);
            var cartItems = new List<CartItem>();
            foreach(DataRow row in dt.Rows)
            {
                var cartItem = CartItem.FromDataRow(row);
                cartItem.Item = GetItemByID(cartItem.ItemID);
                cartItems.Add(cartItem);
            }
            return cartItems;
        }
        public CartItem GetCartItemById(int cartItemId)
        {
            string sql = $"SELECT ID, CartID, ItemID, Quantity FROM CartItem WHERE ID = {cartItemId};";
            var dt = _mysql.ExecuteReaderCommand(sql);
            var row = dt.Rows[0];
            return CartItem.FromDataRow(row);
        }
        public List<CustomerOrder> GetOrders()
        {
            string sql = $"SELECT ID, CustomerID, SalesEngineerID, PlacedDate, ShippedDate, OrderStatusID, Subtotal, Tax, Total, TrackingCode FROM CustomerOrder;";
            var dt = _mysql.ExecuteReaderCommand(sql);
            var orders = new List<CustomerOrder>();
            foreach (DataRow row in dt.Rows)
            {
                orders.Add(CustomerOrder.FromDataRow(row));
            }
            return orders;
        }
        public List<OrderStatus> GetOrderStatuses()
        {
            string sql = $"SELECT ID, Status FROM OrderStatus";
            var dt = _mysql.ExecuteReaderCommand(sql);
            var orderStatuses = new List<OrderStatus>();
            foreach(DataRow row in dt.Rows)
            {
                orderStatuses.Add(OrderStatus.FromDataRow(row));
            }
            return orderStatuses;
        }
        public List<CustomerOrder> GetOrdersByCustomerId(int customerId)
        {
            string sql = $"SELECT ID, CustomerID, SalesEngineerID, PlacedDate, ShippedDate, OrderStatusID, Subtotal, Tax, Total, TrackingCode FROM CustomerOrder WHERE CustomerID = {customerId};";
            var dt = _mysql.ExecuteReaderCommand(sql);
            var orders = new List<CustomerOrder>();
            foreach(DataRow row in dt.Rows)
            {
                orders.Add(CustomerOrder.FromDataRow(row));
            }
            return orders;
        }
        public CustomerOrder GetOrderById(int orderId)
        {
            string sql = $"SELECT ID, CustomerID, SalesEngineerID, PlacedDate, ShippedDate, OrderStatusID, Subtotal, Tax, Total, TrackingCode FROM CustomerOrder WHERE ID = {orderId};";
            var dt = _mysql.ExecuteReaderCommand(sql);
            var row = dt.Rows[0];
            return CustomerOrder.FromDataRow(row);
        }
        public Customer GetCustomerById(int customerId)
        {
            string sql = $"SELECT ID, FirstName, LastName, Email, Phone, AddressLine1, AddressLine2, City, StateProvince, Postcode, Country, SalesEngineerID FROM Customer WHERE ID = {customerId};";
            var dt = _mysql.ExecuteReaderCommand(sql);
            var row = dt.Rows[0];
            return Customer.FromDataRow(row);
        }
        public List<CartItem> DeleteCartItemById(int cartItemId)
        {
            var cartItem = GetCartItemById(cartItemId);  
            string sql = $"DELETE FROM CartItem WHERE ID = {cartItemId};";
            _mysql.ExecuteDelete(sql);

            return GetCartItemsByCartId(cartItem.CartID);
        }
        public Cart EmptyCart(int cartId)
        {
            string sql = $"DELETE FROM CartItem WHERE CartID = {cartId}";
            _mysql.ExecuteDelete(sql);
            return GetCartByID(cartId);
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
        public Cart AddItemToCart(int cartId, int itemId, int quantity)
        {
            string sql = $"INSERT INTO CartItem (CartID, ItemID, Quantity) VALUES ({cartId}, {itemId}, {quantity});";
            _mysql.ExecuteInsert(sql);
            return GetCartByID(cartId);
        }
        public CustomerOrder AddCustomerOrder(int customerId, int salesEngineerId, DateTime placedDate, DateTime? shippedDate, int orderStatusId, double subtotal, double tax, double total, string trackingCode)
        {
            var customer = GetCustomerById(customerId);
            string sql = $@"INSERT INTO CustomerOrder (CustomerID, SalesEngineerID, PlacedDate, ShippedDate, OrderStatusID, Subtotal, Tax, Total, TrackingCode) 
                VALUES ({customerId}, {customer.SalesEngineerID}, '{placedDate.ToMySqlDatetime()}', NULL, {orderStatusId}, {subtotal}, {tax}, {total}, '{trackingCode}');";

            int id = _mysql.ExecuteInsert(sql);

            return new CustomerOrder(id, customerId, placedDate, shippedDate, orderStatusId, subtotal, tax, total, trackingCode);
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
            string sql = $"UPDATE SalesEngineer SET FirstName = '{firstName}', LastName = '{lastName}', Email = '{email}', Phone = '{phone}', SpecialtyDepartmentID = {specialtyDepartmentId}, PhotoURI = '{photoUri}' WHERE ID = {id};";
            _mysql.ExecuteUpdate(sql);
            return new SalesEngineer(id, firstName, lastName, email, phone, specialtyDepartmentId, photoUri);
        }
        public Item UpdateItem(int id, string sku, string name, string description, double msrp, double price, string photoUri, int inventoryCount, int departmentId, List<int> categoryIds)
        {
            // Update the main item metadata
            string sql = $"UPDATE Item SET SKU = '{sku}', Name = '{name}', Description = '{description}', MSRP = {msrp}, Price = {price}, PhotoURI = '{photoUri}', InventoryCount = {inventoryCount}, DepartmentID = {departmentId} WHERE ID = {id};";
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

        public CustomerOrder UpdateOrder(int id, DateTime? shippedDate, int orderStatusId, string trackingCode)
        {
            string shipDate = shippedDate.HasValue ? $"'{shippedDate.Value.ToMySqlDatetime()}'" : "NULL";
            string sql = $"UPDATE CustomerOrder SET OrderStatusID = {orderStatusId}, TrackingCode = '{trackingCode}', ShippedDate = {shipDate} WHERE ID = {id};";
            _mysql.ExecuteUpdate(sql);
            return GetOrderById(id);
        }
    }
}
