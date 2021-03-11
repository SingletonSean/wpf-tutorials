using DragDropDemo.ViewModels;
using MVVMEssentials.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DragDropDemo.Commands
{
    public class DeleteRectangleCommand : CommandBase
    {
        private readonly CanvasViewModel _canvasViewModel;

        public DeleteRectangleCommand(CanvasViewModel canvasViewModel)
        {
            _canvasViewModel = canvasViewModel;
        }

        public override void Execute(object parameter)
        {
            //MessageBox.Show(_canvasViewModel.RemoveRectangleName);
        }
    }
}
