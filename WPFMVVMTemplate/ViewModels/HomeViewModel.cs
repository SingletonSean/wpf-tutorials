using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using System.Windows.Input;

namespace WPFMVVMTemplate.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to the WPF MVVM Template!";

        public ICommand NavigateAboutCommand { get; }

        public HomeViewModel(INavigationService aboutNavigationService)
        {
            NavigateAboutCommand = new NavigateCommand(aboutNavigationService);
        }
    }
}
