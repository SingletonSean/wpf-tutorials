using MVVMEssentials.ViewModels;

namespace ItemsControlDemo.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        public string Name { get; }
        public string Description { get; }
        public double Price { get; }

        public ProductViewModel(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
