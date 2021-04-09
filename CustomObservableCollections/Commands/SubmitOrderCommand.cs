using CustomObservableCollections.ViewModels;
using MVVMEssentials.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomObservableCollections.Commands
{
    public class SubmitOrderCommand : CommandBase
    {
        private static int UNIQUE_ORDER_ID = 1;

        private readonly DriveThruViewModel _viewModel;

        public SubmitOrderCommand(DriveThruViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            OrderViewModel order = new OrderViewModel(UNIQUE_ORDER_ID++, 
                _viewModel.SelectedItem, 
                DateTime.Now);

            _viewModel.SubmitOrder(order);
        }
    }
}
