using CommonProject.MVVM.Views;

namespace CommonProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainView();
        }
    }
}