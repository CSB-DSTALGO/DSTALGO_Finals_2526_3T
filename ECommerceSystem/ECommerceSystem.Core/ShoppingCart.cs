namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    // Returns the current number of products in the shopping cart.
    public int Count => _items.Count;

    // Adds a product to the shopping cart.
    public void AddItem(Product product)
    {
        _items.Add(product);
    }

    // Removes the product at the specified index from the shopping cart.
    public void RemoveItem(int index)
    {
        // Gets the product at the specified index before removing it.
        Product product = _items.Get(index);
        _items.Remove(product);
    }

    // Returns the product stored at the specified index.
    public Product GetItemAt(int index)
    {
        return _items.Get(index);
    }

    // Displays all products currently stored in the shopping cart.
    public void ShowAllItems()
    {
        // Loops through each product in the shopping cart.
        for (int i = 0; i < _items.Count; i++)
        {
            Console.WriteLine(_items.Get(i));
        }
    }

    // Calculates and returns the total price of all products in the shopping cart.
    public decimal CalculateTotal()
    {
        decimal total = 0;

        // Adds the price of each product to the total.
        for (int i = 0; i < _items.Count; i++)
        {
            total += _items.Get(i).Price;
        }

        return total;
    }

    // Searches for a product and returns its index in the shopping cart.
    public int SearchItem(Product product)
    {
        return _items.Search(product);
    }

    // Sorts the products in the shopping cart by price.
    public void SortCartByPrice()
    {
        _items.Sort();
    }
}