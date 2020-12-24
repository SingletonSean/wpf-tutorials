using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TrayIcon.Commands;
using TrayIcon.Stores;

namespace TrayIcon.ViewModels
{
    public class TimerViewModel : ViewModelBase, IDisposable
    {
        private readonly TimerStore _timerStore;
        
        private int _duration;
        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        public double RemainingSeconds => _timerStore.RemainingSeconds;

        public ICommand StartCommand { get; }

        public TimerViewModel(TimerStore timerStore)
        {
            _timerStore = timerStore;
            StartCommand = new StartCommand(this, _timerStore);

            _timerStore.RemainingSecondsChanged += TimerStore_RemainingSecondsChanged;
        }

        private void TimerStore_RemainingSecondsChanged()
        {
            OnPropertyChanged(nameof(RemainingSeconds));
        }

        public void Dispose()
        {
            _timerStore.RemainingSecondsChanged -= TimerStore_RemainingSecondsChanged;
        }
    }
}
