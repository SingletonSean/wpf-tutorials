using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public CreateProductViewModel CreateProductViewModel { get; set; }

        public MainViewModel()
        {
            CreateProductViewModel = new CreateProductViewModel();
        }
    }
}
