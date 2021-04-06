using MVVMEssentials.Commands;
using StateMVVM.Services;
using StateMVVM.Services.Navigations;
using StateMVVM.Stores;
using StateMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateMVVM.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService _navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
