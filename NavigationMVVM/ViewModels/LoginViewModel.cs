﻿using NavigationMVVM.Commands;
using NavigationMVVM.Models;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(NavigationStore navigationStore)
        {
            ParameterNavigationService<Account, AccountViewModel> navigationService = new ParameterNavigationService<Account, AccountViewModel>(
                navigationStore,
                (account) => new AccountViewModel(account, navigationStore));

            LoginCommand = new LoginCommand(this, navigationService);
        }
    }
}
