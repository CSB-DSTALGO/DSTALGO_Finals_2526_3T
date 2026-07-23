namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    public int Count => _items.Count;

    public void AddItem(Product product)
    {
        _items.Add(product);
    }

    public void RemoveItem(int index)
    {
        Product product = _items.Get(index);
        _items.Remove(product);
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
        return _items.Search(product);
    }

    public void SortCartByPrice()
    {
        _items.Sort();
    }
}