using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public IPAddressViewModel IPAddressViewModel { get; set; }

        public MainViewModel()
        {
            IPAddressViewModel = new IPAddressViewModel();
        }
    }
}
