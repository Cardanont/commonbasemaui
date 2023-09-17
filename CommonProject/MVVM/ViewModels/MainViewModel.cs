using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommonProject.MVVM.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProject.MVVM.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }

        public MainViewModel()
        {
            FillData();
        }

        private void FillData()
        {
            // create a set of categories withoug pending tasks and percentage
            Categories = new ObservableCollection<Category>
            {
                new Category
                {
                    Id = 1,
                    CategoryName = "Personal",
                    Color = "#FFA500"
                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Work",
                    Color = "#FF0000"
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Shopping",
                    Color = "#FFFF00"
                },
                new Category
                {
                    Id = 4,
                    CategoryName = "Family",
                    Color = "#00FF00"
                },
                new Category
                {
                    Id = 5,
                    CategoryName = "Friends",
                    Color = "#0000FF"
                },
                new Category
                {
                    Id = 6,
                    CategoryName = "Other",
                    Color = "#FF00FF"
                }
            };  
        }
    }
}
