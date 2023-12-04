using IncExpTrack.MVVM.ViewModels;

namespace IncExpTrack.MVVM.Views;

public partial class TransactionsPage : ContentPage
{
	public TransactionsPage()
	{
		InitializeComponent();
	}

    private async void Save_Clicked(object sender, EventArgs e)
    {
        var currentVM = 
            (TransactionsViewModel)BindingContext;
        
        var message = 
            currentVM.SaveTranasaction();

        await DisplayAlert("Info", message, "OK");
        await Navigation.PopToRootAsync();
    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}