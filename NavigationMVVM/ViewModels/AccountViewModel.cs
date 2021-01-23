using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        public string Name => "SingletonSean";

        public ICommand NavigateHomeCommand { get; }
    }
}
