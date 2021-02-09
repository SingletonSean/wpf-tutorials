using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationMVVM.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly NavigationBarViewModel _navigationBarViewModel;

        public LayoutNavigationService(NavigationStore navigationStore, 
            Func<TViewModel> createViewModel, 
            NavigationBarViewModel navigationBarViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _navigationBarViewModel = navigationBarViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(_navigationBarViewModel, _createViewModel());
        }
    }
}
