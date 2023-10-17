using SQLiteDemo.Abstractions;

namespace SQLiteDemo.MVVM.Models
{
    public class Passport : TableData
    {
        public DateTime ExpirationDate { get; set; }
    }
}
