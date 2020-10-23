using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EventCommands.Commands
{
    public class SelectedTodoItemsChangedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
        }
    }
}
