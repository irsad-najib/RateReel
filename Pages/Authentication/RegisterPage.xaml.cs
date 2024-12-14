using Microsoft.Maui.Controls;
using RateReel.Models;
using RateReel.Services;
using System;
using System.Threading.Tasks;
using MongoDB.Driver; // Added using directive

namespace RateReel.Pages.Authentication
{
    public partial class RegisterPage : ContentPage
    {
        private readonly MongoDbContext _mongoDbContext;

        public RegisterPage()
        {
            InitializeComponent();
            _mongoDbContext = App.ServiceProvider.GetService<MongoDbContext>();
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

                var existingUser = await _mongoDbContext.Users.Find(u => u.Username == username).FirstOrDefaultAsync();
                if (existingUser != null)
                {
                    await DisplayAlert("Error", "Username already exists.", "OK");
                    return;
                }

                var hashedPassword = PasswordHasher.HashPassword(password);

                var user = new User
                {
                    Username = username,
                    Password = hashedPassword
                };

                await _mongoDbContext.Users.InsertOneAsync(user);
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