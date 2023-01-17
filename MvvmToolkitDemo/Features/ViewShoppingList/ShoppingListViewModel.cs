using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MvvmToolkitDemo.Entities.ShoppingList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmToolkitDemo.Features.ViewShoppingList
{
    public class ShoppingListViewModel : ObservableRecipient, IRecipient<ShoppingListItemAddedMessage>
    {
        private readonly ObservableCollection<string> _shoppingListItems;
        public IEnumerable<string> ShoppingListItems => _shoppingListItems;

        public ShoppingListViewModel()
        {
            _shoppingListItems = new ObservableCollection<string>();
        }

        protected override void OnActivated()
        {
            StrongReferenceMessenger.Default.Register<ShoppingListItemAddedMessage>(this);

            ResetShoppingListItems();
        }

        protected override void OnDeactivated()
        {
            StrongReferenceMessenger.Default.Register<ShoppingListItemAddedMessage>(this);
        }

        private void ResetShoppingListItems()
        {
            _shoppingListItems.Clear();

            ShoppingListItemsRequestMessage items = StrongReferenceMessenger.Default.Send<ShoppingListItemsRequestMessage>();

            foreach (string item in items.Response)
            {
                _shoppingListItems.Add(item);
            }
        }

        public void Receive(ShoppingListItemAddedMessage message)
        {
            _shoppingListItems.Add(message.Name);
        }
    }
}
