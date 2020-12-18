using ClassCommands.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCommands.Services
{
    public class PriceService : IPriceService
    {
        /// <summary>
        /// Get the price of an item.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <returns>The price of the item.</returns>
        /// <exception cref="ItemPriceNotFoundException">Thrown if item price is unknown.</exception>
        public double GetPrice(string itemName)
        {
            switch (itemName.ToLower())
            {
                case "apple":
                    return 0.49;
                case "shirt":
                    return 19.99;
                case "phone":
                    return 499.99;
                case "burrito":
                    return 9.99;
                case "shoes":
                    return 119.99;
                default:
                    throw new ItemPriceNotFoundException(itemName);
            }
        }
    }
}
