using DragDropDemo.ViewModels;
using MVVMEssentials.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DragDropDemo.Commands
{
    public class SaveRectangleCommand : CommandBase
    {
        private readonly CanvasViewModel _canvasViewModel;

        public SaveRectangleCommand(CanvasViewModel canvasViewModel)
        {
            _canvasViewModel = canvasViewModel;
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show($"Successfully saved the rectangle to position {_canvasViewModel.X}, {_canvasViewModel.Y}.");
        }
    }
}
