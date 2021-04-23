using StateMVVM.Services;
using StateMVVM.Services.Navigations;
using StateMVVM.Stores;
using StateMVVM.ViewModels;
using StateMVVM.ViewModels.Posts;
using System.Windows;

namespace StateMVVM
{
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly PostStore _postStore;
        private readonly MessageStore _messageStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            _postStore = new PostStore(new PostService());
            _messageStore = new MessageStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService navigationService = CreatePostHomeNavigationService();

            navigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private PostHomeViewModel CreatePostHomeViewModel()
        {
            return new PostHomeViewModel(
                new CreatePostViewModel(_postStore, _messageStore),
                RecentPostListingViewModel.LoadViewModel(_postStore, _messageStore));
        }

        private PostListingViewModel CreatePostListingViewModel()
        {
            return PostListingViewModel.LoadViewModel(_postStore, _messageStore);
        }

        private INavigationService CreatePostHomeNavigationService()
        {
            return new LayoutNavigationService<PostHomeViewModel>(_navigationStore,
                CreatePostHomeViewModel,
                CreateGlobalMessageViewModel,
                CreateNavigationBarViewModel);
        }

        private INavigationService CreatePostListingNavigationService()
        {
            return new LayoutNavigationService<PostListingViewModel>(_navigationStore,
                CreatePostListingViewModel,
                CreateGlobalMessageViewModel,
                CreateNavigationBarViewModel);
        }

        private NavigationBarViewModel CreateNavigationBarViewModel()
        {
            return new NavigationBarViewModel(
                CreatePostHomeNavigationService(),
                CreatePostListingNavigationService());
        }

        private GlobalMessageViewModel CreateGlobalMessageViewModel()
        {
            return new GlobalMessageViewModel(_messageStore);
        }
    }
}
