using System.Transactions;

namespace IncExpTrack.MVVM.ViewModels
{
    public class TransactionsViewModel
    {

        public Models.Transaction Transaction { get; set; } = new Models.Transaction();

        public string SaveTranasaction()
        {
            App.TransactionsRepo.SaveItem(Transaction);
            return App.TransactionsRepo.StatusMessage;
        }

    }
}
