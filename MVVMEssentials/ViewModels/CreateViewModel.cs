namespace MVVMEssentials.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;

    public delegate TViewModel CreateViewModel<TParameter, TViewModel>(TParameter parameter) where TViewModel : ViewModelBase;
}
