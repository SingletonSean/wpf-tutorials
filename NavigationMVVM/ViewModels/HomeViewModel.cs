using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my application.";

        public ICommand NavigateAccountCommand { get; }
    }
}
