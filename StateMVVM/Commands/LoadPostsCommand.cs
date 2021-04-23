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
        private readonly MessageStore _messageStore;

        public LoadPostsCommand(PostStore postStore, MessageStore messageStore)
        {
            _postStore = postStore;
            _messageStore = messageStore;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try 
            { 
                await _postStore.LoadPosts();
            }
            catch (Exception)
            {
                _messageStore.SetCurrentMessage("Failed to load posts.", MessageType.Error);
            }
        }
    }
}
