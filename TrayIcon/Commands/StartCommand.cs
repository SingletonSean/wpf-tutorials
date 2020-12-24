using System;
using System.Collections.Generic;
using System.Text;
using TrayIcon.Stores;
using TrayIcon.ViewModels;

namespace TrayIcon.Commands
{
    public class StartCommand : BaseCommand
    {
        private readonly TimerViewModel _viewModel;
        private readonly TimerStore _timerStore;

        public StartCommand(TimerViewModel viewModel, TimerStore timerStore)
        {
            _viewModel = viewModel;
            _timerStore = timerStore;
        }

        public override void Execute(object parameter)
        {
            _timerStore.Start(_viewModel.Duration);
        }
    }
}
