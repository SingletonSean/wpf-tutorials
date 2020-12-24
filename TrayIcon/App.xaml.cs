using System;
using System.Drawing;
using System.Windows;
using TrayIcon.ViewModels;
using Forms = System.Windows.Forms;

namespace TrayIcon
{
    public partial class App : Application
    {
        private readonly Forms.NotifyIcon _notifyIcon;

        public App()
        {
            _notifyIcon = new Forms.NotifyIcon();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _notifyIcon.Icon = new System.Drawing.Icon("Resources/icon.ico");
            _notifyIcon.Text = "SingletonSean";
            _notifyIcon.Click += NotifyIcon_Click;

            _notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Status", Image.FromFile("Resources/icon.ico"), OnStatusClicked);
            _notifyIcon.ContextMenuStrip.Items.Add(new Forms.ToolStripLabel("Status: Running"));
            _notifyIcon.ContextMenuStrip.Items.Add(new Forms.ToolStripButton("Status: Running"));
            _notifyIcon.ContextMenuStrip.Items.Add(new Forms.ToolStripDropDownButton("Status: Running", null,
                new Forms.ToolStripLabel("Label 1"),
                new Forms.ToolStripLabel("Label 2")));
            _notifyIcon.BalloonTipClicked += NotifyIcon_BalloonTipClicked;
            _notifyIcon.Visible = true;

            MainWindow = new MainWindow();
            MainWindow.DataContext = new NotifyViewModel(_notifyIcon);
            MainWindow.Show();

            base.OnStartup(e);
        }

        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Application is running.", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnStatusClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Application is running.", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            MainWindow.WindowState = WindowState.Normal;
            MainWindow.Activate();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notifyIcon.Dispose();

            base.OnExit(e);
        }
    }
}
