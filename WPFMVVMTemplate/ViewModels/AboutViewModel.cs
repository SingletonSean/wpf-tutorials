using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using System.Windows.Input;

namespace WPFMVVMTemplate.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public string Author => "SingletonSean";

        public ICommand CloseCommand { get; }

        public AboutViewModel(INavigationService closeModalNavigationService)
        {
            CloseCommand = new NavigateCommand(closeModalNavigationService);
        }
    }
}
