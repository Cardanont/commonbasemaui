using SQLiteDemo.Abstractions;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;

namespace SQLiteDemo.MVVM.Models
{
    public class Passport : TableData
    {
        public DateTime ExpirationDate { get; set; }

        [ForeignKey(typeof(Customer))]
        public int CustomerId { get; set; }
    }
}
