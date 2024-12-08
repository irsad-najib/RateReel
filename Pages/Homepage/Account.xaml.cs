using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace RateReel.Pages.Homepage
{
    public partial class Account : ContentPage, INotifyPropertyChanged
    {
        private string username = "admin"; // Match login credentials
        private int reviewCount = 0;
        private int filmsCount = 0;

        public string Username
        {
            get => username;
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ReviewCount
        {
            get => reviewCount;
            set
            {
                if (reviewCount != value)
                {
                    reviewCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public int FilmsCount
        {
            get => filmsCount;
            set
            {
                if (filmsCount != value)
                {
                    filmsCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public Account()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void OnEditProfileClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Edit Profile", "Edit Profile functionality coming soon", "OK");
        }

        private async void OnBackToHomeClicked(object sender, EventArgs e)
{
    try
    {
        System.Diagnostics.Debug.WriteLine("Attempting navigation to Home...");
        await Shell.Current.GoToAsync($"///Home");
        System.Diagnostics.Debug.WriteLine("Navigation successful");
    }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
        await DisplayAlert("Error", "Could not navigate to Home", "OK");
    }
}

        private async void OnSignOutClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Sign Out", "Are you sure you want to sign out?", "Yes", "No");
            if (answer)
            {
                try
                {
                    // Navigate back to login page
                     Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
                    Shell.SetNavBarIsVisible(Shell.Current, false);
                    Shell.SetTabBarIsVisible(Shell.Current, false);
                  
                  await Shell.Current.GoToAsync("//Login");
                    
                    // Hide navigation and tab bars
                    Shell.SetNavBarIsVisible(Shell.Current, false);
                    Shell.SetTabBarIsVisible(Shell.Current, false);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Sign out error: {ex}");
                    await DisplayAlert("Error", "Could not sign out", "OK");
                }
            }
        }

        // INotifyPropertyChanged implementation
        public new event PropertyChangedEventHandler? PropertyChanged;

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            base.OnPropertyChanged(propertyName);
        }
    }
}