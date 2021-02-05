using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMEssentials.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;
}
