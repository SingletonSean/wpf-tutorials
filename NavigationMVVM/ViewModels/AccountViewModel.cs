using NavigationMVVM.Commands;
using NavigationMVVM.Models;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public string Username => _accountStore.CurrentAccount?.Username;
        public string Email => _accountStore.CurrentAccount?.Email;

        public NavigationBarViewModel NavigationBarViewModel { get; }

        public ICommand NavigateHomeCommand { get; }

        public AccountViewModel(NavigationBarViewModel navigationBarViewModel, AccountStore accountStore, NavigationService<HomeViewModel> homeNavigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;
            _accountStore = accountStore;

            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        }
    }
}
