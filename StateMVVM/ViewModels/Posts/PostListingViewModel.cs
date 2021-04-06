using MVVMEssentials.ViewModels;
using StateMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace StateMVVM.ViewModels.Posts
{
    public class PostListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<PostViewModel> _posts;

        public IEnumerable<PostViewModel> Posts => _posts;

        public bool HasPosts => _posts.Count > 0;

        public PostListingViewModel()
        {
            _posts = new ObservableCollection<PostViewModel>();
            _posts.CollectionChanged += Posts_CollectionChanged;
        }

        private void Posts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(HasPosts));        
        }
    }
}
