using CommunicationMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CommunicationMVVM.ViewModels
{
    public class ProductListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ProductViewModel> _products;

        public IEnumerable<ProductViewModel> Products => _products;
        public bool HasProducts => _products.Count > 0;
        public bool HasNoProducts => !HasProducts;

        public ProductListingViewModel()
        {
            _products = new ObservableCollection<ProductViewModel>();

            _products.Add(new ProductViewModel(new Product() 
            {
               Name = "T-Shirt", 
               Price = 49.99, 
               Quantity = 3
            }));
        }
    }
}
