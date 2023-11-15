using IncExpTrack.MVVM.Views;

namespace IncExpTrack
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TransactionsPage();
        }
    }
}