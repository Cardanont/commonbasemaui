using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Repositories
{
    public class CustomerRepository
    {
        SQLiteConnection connection;

        public CustomerRepository()
        {
            connection = 
                new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        }
    }
}
