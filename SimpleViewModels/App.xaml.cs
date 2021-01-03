using SimpleViewModels.Services;
using SimpleViewModels.ViewModels;
using System.Windows;

namespace SimpleViewModels
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            PriceService priceService = new PriceService();
            BuyViewModel initialViewModel = new BuyViewModel(priceService);

            MainWindow = new MainWindow()
            {
                DataContext = initialViewModel
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
