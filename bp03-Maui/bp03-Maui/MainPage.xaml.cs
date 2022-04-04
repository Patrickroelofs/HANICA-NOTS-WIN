namespace bp03_Maui;
using bp03_Maui.ViewModels;

public partial class MainPage : ContentPage
{
  public MainPage(MainPageViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}

