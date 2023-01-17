namespace MvvmToolkitDemo.Entities.ShoppingList
{
    public class ShoppingListItemAddedMessage
    {
        public string Name { get; }

        public ShoppingListItemAddedMessage(string name)
        {
            Name = name;
        }
    }
}
