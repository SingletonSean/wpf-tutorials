using DragDropDemo.ViewModels;
using MVVMEssentials.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragDropDemo.Commands
{
    public class TodoItemInsertedCommand : CommandBase
    {
        private readonly TodoItemListingViewModel _viewModel;

        public TodoItemInsertedCommand(TodoItemListingViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.InsertTodoItem(_viewModel.InsertedTodoItemViewModel, _viewModel.TargetTodoItemViewModel);
        }
    }
}
