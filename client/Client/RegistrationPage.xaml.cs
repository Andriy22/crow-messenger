namespace Client;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}

    private void InputNameAndPassword(object sender, SkiaSharp.Views.Maui.SKTouchEventArgs e)
    {
        NameAndPasswordPanel.IsVisible = false;
        EmailPanel.IsVisible = true;
    }

    private void InputEmail(object sender, SkiaSharp.Views.Maui.SKTouchEventArgs e)
    {
        EmailPanel.IsVisible = false;
        LastPanel.IsVisible = true;
    }

    private void EndRegistration(object sender, SkiaSharp.Views.Maui.SKTouchEventArgs e)
    {

    }
}