using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Inventory_BusinessDataLogic;
using System;
using System.Windows.Forms; // Required for ApplicationConfiguration.Initialize()

namespace InventorySystemWinForms
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(configuration);

            services.Configure<Inventory_BusinessDataLogic.EmailSettings>(
                configuration.GetSection("EmailSettings") 
            );

            services.AddSingleton<EmailService>();

            
            ServiceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}