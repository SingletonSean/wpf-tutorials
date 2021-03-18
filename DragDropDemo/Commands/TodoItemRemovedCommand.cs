using DragDropDemo.ViewModels;
using MVVMEssentials.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragDropDemo.Commands
{
    public class TodoItemRemovedCommand : CommandBase
    {
        private readonly TodoItemListingViewModel _todoItemListingViewModel;

        public TodoItemRemovedCommand(TodoItemListingViewModel todoItemListingViewModel)
        {
            _todoItemListingViewModel = todoItemListingViewModel;
        }

        public override void Execute(object parameter)
        {
            _todoItemListingViewModel.RemoveTodoItem(_todoItemListingViewModel.RemovedTodoItemViewModel);
        }
    }
}
