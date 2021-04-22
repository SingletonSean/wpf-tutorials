using MVVMEssentials.Commands;
using StateMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StateMVVM.Commands
{
    public class LoadPostsCommand : AsyncCommandBase
    {
        private readonly PostStore _postStore;

        public LoadPostsCommand(PostStore postStore)
        {
            _postStore = postStore;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try 
            { 
                await _postStore.LoadPosts();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load posts.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
