using SQLiteDemo.MVVM.ViewModels;

namespace SQLiteDemo.MVVM.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
			BindingContext = new MainPageViewModel();
	}
}