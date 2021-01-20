using CommunicationMVVM.Stores;
using CommunicationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CommunicationMVVM
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ProductStore productStore = new ProductStore();

            CreateProductViewModel createProductViewModel = new CreateProductViewModel(productStore);
            ProductListingViewModel productListingViewModel = new ProductListingViewModel(productStore);
            MainViewModel mainViewModel = new MainViewModel(createProductViewModel, productListingViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = mainViewModel
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
