using NavigationMVVM.ViewModels;

namespace NavigationMVVM.Services
{
    public interface INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        void Navigate();
    }
}