using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardMVVM.ViewModels
{
    public class ProfitViewModel : ViewModelBase
    {
        public decimal Value => 500;

        public bool IsPositive => Value > 0;
        public bool IsNegative => Value < 0;
    }
}
