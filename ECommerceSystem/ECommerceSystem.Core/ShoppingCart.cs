namespace ECommerceSystem.Core;

using System;
using DataStructuresLibrary;

public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    public void AddItem(Product product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product));

        _items.Add(product);
    }

    public void RemoveItem(int index)
    {
        _items.RemoveAt(index);
    }

    public Product GetItemAt(int index)
    {
        return _items.Get(index);
    }

    public void ShowAllItems()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            Console.WriteLine(_items.Get(i));
        }
    }
}