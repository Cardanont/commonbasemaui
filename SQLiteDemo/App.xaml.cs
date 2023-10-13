using SQLiteDemo.Repositories;
using SQLiteDemo.MVVM.Views;

namespace SQLiteDemo
{
    public partial class App : Application
    {

        public static  CustomerRepository CustomerRepo { get; private set; }

        public App(CustomerRepository repo)
        {
            InitializeComponent();

            CustomerRepo = repo;

            MainPage = new MainPage();
        }
    }
}