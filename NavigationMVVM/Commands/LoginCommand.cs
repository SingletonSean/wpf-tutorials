using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NavigationMVVM.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly NavigationService<AccountViewModel> _navigationService;

        public LoginCommand(LoginViewModel viewModel, NavigationService<AccountViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show($"Logging in {_viewModel.Username}...");

            _navigationService.Navigate();
        }
    }
}
