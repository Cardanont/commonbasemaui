using SQLite;
using SQLiteDemo.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Repositories
{
    public class BaseRepository<T> :
        IBaseRepository<T> where T : TableData, new()
    {

        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public BaseRepository()
        {
            connection = 
                new SQLiteConnection(Constants.DatabasePath,
                Constants.Flags);
            connection.CreateTable<T>();
        }


        public void DeleteItem(T item)
        {
            try
            {
                int result = connection.Delete(item);
                StatusMessage =
                    $"{result} record(s) deleted [Name: {item}]";
            }
            catch (Exception ex)
            {
                StatusMessage =
                    $"Failed to delete {item}. Error: {ex.Message}";
            }
        }

        public void Dispose()
        {
            connection.Close();
        }

        public T GetItem(int id)
        {
            try
            {
                return connection.Table<T>().FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage =
                    $"Failed to retrieve data. Error: {ex.Message}";
            }

            return null;
        }

        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return connection.Table<T>().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                StatusMessage =
                    $"Failed to retrieve data. Error: {ex.Message}";
            }

            return null;
        }

        public List<T> GetItems()
        {
            try
            {
                return connection.Table<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage =
                    $"Failed to retrieve data. Error: {ex.Message}";
            }

            return null;
        }

        public List<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return connection.Table<T>().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage =
                    $"Failed to retrieve data. Error: {ex.Message}";
            }

            return null;
        }

        public void SaveItem(T item)
        {
            int result = 0;

            try
            {
                if (item.Id != 0)
                {
                    // Update an existing customer
                    result = connection.Update(item);
                    StatusMessage = $"{result} record(s) updated [Name: {item}]";
                }
                else
                {
                    // Add a new customer
                    result = connection.Insert(item);
                    StatusMessage = $"{result} record(s) added [Name: {item}]";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to add {item}. Error: {ex.Message}";
            }
        }
    }
}
