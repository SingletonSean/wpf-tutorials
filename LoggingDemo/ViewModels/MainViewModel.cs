using LoggingDemo.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LoggingDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand MakeSandwichCommand { get; }

        public MainViewModel(ICommand makeSandwichCommand)
        {
            MakeSandwichCommand = makeSandwichCommand;
        }
    }
}
