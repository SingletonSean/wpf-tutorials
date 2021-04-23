using MVVMEssentials.ViewModels;
using StateMVVM.Commands;
using StateMVVM.Models;
using StateMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StateMVVM.ViewModels.Posts
{
    public class RecentPostListingViewModel : ViewModelBase
    {
        private readonly PostStore _postStore;
        private readonly ObservableCollection<PostViewModel> _posts;

        public IEnumerable<PostViewModel> Posts => _posts;

        public bool HasPosts => _posts.Count > 0;

        public ICommand LoadPostsCommand { get; }

        public RecentPostListingViewModel(PostStore postStore, MessageStore messageStore)
        {
            _postStore = postStore;

            _posts = new ObservableCollection<PostViewModel>();
            _posts.CollectionChanged += Posts_CollectionChanged;

            _postStore.PostCreated += PostStore_PostCreated;
            _postStore.PostsLoaded += UpdatePosts;

            LoadPostsCommand = new LoadPostsCommand(_postStore, messageStore);
        }

        public static RecentPostListingViewModel LoadViewModel(PostStore postStore, MessageStore messageStore)
        {
            RecentPostListingViewModel viewModel = new RecentPostListingViewModel(postStore, messageStore);

            viewModel.LoadPostsCommand.Execute(null);

            return viewModel;
        }

        public override void Dispose()
        {
            _postStore.PostCreated -= PostStore_PostCreated;
            _postStore.PostsLoaded -= UpdatePosts;
            base.Dispose();
        }

        private void UpdatePosts()
        {
            _posts.Clear();

            foreach (Post post in _postStore.Posts
                .OrderByDescending(p => p.DateCreated)
                .Take(5))
            {
                PostViewModel postViewModel = new PostViewModel(post);
                _posts.Add(postViewModel);
            }
        }

        private void PostStore_PostCreated(Post post)
        {
            PostViewModel postViewModel = new PostViewModel(post);
            _posts.Insert(0, postViewModel);

            if(_posts.Count > 5)
            {
                _posts.RemoveAt(5);
            }
        }

        private void Posts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(HasPosts));        
        }
    }
}
