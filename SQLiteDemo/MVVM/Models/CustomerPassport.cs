using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;

namespace SQLiteDemo.MVVM.Models
{
    public class CustomerPassport
    {
        [ForeignKey(typeof(Customer))]
        public int CustomerId { get; set; }
        [ForeignKey(typeof(Passport))]
        public int PassportId { get; set; }
    }
}
