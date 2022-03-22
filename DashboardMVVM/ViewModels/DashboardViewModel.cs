using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardMVVM.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public ProfitViewModel ProfitViewModel { get; }
        public CostsViewModel CostsViewModel { get; }
        public RevenueViewModel RevenueViewModel { get; }
        public RecentSalesViewModel RecentSalesViewModel { get; }

        public DashboardViewModel(
            ProfitViewModel profitViewModel,
            CostsViewModel costsViewModel,
            RevenueViewModel revenueViewModel,
            RecentSalesViewModel recentSalesViewModel)
        {
            ProfitViewModel = profitViewModel;
            CostsViewModel = costsViewModel;
            RevenueViewModel = revenueViewModel;
            RecentSalesViewModel = recentSalesViewModel;
        }
    }
}
