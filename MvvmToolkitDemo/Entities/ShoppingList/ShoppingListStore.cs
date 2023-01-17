using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;

namespace MvvmToolkitDemo.Entities.ShoppingList
{
    public class ShoppingListStore
    {
        private readonly List<string> _items;

        public ShoppingListStore()
        {
            _items = new List<string>()
            {
                "Bananas",
                "Napkins",
                "Vitamins"
            };

            StrongReferenceMessenger.Default.Register<ShoppingListItemsRequestMessage>(this, (r, m) =>
            {
                m.Reply(_items);
            });
        }

        public void AddItem(string name)
        {
            _items.Add(name);

            StrongReferenceMessenger.Default.Send(new ShoppingListItemAddedMessage(name));
        }
    }
}
