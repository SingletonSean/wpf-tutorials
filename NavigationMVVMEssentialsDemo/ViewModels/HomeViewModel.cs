using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NavigationMVVMEssentialsDemo.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateAccountCommand { get; }

        public HomeViewModel(INavigationService accountNavigationService)
        {
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
        }
    }
}
