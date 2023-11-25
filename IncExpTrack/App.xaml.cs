using IncExpTrack.MVVM.Models;
using IncExpTrack.MVVM.Views;
using IncExpTrack.Repositories;

namespace IncExpTrack
{
    public partial class App : Application
    {

        public static BaseRepository<Transaction> TransactionsRepo { get; private set; }

        public App(BaseRepository<Transaction> _transactionsRepo)
        {
            InitializeComponent();

            TransactionsRepo = _transactionsRepo;

            MainPage = new TransactionsPage();
        }
    }
}