using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SwitchingViewsMVVM.Views
{
    /// <summary>
    /// Interaction logic for AccountView.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {
        public AccountView()
        {
            InitializeComponent();

            UpdateClockAngles();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateClockAngles();
        }

        private void UpdateClockAngles()
        {
            PART_HourLine.RenderTransform = new RotateTransform((DateTime.Now.Hour / 24.0) * 360, 0.5, 0.5);
            PART_MinuteLine.RenderTransform = new RotateTransform((DateTime.Now.Minute / 60.0) * 360, 0.5, 0.5);
            PART_SecondLine.RenderTransform = new RotateTransform((DateTime.Now.Second / 60.0) * 360, 0.5, 0.5);

        }
    }
}
