using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionViewMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public EmployeeListingViewModel EmployeeListingViewModel { get; }

        public MainViewModel()
        {
            EmployeeListingViewModel = new EmployeeListingViewModel();
        }
    }
}
