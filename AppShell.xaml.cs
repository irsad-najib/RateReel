using Microsoft.Maui.Controls;
using RateReel.Pages.Authentication;
using RateReel.Pages.Homepage;
using RateReel.Services;
using Backend.Configuration;
using Microsoft.Extensions.Options;

namespace RateReel
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("Starting initial navigation...");

                    FlyoutBehavior = FlyoutBehavior.Disabled;
                    Shell.SetNavBarIsVisible(Shell.Current, false);
                    Shell.SetTabBarIsVisible(Shell.Current, false);

                    await Shell.Current.GoToAsync("//Login");
                    System.Diagnostics.Debug.WriteLine("Navigated to Login page");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
                    System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                }
            });
        }

        private void RegisterRoutes()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Registering routes...");

                Routing.RegisterRoute("Login", typeof(LoginPage));
                Routing.RegisterRoute("Register", typeof(RegisterPage));
                Routing.RegisterRoute("Home", typeof(Homepage));
                Routing.RegisterRoute("Timeline", typeof(Timeline));
                Routing.RegisterRoute("Films", typeof(Films));
                Routing.RegisterRoute("Settings", typeof(Settings));
                Routing.RegisterRoute("Account", typeof(Account));


                System.Diagnostics.Debug.WriteLine("Routes registered successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Route registration error: {ex.Message}");
            }
        }
    }
}