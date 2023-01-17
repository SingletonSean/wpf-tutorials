using CommunityToolkit.Mvvm.Messaging.Messages;
using System.Collections.Generic;

namespace MvvmToolkitDemo.Entities.ShoppingList
{
    public class ShoppingListItemsRequestMessage : RequestMessage<IEnumerable<string>> { }
}
