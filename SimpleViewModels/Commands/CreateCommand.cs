using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleViewModels.Commands
{
    public delegate ICommand CreateCommand<TViewModel>(TViewModel viewModel);
}
