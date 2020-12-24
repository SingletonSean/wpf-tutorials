using System.Windows.Forms;
using System.Windows.Input;
using TrayIcon.Commands;

namespace TrayIcon.ViewModels
{
    public class NotifyViewModel : ViewModelBase
    {
        public ICommand NotifyCommand { get; }

        public NotifyViewModel(NotifyIcon notifyIcon)
        {
            NotifyCommand = new NotifyCommand(notifyIcon);
        }
    }
}
