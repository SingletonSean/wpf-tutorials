using CommunicationMVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationMVVM.Stores
{
    public class ProductStore
    {
        public event Action<Product> ProductCreated;

        public void CreateProduct(Product product)
        {
            ProductCreated?.Invoke(product);
        }
    }
}
