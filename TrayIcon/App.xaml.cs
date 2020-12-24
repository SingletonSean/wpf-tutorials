using System;
using System.Drawing;
using System.Windows;
using TrayIcon.Services;
using TrayIcon.Stores;
using TrayIcon.ViewModels;
using Forms = System.Windows.Forms;

namespace TrayIcon
{
    public partial class App : Application
    {
        private readonly Forms.NotifyIcon _notifyIcon;

        private TimerStore _timerStore;
        private TimerViewModel _timerViewModel;

        public App()
        {
            _notifyIcon = new Forms.NotifyIcon();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _notifyIcon.Icon = new Icon("Resources/icon.ico");
            _notifyIcon.Text = "SingletonSean";
            _notifyIcon.Click += NotifyIcon_Click;

            _notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Status", Image.FromFile("Resources/icon.ico"), OnStatusClicked);
            //_notifyIcon.ContextMenuStrip.Items.Add(new Forms.ToolStripLabel("Status: Running"));
            //_notifyIcon.ContextMenuStrip.Items.Add(new Forms.ToolStripButton("Status: Running"));
            //_notifyIcon.ContextMenuStrip.Items.Add(new Forms.ToolStripDropDownButton("Status: Running", null,
            //    new Forms.ToolStripLabel("Label 1"),
            //    new Forms.ToolStripLabel("Label 2")));
            //_notifyIcon.BalloonTipClicked += NotifyIcon_BalloonTipClicked;

            _notifyIcon.Visible = true;

            _timerStore = new TimerStore(new NotifyIconNotificationService(_notifyIcon));
            _timerViewModel = new TimerViewModel(_timerStore);

            MainWindow = new MainWindow();
            MainWindow.DataContext = _timerViewModel;
            MainWindow.Show();

            base.OnStartup(e);
        }

        //private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Application is running.", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
        //}

        private void OnStatusClicked(object sender, EventArgs e)
        {
            string status = _timerStore.IsRunning ? "Timer is running." : "Timer is stopped.";
            MessageBox.Show(status, "Status", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            MainWindow.WindowState = WindowState.Normal;
            MainWindow.Activate();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notifyIcon.Dispose();
            _timerViewModel.Dispose();
            _timerStore.Dispose();

            base.OnExit(e);
        }
    }
}
