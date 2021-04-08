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

        public App()
        {
            _navigationStore = new NavigationStore();
            _postStore = new PostStore(new PostService());
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
                new CreatePostViewModel(_postStore),
                RecentPostListingViewModel.LoadViewModel(_postStore));
        }

        private PostListingViewModel CreatePostListingViewModel()
        {
            return PostListingViewModel.LoadViewModel(_postStore);
        }

        private INavigationService CreatePostHomeNavigationService()
        {
            return new LayoutNavigationService<PostHomeViewModel>(_navigationStore,
                CreatePostHomeViewModel,
                CreateNavigationBarViewModel);
        }

        private INavigationService CreatePostListingNavigationService()
        {
            return new LayoutNavigationService<PostListingViewModel>(_navigationStore,
                CreatePostListingViewModel,
                CreateNavigationBarViewModel);
        }

        private NavigationBarViewModel CreateNavigationBarViewModel()
        {
            return new NavigationBarViewModel(
                CreatePostHomeNavigationService(),
                CreatePostListingNavigationService());
        }
    }
}
