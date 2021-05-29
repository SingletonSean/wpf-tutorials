using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using System;
using System.Windows;
using WPFMVVMTemplate.ViewModels;

namespace WPFMVVMTemplate
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<AboutViewModel>(CreateAboutViewModel);
                    services.AddSingleton<CreateViewModel<AboutViewModel>>(s => () => s.GetRequiredService<AboutViewModel>());
                    services.AddSingleton<NavigationService<AboutViewModel>>(CreateAboutNavigationService);

                    services.AddTransient<HomeViewModel>(CreateHomeViewModel);
                    services.AddSingleton<CreateViewModel<HomeViewModel>>(s => () => s.GetRequiredService<HomeViewModel>());
                    services.AddSingleton<NavigationService<HomeViewModel>>(CreateHomeNavigationService);

                    services.AddSingleton<CloseModalNavigationService>();

                    services.AddSingleton<NavigationStore>();
                    services.AddSingleton<ModalNavigationStore>();

                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            INavigationService navigationService = _host.Services.GetRequiredService<NavigationService<HomeViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }

        private AboutViewModel CreateAboutViewModel(IServiceProvider services)
        {
            return new AboutViewModel(
                services.GetRequiredService<CloseModalNavigationService>());
        }

        private NavigationService<AboutViewModel> CreateAboutNavigationService(IServiceProvider services)
        {
            return new NavigationService<AboutViewModel>(
                services.GetRequiredService<ModalNavigationStore>(),
                services.GetRequiredService<CreateViewModel<AboutViewModel>>());
        }

        private HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel(
                services.GetRequiredService<NavigationService<AboutViewModel>>());
        }

        private NavigationService<HomeViewModel> CreateHomeNavigationService(IServiceProvider services)
        {
            return new NavigationService<HomeViewModel>(
                services.GetRequiredService<NavigationStore>(),
                services.GetRequiredService<CreateViewModel<HomeViewModel>>());
        }
    }
}
