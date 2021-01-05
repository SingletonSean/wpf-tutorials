using SimpleViewModels.Exceptions;
using SimpleViewModels.Services;
using SimpleViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleViewModels.Commands
{
    public class CalculatePriceCommand : BaseCommand
    {
        private readonly BuyViewModel _viewModel;
        private readonly PriceService _priceService;

        public CalculatePriceCommand(BuyViewModel viewModel, PriceService priceService)
        {
            _viewModel = viewModel;
            _priceService = priceService;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.CanCalculatePrice;
        }

        public override void Execute(object parameter)
        {
            _viewModel.ClearMessages();

            try
            {
                double price = _priceService.GetPrice(_viewModel.ItemName);
                double totalPrice = price * _viewModel.Quantity;

                _viewModel.StatusMessage = $"The total price of {_viewModel.Quantity} {_viewModel.ItemName} is {totalPrice:C}.";
            }
            catch (ItemPriceNotFoundException)
            {
                _viewModel.ErrorMessage = $"Failed to calculate price. Unable to find price of {_viewModel.ItemName}.";
            }
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BuyViewModel.CanCalculatePrice))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
