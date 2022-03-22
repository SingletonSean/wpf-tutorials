using DashboardMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DashboardMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            { 
                DataContext = new DashboardViewModel(
                    new ProfitViewModel(),
                    new CostsViewModel(),
                    new RevenueViewModel(),
                    new RecentSalesViewModel())
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
