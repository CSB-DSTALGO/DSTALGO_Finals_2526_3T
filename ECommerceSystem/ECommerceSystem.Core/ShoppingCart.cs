namespace ECommerceSystem.Core;

using System;
using DataStructuresLibrary;

public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    // Required by tests
    public int Count => _items.Count;

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

    // Required by tests
    public decimal CalculateTotal()
    {
        decimal total = 0;

        for (int i = 0; i < _items.Count; i++)
        {
            total += _items.Get(i).Price;
        }

        return total;
    }

    public int SearchItem(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        return _items.Search(product);
    }

    public void SortCartByPrice()
    {
        _items.Sort();
    }

    public void ShowAllItems()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            Console.WriteLine(_items.Get(i));
        }
    }
}