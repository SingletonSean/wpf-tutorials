using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Stores
{
    public interface INavigationStore
    {
        ViewModelBase CurrentViewModel { set; }
    }
}