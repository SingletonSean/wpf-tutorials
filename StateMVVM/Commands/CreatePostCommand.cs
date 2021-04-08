using MVVMEssentials.Commands;
using StateMVVM.Models;
using StateMVVM.Stores;
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
        private readonly PostStore _postStore;

        public CreatePostCommand(CreatePostViewModel viewModel, PostStore postStore)
        {
            _viewModel = viewModel;
            _postStore = postStore;
        }

        public override void Execute(object parameter)
        {
            Post post = new Post()
            {
                Title = _viewModel.Title,
                Content = _viewModel.Content,
                DateCreated = DateTime.Now
            };
            _postStore.CreatePost(post);

            MessageBox.Show("Successfully created post.", "Success", 
                MessageBoxButton.OK, MessageBoxImage.Information);

            _viewModel.Title = string.Empty;
            _viewModel.Content = string.Empty;
        }
    }
}
