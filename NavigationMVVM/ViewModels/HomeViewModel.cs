using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my application.";

        public NavigationBarViewModel NavigationBarViewModel { get; }

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(NavigationBarViewModel navigationBarViewModel, NavigationService<LoginViewModel> loginNavigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;

            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }
}
