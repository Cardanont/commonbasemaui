using CommonProject.MVVM.ViewModels;

namespace CommonProject.MVVM.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
			BindingContext = new MainViewModel();
	}
}