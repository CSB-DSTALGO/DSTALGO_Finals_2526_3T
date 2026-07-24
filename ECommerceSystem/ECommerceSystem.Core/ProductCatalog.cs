namespace ECommerceSystem.Core;

using DataStructuresLibrary;
using System;
using System.Collections.Generic;

public class ProductCatalog
{
    private readonly CustomSinglyLinkedList<Product> _products = new();

    public int Count => _products.Count;

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public bool RemoveProduct(Product product)
    {
        return _products.Remove(product);
    }

    public bool SearchProduct(Product product)
    {
        return _products.Contains(product);
    }

    public void SortCatalog()
    {
        var productList = new List<Product>();
        foreach (var item in _products)
        {
            productList.Add(item);
        }

        productList.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));

        _products.Clear();
        foreach (var product in productList)
        {
            _products.Add(product);
        }
    }
}
