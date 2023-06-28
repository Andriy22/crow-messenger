namespace Client;

public partial class LogInPage : ContentPage
{
	public LogInPage()
	{
		InitializeComponent();
	}

    private async void GoToRegistration(object sender, SkiaSharp.Views.Maui.SKTouchEventArgs e)
    {
		await Shell.Current.GoToAsync("//RegistrationPage");
    }
}