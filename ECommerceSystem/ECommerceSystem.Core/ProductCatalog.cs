namespace ECommerceSystem.Core;

using System;
using DataStructuresLibrary;

public class ProductCatalog
{
    private readonly CustomSinglyLinkedList<Product> _catalog = new();

    public int Count => _catalog.Count;

    public void AddProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        _catalog.Add(product);
    }

    public bool RemoveProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        return _catalog.Remove(product);
    }

    public Product GetProductDetails(int index)
    {
        return _catalog.Get(index);
    }

    public bool SearchProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        return _catalog.Search(product);
    }

    public void SortCatalog()
    {
        _catalog.Sort();
    }

    public void ShowAllProfiles()
    {
        for (int i = 0; i < _catalog.Count; i++)
        {
            Console.WriteLine(_catalog.Get(i));
        }
    }
}