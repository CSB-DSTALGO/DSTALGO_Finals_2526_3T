namespace ECommerceSystem.Core;

using DataStructuresLibrary;

/// <summary>
/// Manages products in a shopping cart using CustomArrayList.
/// </summary>
public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    /// <summary>
    /// Gets the number of products currently in the cart.
    /// </summary>
    public int Count => _items.Count;

    /// <summary>
    /// Adds a product to the end of the cart.
    /// Amortized time complexity: O(1).
    /// </summary>
    public void AddItem(Product product)
    {
        _items.Add(product);
    }

    /// <summary>
    /// Removes the first product that compares equal to the target.
    /// Time complexity: O(n).
    /// </summary>
    public bool RemoveItem(Product product)
    {
        return _items.Remove(product);
    }

    /// <summary>
    /// Removes a product using its zero-based index.
    /// Time complexity: O(n).
    /// </summary>
    public void RemoveItem(int index)
    {
        _items.RemoveAt(index);
    }

    /// <summary>
    /// Returns the product stored at the specified index.
    /// Time complexity: O(1).
    /// </summary>
    public Product GetItemAt(int index)
    {
        return _items.Get(index);
    }

    /// <summary>
    /// Prints every product currently stored in the cart.
    /// Time complexity: O(n).
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
            Product product = _items.Get(i);

            Console.WriteLine(
                $"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:0.00}");
        }
    }

    /// <summary>
    /// Calculates and returns the sum of all product prices.
    /// Time complexity: O(n).
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
    /// Performs a linear search and returns the matching product index.
    /// Returns -1 when the product is not found.
    /// Time complexity: O(n).
    /// </summary>
    public int SearchItem(Product product)
    {
        return _items.Search(product);
    }

    /// <summary>
    /// Sorts products by price using the array list's insertion sort.
    /// Time complexity: O(n^2).
    /// </summary>
    public void SortCartByPrice()
    {
        _items.Sort();
    }
}
