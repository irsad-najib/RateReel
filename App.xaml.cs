using Microsoft.Extensions.DependencyInjection;
using RateReel.Services;
using Backend.Configuration; // Ensure this matches the intended DatabaseSettings namespace
using Microsoft.Extensions.Configuration;
using RateReel.Helper;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using RateReel.Models;
using System.Net.Http;
using System.IO;

namespace RateReel
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static string LoggedInUsername { get; set; }

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
            var builder = new ConfigurationBuilder();

            // Load appsettings.json from the Configuration folder in the app package
            using (var stream = FileSystem.OpenAppPackageFileAsync("Configuration/appsettings.json").Result)
            {
                builder.AddJsonStream(stream);
            }

            var configuration = builder.Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.Configure<Backend.Configuration.DatabaseSettings>(configuration.GetSection(nameof(Backend.Configuration.DatabaseSettings)));
            services.AddSingleton<MongoDbContext>();
            services.AddSingleton<JwtTokenGenerator>();
            services.AddSingleton(new HttpClient());
            services.AddSingleton<TmdbService>();
        }
    }
}