using TheMusicSea.Entities;

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
}
