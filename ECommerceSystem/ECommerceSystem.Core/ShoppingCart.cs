namespace ECommerceSystem.Core;

using DataStructuresLibrary;

// Represents a customer's shopping cart.
// It stores Product items using CustomArrayList, a teammate's custom
// data structure (similar to a resizable array / List<T>).
public class ShoppingCart
{
    // The underlying storage for cart items.
    // "readonly" means this field itself can't be reassigned after
    // construction, though items can still be added/removed inside it.
    private readonly CustomArrayList<Product> _items = new();

    // Exposes how many items are currently in the cart.
    // This just forwards to the underlying list's Count.
    public int Count => _items.Count;

    // Adds a product to the cart.
    public void AddItem(Product product) => _items.Add(product);

    // Removes a product from the cart.
    // Returns true if the product was found and removed, false otherwise.
    public bool RemoveItem(Product product) => _items.Remove(product);

    // Retrieves the product at a specific position (index) in the cart.
    public Product GetItemAt(int index) => _items.Get(index);

    // Adds up the Price of every item currently in the cart
    // and returns the total cost.
    public decimal CalculateTotal()
    {
        decimal total = 0m;

        // Loop through every item by index and add its price to the running total.
        for (int i = 0; i < _items.Count; i++)
        {
            total += _items.Get(i).Price;
        }

        return total;
    }

    // Looks for a product in the cart.
    // Returns its index if found, or a "not found" indicator
    // (depends on how CustomArrayList.Search is implemented,
    // typically -1 when not found).
    public int SearchItem(Product product) => _items.Search(product);

    // Sorts the items in the cart by price, using CustomArrayList's
    // own Sort implementation.
    public void SortCartByPrice() => _items.Sort();
}


