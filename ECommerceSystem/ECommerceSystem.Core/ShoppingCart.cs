namespace ECommerceSystem.Core;

using DataStructuresLibrary;

/// <summary>
/// Represents a user's shopping cart, built on CustomArrayList
/// instead of any built-in .NET collection.
/// </summary>
public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    public int Count => _items.Count;

    /// <summary>Inserts a product into the cart.</summary>
    public void AddItem(Product product)
    {
        _items.Add(product);
    }

    /// <summary>Removes the given product from the cart. Returns true if found and removed.</summary>
    public bool RemoveItem(Product product)
    {
        return _items.Remove(product);
    }

    /// <summary>Returns the product stored at the given index.</summary>
    public Product GetItemAt(int index)
    {
        return _items.Get(index);
    }

    /// <summary>Sums the price of every product currently in the cart.</summary>
    public decimal CalculateTotal()
    {
        decimal total = 0m;
        for (int i = 0; i < _items.Count; i++)
        {
            total += _items.Get(i).Price;
        }
        return total;
    }

    /// <summary>Finds a product in the cart using CustomArrayList's linear search.</summary>
    public int SearchItem(Product product)
    {
        return _items.Search(product);
    }

    /// <summary>Sorts cart items by Price (ascending) using CustomArrayList's insertion sort.</summary>
    public void SortCartByPrice()
    {
        _items.Sort();
    }
}