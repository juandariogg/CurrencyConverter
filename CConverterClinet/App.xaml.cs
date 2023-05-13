using CConverterClient.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.Xml;
using System.Threading;
using System.Windows;

namespace CConverterClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            
            SetDecimalSeparator(Configuration);

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddViewModels();
            serviceCollection.AddScoped<APIConsumer>();
            serviceCollection.Configure<APIConsumer>(x =>
            {
                var host = Configuration.GetSection("ApplicationSettings").GetValue<string>("APIHost") ?? "";
                var converterEndpoint = Configuration.GetSection("ApplicationSettings").GetValue<string>("ConvertEndpoint") ?? "";
                x.Configure(host, converterEndpoint);
            });

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void SetDecimalSeparator(IConfiguration config)
        {
            var appsetting = config.GetSection("ApplicationSettings");
            var c = appsetting.GetValue<string>("DecimalSeparator");

            string CultureName = Thread.CurrentThread.CurrentCulture.Name;
            CultureInfo ci = new CultureInfo(CultureName);
            if (ci.NumberFormat.NumberDecimalSeparator != c)
            {
                // Forcing use of decimal separator for numerical values
                ci.NumberFormat.CurrencyDecimalSeparator = c;
                Thread.CurrentThread.CurrentCulture = ci;
            }
        }
    }
}
