using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TrayIcon.Services
{
    public enum NotificationType
    {
        TimerComplete,
        RestartTimer
    }

    public interface INotificationService
    {
        event Action<NotificationType> NotificationAccepted;

        void Notify(string title, string message, int timeout, NotificationType notificationType, ToolTipIcon icon);
    }
}
