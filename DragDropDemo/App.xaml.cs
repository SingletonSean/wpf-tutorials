using DragDropDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DragDropDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            TodoItemListingViewModel inProgressTodoItemListingViewModel = new TodoItemListingViewModel();
            inProgressTodoItemListingViewModel.AddTodoItem(new TodoItemViewModel("Go jogging"));
            inProgressTodoItemListingViewModel.AddTodoItem(new TodoItemViewModel("Walk the dog"));
            inProgressTodoItemListingViewModel.AddTodoItem(new TodoItemViewModel("Make videos"));

            TodoItemListingViewModel completedTodoItemListingViewModel = new TodoItemListingViewModel();
            completedTodoItemListingViewModel.AddTodoItem(new TodoItemViewModel("Take a shower"));
            completedTodoItemListingViewModel.AddTodoItem(new TodoItemViewModel("Eat breakfast"));

            TodoViewModel todoViewModel = new TodoViewModel(inProgressTodoItemListingViewModel, completedTodoItemListingViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = todoViewModel
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
