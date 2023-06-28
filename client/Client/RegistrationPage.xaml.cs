using Application.Common.DTOs.Registration;
using Client.Consts;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace Client;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}

    private async void InputNameAndPassword(object sender, SkiaSharp.Views.Maui.SKTouchEventArgs e)
    {
        if(UserNameField.Text.Length < 4)
        {
            UserNameField.IsError = true;
            UserNameField.SupportingText = "Name is too short! As your DICK!";
            return;
        }

        if (!RegexConsts.UserName.IsMatch(UserNameField.Text))
        {
            UserNameField.IsError = true;
            UserNameField.SupportingText = "Name can contain only English letters and English numbers! God bless America!";
            return;
        }

        using(var http = new HttpClient())
        {
            var respons = await http.GetAsync($"https://1ce8-194-44-167-129.ngrok-free.app/api/Utilities/check-nickname-availability?nickname={UserNameField.Text}");

            if (respons.IsSuccessStatusCode)
            {
                var canUse = bool.Parse(await respons.Content.ReadAsStringAsync());

                if (!canUse)
                {
                    UserNameField.IsError = true;
                    UserNameField.SupportingText = "This username is already used! You even can't come up with a unique nickname! moron.";
                    return;
                }
            }
        }

        if (PasswordField.Text != RepeatPasswordField.Text)
        {
            RepeatPasswordField.IsError = true;
            RepeatPasswordField.SupportingText = "The passwords are not matching! Your and your so-called \"father\" DNA tests to, btw.";
            return;
        }

        if (string.IsNullOrEmpty(PasswordField.Text))
        {
            PasswordField.IsError = true;
            PasswordField.SupportingText = "The password can not be null! But your bank account can.";
            return;
        }

        if (PasswordField.Text.Length < 10)
        {
            PasswordField.IsError = true;
            PasswordField.SupportingText = "The password is to short! lol";
            return;
        }

        NameAndPasswordPanel.IsVisible = false;
        EmailPanel.IsVisible = true;
    }

    private async void InputEmail(object sender, SkiaSharp.Views.Maui.SKTouchEventArgs e)
    {
        
        if(!RegexConsts.Email.IsMatch(EmailField.Text))
        {
            EmailField.IsError = true;
            EmailField.SupportingText = "It is not a valid E-mail! stupid bot ha ha. bip bop.";
            return;
        }

        var newUser = new RegistrationDTO(UserNameField.Text,
            EmailField.Text,
            PasswordField.Text,
            DeviceInfo.Name,
            "device id)))",
            DeviceInfo.DeviceType.ToString(),
            DeviceInfo.Platform.ToString(),
            DeviceInfo.VersionString,
            "0.0.0.0.10.01",
            "extra early build");

        using (var http = new HttpClient())
        {
            var respons = await http.PostAsync($"https://1ce8-194-44-167-129.ngrok-free.app/api/Account/register", new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json"));

            if (respons.IsSuccessStatusCode)
            {
                DebugLabel.Text = newUser.ToString();

                EmailPanel.IsVisible = false;
                LastPanel.IsVisible = true;
                
                return;
            }

            //respons.Content
        }
    }

    private void EndRegistration(object sender, SkiaSharp.Views.Maui.SKTouchEventArgs e)
    {

    }
}