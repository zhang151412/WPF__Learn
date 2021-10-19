using Domain.Repository;
using InfraSQLite;
using InfraSQLite.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.DItest;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private ServiceProvider serviceProvider { get; }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITextService>(provider => new TextService("Hi WPF .NET Core 3.0"));
            services.AddSingleton<MainWindow>();
            services.AddDbContext<AppDbContext>();
            services.AddScoped(typeof(IRepository<,>), typeof(RepositoryBase<,>));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var main = serviceProvider.GetRequiredService<MainWindow>();
            main.Show();
        }

    }



}
