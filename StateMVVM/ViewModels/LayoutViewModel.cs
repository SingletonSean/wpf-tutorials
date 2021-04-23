using MVVMEssentials.ViewModels;

namespace StateMVVM.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }
        public GlobalMessageViewModel GlobalMessageViewModel { get; }
        public ViewModelBase ContentViewModel { get; }

        public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, 
            GlobalMessageViewModel globalMessageViewModel, 
            ViewModelBase contentViewModel)
        {
            NavigationBarViewModel = navigationBarViewModel;
            GlobalMessageViewModel = globalMessageViewModel;
            ContentViewModel = contentViewModel;
        }

        public override void Dispose()
        {
            NavigationBarViewModel.Dispose();
            GlobalMessageViewModel.Dispose();
            ContentViewModel.Dispose();

            base.Dispose();
        }
    }
}
