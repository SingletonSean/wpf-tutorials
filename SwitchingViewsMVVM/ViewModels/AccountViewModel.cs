using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SwitchingViewsMVVM.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public double Hour { get; set; } = (DateTime.Now.Hour / 12.0) * 360;
        public double Minute { get; set; } = (DateTime.Now.Minute / 60.0) * 360;
        public double Second { get; set; } = (DateTime.Now.Second / 60.0) * 360;

        public AccountViewModel()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnPropertyChanged(nameof(Hour));
            OnPropertyChanged(nameof(Minute));
            OnPropertyChanged(nameof(Second));
        }
    }
}
