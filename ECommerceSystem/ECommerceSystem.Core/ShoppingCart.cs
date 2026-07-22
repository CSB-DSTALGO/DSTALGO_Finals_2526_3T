namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new(); // walang product class dba..?

    public int Count => _items.Count;

    // insrrts inventory record
    public void AddItem(Product product)
    {
        _items.Add(product);
    }

    // remove product by index
    public bool RemoveItem(Product product)
    {
        return _items.Remove(product);
    }

    // returns record by index
    public Product GetItemAt(int index)
    {
        return _items.Get(index);
    }

    // shows all items

    public void ShowAllItems()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            Console.WriteLine(_items.Get(i));
        }
    }

    // Calculates the total price of all products in the cart
    public decimal CalculateTotal()
    {
        decimal total = 0;

        for (int i = 0; i < _items.Count; i++)
        {
            total += _items.Get(i).Price;
        }

        return total;
    }

    // Searches for a product and returns its index
    public int SearchItem(Product product)
    {
        return _items.Search(product);
    }

    // Sorts the cart by product price (or however Product.CompareTo() is implemented)
    public void SortCartByPrice()
    {
        _items.Sort();
    }
}