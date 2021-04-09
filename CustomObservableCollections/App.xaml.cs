using CustomObservableCollections.ViewModels;
using System.Windows;

namespace CustomObservableCollections
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new DriveThruViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
