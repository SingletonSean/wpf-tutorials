using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Forms = System.Windows.Forms;
using TrayIcon.Services;

namespace TrayIcon.Stores
{
    public class TimerStore : IDisposable
    {
        private readonly INotificationService _notificationService;
        private readonly Timer _timer;

        private DateTime _endTime;
        private bool _wasRunning;
        private int _lastDurationInSeconds;

        private double EndTimeCurrentTimeSecondsDifference => TimeSpan.FromTicks(_endTime.Ticks).TotalSeconds - TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds;
        public double RemainingSeconds => EndTimeCurrentTimeSecondsDifference > 0 ? EndTimeCurrentTimeSecondsDifference : 0;

        public bool IsRunning => RemainingSeconds > 0;

        public event Action RemainingSecondsChanged;

        public TimerStore(INotificationService notificationService)
        {
            _notificationService = notificationService;
            _notificationService.NotificationAccepted += NotificationService_NotificationAccepted;

            _timer = new Timer(1000);
            _timer.Elapsed += Timer_Elapsed;
        }

        public void Start(int durationInSeconds)
        {
            _lastDurationInSeconds = durationInSeconds;

            _timer.Start();
            _endTime = DateTime.Now.AddSeconds(durationInSeconds);

            OnRemainingSecondsChanged();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnRemainingSecondsChanged();

            if(_wasRunning && !IsRunning)
            {
                _notificationService.Notify("Timer", "The timer has completed.", 
                    3000, NotificationType.RestartTimer, Forms.ToolTipIcon.Info);
            }

            _wasRunning = IsRunning;
        }

        private void NotificationService_NotificationAccepted(NotificationType lastNotificationType)
        {
            if(lastNotificationType == NotificationType.RestartTimer)
            {
                Start(_lastDurationInSeconds);
            }
        }

        private void OnRemainingSecondsChanged()
        {
            RemainingSecondsChanged?.Invoke();
        }

        public void Dispose()
        {
            _notificationService.NotificationAccepted -= NotificationService_NotificationAccepted;
            _timer.Dispose();
        }
    }
}
