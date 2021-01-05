using SimpleViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleViewModels.Commands
{
    public class StoreClosedCommand : BaseCommand
    {
        private readonly BuyViewModel _viewModel;

        public StoreClosedCommand(BuyViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.ErrorMessage = "The store is currently closed.";
        }
    }
}
