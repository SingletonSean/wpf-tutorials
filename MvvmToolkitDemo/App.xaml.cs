using MvvmToolkitDemo.Entities.ShoppingList;
using MvvmToolkitDemo.Features.AddShoppingListItem;
using MvvmToolkitDemo.Features.ViewShoppingList;
using MvvmToolkitDemo.Pages;
using System.Windows;

namespace MvvmToolkitDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ShoppingListStore shoppingListStore = new ShoppingListStore();

            MainWindow = new MainWindow()
            {
                DataContext = new ShoppingViewModel(
                    new AddShoppingListItemViewModel(shoppingListStore), 
                    new ShoppingListViewModel()
                    {
                        IsActive = true
                    })
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
