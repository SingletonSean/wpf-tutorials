using MVVMEssentials.Commands;
using StateMVVM.ViewModels;
using StateMVVM.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace StateMVVM.Commands
{
    public class CreatePostCommand : CommandBase
    {
        private readonly CreatePostViewModel _viewModel;

        public CreatePostCommand(CreatePostViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show("Successfully created post.", "Success", 
                MessageBoxButton.OK, MessageBoxImage.Information);

            _viewModel.Title = string.Empty;
            _viewModel.Content = string.Empty;
        }
    }
}
