using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using ValidationMVVM.ViewModels;

namespace ValidationMVVM.Commands
{
    public class CreateProductCommand : ICommand
    {
        private readonly CreateProductViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public CreateProductCommand(CreateProductViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            MessageBox.Show($"Successfully created '{_viewModel.Name}' for {_viewModel.Price:C}.");
        }
    }
}
