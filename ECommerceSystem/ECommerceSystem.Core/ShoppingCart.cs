namespace ECommerceSystem.Core;

using DataStructuresLibrary;

// Code by: Victor Tarra

public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    public int Count => _items.Count;

    // Adds a product to the cart using dynamic array insertion.
    public void AddItem(Product product)
    {
        _items.Add(product);
    }

    // Removes a product using Linear Search from CustomArrayList.
    public bool RemoveItem(Product product)
    {
        return _items.Remove(product);
    }

    // Retrieves a product by index.
    public Product GetItemAt(int index)
    {
        return _items.Get(index);
    }

    // Calculates total price by iterating through all items.
    public decimal CalculateTotal()
    {
        decimal total = 0;

        for (int i = 0; i < _items.Count; i++)
        {
            total += _items.Get(i).Price;
        }

        return total;
    }

    // Searches for a product using Linear Search.
    // Returns index if found, otherwise -1.
    public int SearchItem(Product product)
    {
        return _items.Search(product);
    }

    // Sorts products using Bubble Sort based on Product.CompareTo().
    // Typically sorts by price in ascending order.
    public void SortCartByPrice()
    {
        _items.Sort();
    }
}