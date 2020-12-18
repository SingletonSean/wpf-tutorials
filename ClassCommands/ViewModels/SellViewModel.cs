using ClassCommands.Commands;
using ClassCommands.Exceptions;
using ClassCommands.Services;
using ClassCommands.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ClassCommands.ViewModels
{
    public class SellViewModel : ViewModelBase
    {
        private readonly IOwnedItemsStore _ownedItemsStore;
        private readonly IPriceService _priceService;

        public IEnumerable<string> SellableItems => _ownedItemsStore.OwnedItems.Select(i => i.Name);

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
                OnPropertyChanged(nameof(IsValidSell));
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
                OnPropertyChanged(nameof(IsValidSell));
                OnPropertyChanged(nameof(CanCalculatePrice));
            }
        }

        public bool IsValidSell => !string.IsNullOrEmpty(ItemName) && Quantity > 0;
        public bool CanCalculatePrice => IsValidSell;

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
                OnPropertyChanged(nameof(_errorMessage));
            }
        }

        public ICommand CalculatePriceCommand { get; }
        public ICommand SellCommand { get; }

        public SellViewModel(IOwnedItemsStore ownedItemsStore, IPriceService priceService)
        {
            _ownedItemsStore = ownedItemsStore;
            _priceService = priceService;

            CalculatePriceCommand = new CallbackCommand(CalculatePrice, () => CanCalculatePrice);
            SellCommand = new CallbackCommand(Sell, () => IsValidSell);

            _ownedItemsStore.OwnedItemsChanged += OwnedItemsStore_OwnedItemsChanged;
        }

        private void CalculatePrice()
        {
            StatusMessage = string.Empty;
            ErrorMessage = string.Empty;

            try
            {
                double itemPrice = _priceService.GetPrice(ItemName);
                double totalPrice = itemPrice * Quantity;

                StatusMessage = $"The total price of { Quantity} { ItemName} is {totalPrice:C}.";
            }
            catch (ItemPriceNotFoundException)
            {
                ErrorMessage = $"Unable to find price of { ItemName}.";
            }
        }

        private void Sell()
        {
            StatusMessage = string.Empty;
            ErrorMessage = string.Empty;

            string sellItemName = ItemName;
            _ownedItemsStore.Sell(sellItemName, Quantity);

            StatusMessage = $"Successfully sold {Quantity} {sellItemName}.";
        }

        private void OwnedItemsStore_OwnedItemsChanged()
        {
            OnPropertyChanged(nameof(SellableItems));
        }
    }
}
