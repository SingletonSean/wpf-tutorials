using NavigationMVVM.Commands;
using NavigationMVVM.Models;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly Account _account;

        public string Username => _account?.Username;
        public string Email => _account?.Email;

        public ICommand NavigateHomeCommand { get; }

        public AccountViewModel(Account account, NavigationStore navigationStore)
        {
            _account = account;

            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(
                navigationStore, () => new HomeViewModel(navigationStore)));
        }
    }
}
