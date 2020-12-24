using System.Windows.Forms;

namespace TrayIcon.Commands
{
    public class NotifyCommand : BaseCommand
    {
        private readonly NotifyIcon _notifyIcon;

        public NotifyCommand(NotifyIcon notifyIcon)
        {
            _notifyIcon = notifyIcon;
        }

        public override void Execute(object parameter)
        {
            _notifyIcon.ShowBalloonTip(3000, "SingletonSean", "Be sure to subscribe.", ToolTipIcon.Info);
        }
    }
}
