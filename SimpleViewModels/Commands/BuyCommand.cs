using SimpleViewModels.Exceptions;
using SimpleViewModels.Services;
using SimpleViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleViewModels.Commands
{
    public class BuyCommand : BaseCommand
    {
        private readonly BuyViewModel _viewModel;
        private readonly PriceService _priceService;

        public BuyCommand(BuyViewModel viewModel, PriceService priceService)
        {
            _viewModel = viewModel;
            _priceService = priceService;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.IsValidBuy;
        }

        public override void Execute(object parameter)
        {
            _viewModel.ClearMessages();

            try
            {
                double price = _priceService.GetPrice(_viewModel.ItemName);
                double totalPrice = price * _viewModel.Quantity;

                _viewModel.StatusMessage = $"Successfully bought {_viewModel.Quantity} {_viewModel.ItemName} for {totalPrice:C}.";
            }
            catch (ItemPriceNotFoundException)
            {
                _viewModel.ErrorMessage = $"Failed to buy item. Unable to find price of {_viewModel.ItemName}.";
            }
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BuyViewModel.IsValidBuy))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
