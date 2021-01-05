using SimpleViewModels.Commands;
using SimpleViewModels.Services;
using SimpleViewModels.ViewModels;
using System;
using System.Windows;

namespace SimpleViewModels
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            PriceService priceService = new PriceService();

            int currentMinute = 10;

            CreateCommand<BuyViewModel> createCalculatePriceCommand;
            CreateCommand<BuyViewModel> createBuyCommand;

            if (currentMinute % 2 == 1)
            {
                createCalculatePriceCommand = (vm) => new CalculatePriceCommand(vm, priceService);
                createBuyCommand = (vm) => new BuyCommand(vm, priceService);
            }
            else
            {
                CreateCommand<BuyViewModel> createStoreClosedCommand = (vm) => new StoreClosedCommand(vm);

                createCalculatePriceCommand = createStoreClosedCommand;
                createBuyCommand = createStoreClosedCommand;
            }

            BuyViewModel initialViewModel = new BuyViewModel(createCalculatePriceCommand, createBuyCommand);

            MainWindow = new MainWindow()
            {
                DataContext = initialViewModel
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
