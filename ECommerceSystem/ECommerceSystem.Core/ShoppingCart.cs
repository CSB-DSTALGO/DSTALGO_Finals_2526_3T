namespace ECommerceSystem.Core;

using DataStructuresLibrary;


public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    public int Count => _items.Count;

    public void AddItem(Product product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product), "Cannot add a null product to the cart.");

        _items.Add(product);
    }


    public bool RemoveItem(Product product)
    {
        if (product is null) return false;
        return _items.Remove(product);
    }

 
    public Product GetItemAt(int index) => _items.Get(index);

    public decimal CalculateTotal()
    {
        decimal total = 0m;
        for (int i = 0; i < _items.Count; i++)
            total += _items.Get(i).Price;

        return total;
    }


    public int SearchItem(Product product)
    {
        if (product is null) return -1;
        return _items.Search(product);
    }


    public void SortCartByPrice() => _items.Sort();


    public void ShowAllItems()
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("The cart is empty.");
            return;
        }

        Console.WriteLine("=== Shopping Cart ===");
        for (int i = 0; i < _items.Count; i++)
        {
            var p = _items.Get(i);
            Console.WriteLine($"[{i}] {p.Name} - ${p.Price:F2}");
        }
    }
}
