using Bogus;
using PropertyChanged;
using SQLiteDemo.MVVM.Models;
using System.Windows.Input;

namespace SQLiteDemo.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public List<Customer> Customers { get; set; }
        public Customer CurrentCustomer { get; set; }

        public ICommand AddOrUpdateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public MainPageViewModel()
        {
            var orders = App.OrdersRepo.GetItems();
            Refresh();
            GenerateNewCustomer();

            AddOrUpdateCommand = new Command(async =>
            {
                //App.CustomerRepo.SaveItem(CurrentCustomer);
                App.CustomerRepo.SaveItemWIthChildren(CurrentCustomer);
                Console.WriteLine(App.CustomerRepo.StatusMessage);
                GenerateNewCustomer();
                Refresh();
            });

            DeleteCommand = new Command(async =>
            {
                App.CustomerRepo.DeleteItem(CurrentCustomer);
                Console.WriteLine(App.CustomerRepo.StatusMessage);
                Refresh();
            });
        }

        private void GenerateNewCustomer()
        {
            CurrentCustomer = new Faker<Customer>().RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Address, f => f.Person.Address.Street)
                .Generate();

            CurrentCustomer.Passport = new List<Passport>
            {
                new Passport
                {
                    ExpirationDate = DateTime.Now.AddDays(30)
                },
                new Passport
                {
                    ExpirationDate = DateTime.Now.AddDays(15)
                }
            };
        }

        private void Refresh()
        {
            //Customers = App.CustomerRepo.GetItems();
            Customers = App.CustomerRepo.GetItemsWithChildren();
            //Customers = App.CustomerRepo.GetAll(c => c.Name.StartsWith("A"));

            var passports =
                App.PassportsRepo.GetItems();
        }
    }
}
