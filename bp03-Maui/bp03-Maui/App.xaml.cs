namespace bp03_Maui;
using bp03_Maui.Services;

public partial class App : Application
{
	public App(INavigationService navigationService)
	{
		InitializeComponent();
		MainPage = new NavigationPage();
		navigationService.NavigateToMainPage();
	}
}
