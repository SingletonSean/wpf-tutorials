using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmToolkitDemo.Entities.ShoppingList;

namespace MvvmToolkitDemo.Features.AddShoppingListItem
{
    public partial class AddShoppingListItemViewModel : ObservableObject
    {
        private readonly ShoppingListStore _shoppingListStore;

        [ObservableProperty]
        private string _name = string.Empty;

        public AddShoppingListItemViewModel(ShoppingListStore shoppingListStore)
        {
            _shoppingListStore = shoppingListStore;
        }

        [RelayCommand]
        private void AddShoppingListItem()
        {
            _shoppingListStore.AddItem(Name);

            Name = string.Empty;
        }
    }
}
