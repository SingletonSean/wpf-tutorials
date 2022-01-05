using MVVMEssentials.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ItemsControlDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ProductViewModel> _productViewModels;
        public IEnumerable<ProductViewModel> ProductViewModels => _productViewModels;

        public MainViewModel()
        {
            _productViewModels = new ObservableCollection<ProductViewModel>()
            {
                new ProductViewModel("T-Shirt", "A beautiful blue t-shirt.", 29.99),
                new ProductViewModel("Sweatpants", "The greatest gray sweatpants.", 19.99),
                new ProductViewModel("Shoes", "Some radical red shoes.", 179.99),
                new ProductViewModel("Socks", "Just regular socks.", 4.99),
                new ProductViewModel("Shorts", "A pair of shorts that you can use to wear around in, play sports, or record YouTube videos.", 19.99)
            };
        }
    }
}
