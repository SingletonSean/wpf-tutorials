using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public CreateProductViewModel CreateProductViewModel { get; }
        public ProductListingViewModel ProductListingViewModel { get; }

        public MainViewModel(CreateProductViewModel createProductViewModel, ProductListingViewModel productListingViewModel)
        {
            CreateProductViewModel = createProductViewModel;
            ProductListingViewModel = productListingViewModel;
        }
    }
}
