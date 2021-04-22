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
    public class PostListingViewModel : ViewModelBase
    {
        private readonly PostStore _postStore;
        private readonly ObservableCollection<PostViewModel> _posts;

        public IEnumerable<PostViewModel> Posts => _posts;

        public bool HasPosts => _posts.Count > 0;

        public ICommand LoadPostsCommand { get; }

        public PostListingViewModel(PostStore postStore)
        {
            _postStore = postStore;

            _posts = new ObservableCollection<PostViewModel>();
            _posts.CollectionChanged += Posts_CollectionChanged;

            _postStore.PostCreated += PostStore_PostCreated;
            _postStore.PostsLoaded += UpdatePosts;

            LoadPostsCommand = new LoadPostsCommand(_postStore);
        }

        public static PostListingViewModel LoadViewModel(PostStore postStore)
        {
            PostListingViewModel viewModel = new PostListingViewModel(postStore);

            viewModel.LoadPostsCommand.Execute(null);

            return viewModel;
        }

        public override void Dispose()
        {
            _postStore.PostCreated -= PostStore_PostCreated;
            _postStore.PostsLoaded -= UpdatePosts;
            base.Dispose();
        }

        private void PostStore_PostCreated(Post post)
        {
            PostViewModel postViewModel = new PostViewModel(post);
            _posts.Insert(0, postViewModel);
        }

        private void UpdatePosts()
        {
            _posts.Clear();

            foreach (Post post in _postStore.Posts
                .OrderByDescending(p => p.DateCreated))
            {
                PostViewModel postViewModel = new PostViewModel(post);
                _posts.Add(postViewModel);
            }
        }

        private void Posts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(HasPosts));        
        }
    }
}
