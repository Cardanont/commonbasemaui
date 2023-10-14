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
            Refresh();
            GenerateNewCustomer();

            AddOrUpdateCommand = new Command(async =>
            {
                App.CustomerRepo.AddOrUpdate(CurrentCustomer);
                Console.WriteLine(App.CustomerRepo.StatusMessage);
                GenerateNewCustomer();
                Refresh();
            });

            DeleteCommand = new Command(async =>
            {
                App.CustomerRepo.Delete(CurrentCustomer.ID);
                Console.WriteLine(App.CustomerRepo.StatusMessage);
                Refresh();
            });
        }

        private void GenerateNewCustomer()
        {
            CurrentCustomer = new Faker<Customer>().RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Address, f => f.Person.Address.Street)
                .Generate();
        }

        private void Refresh()
        {
            Customers = App.CustomerRepo.GetAll();
        }
    }
}
