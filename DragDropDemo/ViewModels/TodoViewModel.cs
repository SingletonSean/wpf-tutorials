using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragDropDemo.ViewModels
{
    public class TodoViewModel : ViewModelBase
    {
        public TodoItemListingViewModel InProgressTodoItemListingViewModel { get; }
        public TodoItemListingViewModel CompletedTodoItemListingViewModel { get; }

        public TodoViewModel(TodoItemListingViewModel inProgressTodoItemListingViewModel, TodoItemListingViewModel completedTodoItemListingViewModel)
        {
            InProgressTodoItemListingViewModel = inProgressTodoItemListingViewModel;
            CompletedTodoItemListingViewModel = completedTodoItemListingViewModel;
        }
    }
}
