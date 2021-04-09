using CustomObservableCollections.ViewModels;
using MVVMEssentials.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomObservableCollections.Commands
{
    public class GiveOrderCommand : CommandBase
    {
        private readonly DriveThruViewModel _viewModel;

        public GiveOrderCommand(DriveThruViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.GiveOrderToCustomer();
        }
    }
}
