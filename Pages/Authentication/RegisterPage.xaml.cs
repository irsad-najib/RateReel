using Microsoft.Maui.Controls;
using System;

namespace RateReel.Pages.Authentication
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            try
            {
                string username = UsernameEntry?.Text?.Trim() ?? string.Empty;
                string password = PasswordEntry?.Text?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Error", "Please enter both username and password.", "OK");
                    return;
                }

                // Simple registration logic - replace with actual registration
                await DisplayAlert("Success", "Registration successful!", "OK");
                await Shell.Current.GoToAsync("//Login");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Registration error: {ex.Message}");
                await DisplayAlert("Error", "An error occurred during registration.", "OK");
            }
        }
    }
}