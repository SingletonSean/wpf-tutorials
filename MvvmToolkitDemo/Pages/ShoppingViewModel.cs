using CommunityToolkit.Mvvm.ComponentModel;
using MvvmToolkitDemo.Features.AddShoppingListItem;
using MvvmToolkitDemo.Features.ViewShoppingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmToolkitDemo.Pages
{
    public class ShoppingViewModel : ObservableObject
    {
        public AddShoppingListItemViewModel AddShoppingListItemViewModel { get; }
        public ShoppingListViewModel ShoppingListViewModel { get; }

        public ShoppingViewModel(AddShoppingListItemViewModel addShoppingListItemViewModel, ShoppingListViewModel shoppingListViewModel)
        {
            AddShoppingListItemViewModel = addShoppingListItemViewModel;
            ShoppingListViewModel = shoppingListViewModel;
        }
    }
}
