using System.Transactions;

namespace IncExpTrack.MVVM.ViewModels
{
    public class TransactionsViewModel
    {

        public Transaction Transaction { get; set; } = new Transaction();

        public string SaveTranasaction()
        {
            App.TransactionsRepo.SaveItem(Transaction);
            return App.TransactionsRepo.StatusMessage;
        }
    }
}
