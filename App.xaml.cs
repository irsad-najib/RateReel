using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using RateReel.Models;
using RateReel.Services;
using System.Net.Http;

namespace RateReel
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static ObservableCollection<Review> Reviews { get; set; } = new ObservableCollection<Review>();

        public App()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            MainPage = new AppShell();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new HttpClient());
            services.AddSingleton<TmdbService>();
        }
    }
}