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
            CreateProductViewModel createProductViewModel = new CreateProductViewModel();
            ProductListingViewModel productListingViewModel = new ProductListingViewModel();
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
