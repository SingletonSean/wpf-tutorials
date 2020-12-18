using ClassCommands.Commands;
using ClassCommands.Exceptions;
using ClassCommands.Services;
using ClassCommands.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ClassCommands.ViewModels
{
    public class BuyViewModel : ViewModelBase, ICalculatePriceViewModel
    {
        public IEnumerable<string> BuyableItems { get; }

        private string _itemName;
        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
                OnPropertyChanged(nameof(ItemName));
                OnPropertyChanged(nameof(IsValidBuy));
                OnPropertyChanged(nameof(CanCalculatePrice));
            }
        }

        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(IsValidBuy));
                OnPropertyChanged(nameof(CanCalculatePrice));
            }
        }

        public bool IsValidBuy => !string.IsNullOrEmpty(ItemName) && Quantity > 0;
        public bool CanCalculatePrice => IsValidBuy;

        private string _statusMessage;
        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand CalculatePriceCommand { get; }
        public ICommand BuyCommand { get; }

        public BuyViewModel(IOwnedItemsStore ownedItemsStore, IPriceService priceService)
        {
            BuyableItems = new ObservableCollection<string>
            {
                "apple",
                "shirt",
                "phone",
                "burrito",
                "pillow"
            };

            CalculatePriceCommand = new CalculatePriceCommand(this, priceService);
            BuyCommand = new BuyCommand(this, ownedItemsStore);
        }
    }
}
