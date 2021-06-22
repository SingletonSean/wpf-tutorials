using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public enum View
    {
        Home,
        Account,
        PeopleListing,
        Unknown
    }

    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        private readonly View _activeView;

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigatePeopleListingCommand { get; }
        public ICommand LogoutCommand { get; }

        public bool IsHomeActive => _activeView == View.Home;
        public bool IsAccountActive => _activeView == View.Account;
        public bool IsPeopleListingActive => _activeView == View.PeopleListing;

        public bool IsLoggedIn => _accountStore.IsLoggedIn;

        public NavigationBarViewModel(AccountStore accountStore,
            INavigationService homeNavigationService,
            INavigationService accountNavigationService,
            INavigationService loginNavigationService,
            INavigationService peopleListingNavigationService,
            View activeView = View.Unknown)
        {
            _accountStore = accountStore;
            _activeView = activeView;
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
            NavigatePeopleListingCommand = new NavigateCommand(peopleListingNavigationService);
            LogoutCommand = new LogoutCommand(_accountStore);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
