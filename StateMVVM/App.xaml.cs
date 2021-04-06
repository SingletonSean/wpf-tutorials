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

        public App()
        {
            _navigationStore = new NavigationStore();
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
                new CreatePostViewModel(),
                new RecentPostListingViewModel());
        }

        private PostListingViewModel CreatePostListingViewModel()
        {
            return new PostListingViewModel();
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
