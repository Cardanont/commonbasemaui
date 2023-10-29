using SQLiteDemo.Abstractions;
using SQLiteNetExtensions.Attributes;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;

namespace SQLiteDemo.MVVM.Models
{
    public class Passport : TableData
    {
        public DateTime ExpirationDate { get; set; }

        //[ForeignKey(typeof(Customer))]
        [ManyToMany(typeof(Customer))]
        public int CustomerId { get; set; }
    }
}
