using CommunicationMVVM.Commands;
using CommunicationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CommunicationMVVM.ViewModels
{
    public class CreateProductViewModel : ViewModelBase
    {
        private string _productName;
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private double _productPrice;
        public double ProductPrice
        {
            get
            {
                return _productPrice;
            }
            set
            {
                _productPrice = value;
                OnPropertyChanged(nameof(ProductPrice));
            }
        }

        private int _productQuantity;
        public int ProductQuantity
        {
            get
            {
                return _productQuantity;
            }
            set
            {
                _productQuantity = value;
                OnPropertyChanged(nameof(ProductQuantity));
            }
        }

        public ICommand CreateProductCommand { get; }

        public CreateProductViewModel(ProductStore productStore)
        {
            CreateProductCommand = new CreateProductCommand(this, productStore);
        }
    }
}
