namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    /// Gets the number of products currently in the shopping cart.

    public int Count => _items.Count;

    /// Adds a product to the shopping cart.

    public void AddItem(Product product)
    {
        _items.Add(product);
    }

    /// Removes the specified product from the shopping cart.

    public bool RemoveItem(Product product)
    {
        return _items.Remove(product);
    }

    /// Returns the product at the specified index.

    public Product GetItemAt(int index)
    {
        return _items.Get(index);
    }

    /// Calculates the total cost of all products in the shopping cart.

    public decimal CalculateTotal()
    {
        decimal total = 0;

        for (int i = 0; i < Count; i++)
        {
            total += _items.Get(i).Price;
        }

        return total;
    }

    /// Searches for a product in the shopping cart.

    public int SearchItem(Product product)
    {
        return _items.Search(product);
    }

    /// Sorts the products in ascending order by price.

    public void SortCartByPrice()
    {
        _items.Sort();
    }
}