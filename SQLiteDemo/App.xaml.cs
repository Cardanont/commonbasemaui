using SQLiteDemo.Repositories;
using SQLiteDemo.MVVM.Views;
using SQLiteDemo.MVVM.Models;

namespace SQLiteDemo
{
    public partial class App : Application
    {

        //public static  CustomerRepository CustomerRepo { get; private set; }
        public static BaseRepository<Customer> CustomerRepo { get; private set; }
        public static BaseRepository<Order> OrdersRepo { get; private set; }
        public static BaseRepository<Passport> PassportsRepo { get; private set; }


        public App(BaseRepository<Customer> repo, 
            BaseRepository<Order> orderRepo,
            BaseRepository<Passport> pasportRepo)
        {
            InitializeComponent();

            CustomerRepo = repo;
            OrdersRepo = orderRepo;
            PassportsRepo = pasportRepo;

            MainPage = new MainPage();
        }
    }
}