using ClassCommands.Services;
using ClassCommands.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassCommands.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public BuyViewModel BuyViewModel { get; set; }
        public SellViewModel SellViewModel { get; }

        public MainViewModel()
        {
            OwnedItemsStore ownedItemsStore = new OwnedItemsStore();
            PriceService priceService = new PriceService();

            BuyViewModel = new BuyViewModel(ownedItemsStore, priceService);
            SellViewModel = new SellViewModel(ownedItemsStore, priceService);
        }
    }
}
