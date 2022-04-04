namespace bp03_Maui;
using bp03_Maui.ViewModels;
using bp03_Maui.Services;
using bp03_Maui.Models;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<MainPageViewModel>();

		builder.Services.AddTransient<INavigationService, NavigationService>();

		return builder.Build();
	}
}
