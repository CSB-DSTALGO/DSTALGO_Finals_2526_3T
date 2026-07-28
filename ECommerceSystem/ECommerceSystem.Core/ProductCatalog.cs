namespace ECommerceSystem.Core;

using System;
using DataStructuresLibrary;

public class ProductCatalog
{
    private readonly CustomSinglyLinkedList<Product> _products = new();

    public int Count => _products.Count;

    public void AddProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        _products.Add(product);
    }

    public bool RemoveProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        return _products.Remove(product);
    }

    public bool SearchProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        return _products.Search(product);
    }

    public void SortCatalog()
    {
        _products.Sort();
    }
}