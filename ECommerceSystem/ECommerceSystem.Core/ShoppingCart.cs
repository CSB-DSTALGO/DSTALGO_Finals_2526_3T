namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    public int Count => _items.Count;

    /// <summary>
    /// Adds a product to the shopping cart.
    /// </summary>
    public void AddItem(Product product)
    {
        _items.Add(product);
    }

    /// <summary>
    /// Removes the first product that matches the given product.
    /// This keeps Lim's existing method.
    /// </summary>
    public bool RemoveItem(Product product)
    {
        return _items.Remove(product);
    }

    /// <summary>
    /// Removes a product using its index.
    /// This follows the exact method required in the project.
    /// </summary>
    public void RemoveItem(int index)
    {
        _items.RemoveAt(index);
    }

    /// <summary>
    /// Returns the product stored at the given index.
    /// </summary>
    public Product GetItemAt(int index)
    {
        return _items.Get(index);
    }

    /// <summary>
    /// Displays all products currently stored in the cart.
    /// </summary>
    public void ShowAllItems()
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("The shopping cart is empty.");
            return;
        }

        for (int i = 0; i < _items.Count; i++)
        {
            Console.WriteLine(_items.Get(i));
        }
    }

    /// <summary>
    /// Calculates the total price of all products in the cart.
    /// </summary>
    public decimal CalculateTotal()
    {
        decimal total = 0m;

        for (int i = 0; i < _items.Count; i++)
        {
            total += _items.Get(i).Price;
        }

        return total;
    }

    /// <summary>
    /// Searches for a product and returns its index.
    /// Returns -1 when the product is not found.
    /// </summary>
    public int SearchItem(Product product)
    {
        return _items.Search(product);
    }

    /// <summary>
    /// Sorts the products according to Product.CompareTo().
    /// </summary>
    public void SortCartByPrice()
    {
        _items.Sort();
    }
}