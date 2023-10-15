//using SQLite;
//using SQLiteDemo.MVVM.Models;
//using System.Linq.Expressions;

//namespace SQLiteDemo.Repositories
//{
//    public class CustomerRepository
//    {
//        SQLiteConnection connection;
//        public string StatusMessage { get; set; }

//        public CustomerRepository()
//        {
//            connection =
//                new SQLiteConnection(Constants.DatabasePath, Constants.Flags);

//            connection.CreateTable<Customer>();
//        }

//        public void AddOrUpdate(Customer customer)
//        {
//            int result = 0;

//            try
//            {
//                if (customer.ID != 0)
//                {
//                    // Update an existing customer
//                    result = connection.Update(customer);
//                    StatusMessage = $"{result} record(s) updated [Name: {customer.Name}]";
//                }
//                else
//                {
//                    // Add a new customer
//                    result = connection.Insert(customer);
//                    StatusMessage = $"{result} record(s) added [Name: {customer.Name}]";
//                }
//            }
//            catch (Exception ex)
//            {
//                StatusMessage = $"Failed to add {customer.Name}. Error: {ex.Message}";
//            }
//        }

//        public List<Customer> GetAll()
//        {
//            try
//            {
//                return connection.Table<Customer>().ToList();
//            }
//            catch (Exception ex)
//            {
//                StatusMessage =
//                    $"Failed to retrieve data. Error: {ex.Message}";
//            }

//            return null;
//        }

//        public List<Customer> GetAll(Expression<Func<Customer, bool>> predicate)
//        {
//            try
//            {
//                return connection.Table<Customer>().Where(predicate).ToList();
//            }
//            catch (Exception ex)
//            {
//                StatusMessage =
//                    $"Failed to retrieve data. Error: {ex.Message}";
//            }

//            return null;
//        }

//        public Customer Get(int id)
//        {
//            try
//            {
//                return connection.Table<Customer>().FirstOrDefault(c => c.ID == id);
//            }
//            catch (Exception ex)
//            {
//                StatusMessage =
//                    $"Failed to retrieve data. Error: {ex.Message}";
//            }

//            return null;
//        }

//        // Get all customers with sql query
//        public List<Customer> GetAllWithQuery()
//        {
//            try
//            {
//                return connection.Query<Customer>("SELECT * FROM Customers").ToList();
//            }
//            catch (Exception ex)
//            {
//                StatusMessage =
//                    $"Failed to retrieve data. Error: {ex.Message}";
//            }

//            return null;
//        }

//        public void Delete(int customerId)
//        {
//            try
//            {
//                var cusomer = Get(customerId);
//                connection.Delete(cusomer);
//            }
//            catch (Exception ex)
//            {
//                StatusMessage =
//                    $"Failed to delete {customerId}. Error: {ex.Message}";
//            }
//        }
//    }
//}
