using DragDropDemo.ViewModels;
using MVVMEssentials.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragDropDemo.Commands
{
    public class TodoItemReceivedCommand : CommandBase
    {
        private readonly TodoItemListingViewModel _todoItemListingViewModel;

        public TodoItemReceivedCommand(TodoItemListingViewModel todoItemListingViewModel)
        {
            _todoItemListingViewModel = todoItemListingViewModel;
        }

        public override void Execute(object parameter)
        {
            _todoItemListingViewModel.AddTodoItem(_todoItemListingViewModel.IncomingTodoItemViewModel);
        }
    }
}
