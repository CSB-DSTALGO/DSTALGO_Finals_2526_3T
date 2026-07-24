// 12521269 Joaquin Bryan G. Ross
namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    public int Count => _items.Count;

    /// <summary>
    /// Inserts an inventory record at the end of the cart. O(1) amortised:
    /// the write itself is constant, and the occasional capacity doubling
    /// spreads out to a constant cost per item.
    /// </summary>
    public void AddItem(Product product) => _items.Add(product);

    /// <summary>
    /// Removes a product by index. O(n), because every item after the removed
    /// slot shifts one position left to close the gap. Returns false when the
    /// index is outside the cart rather than throwing, so the console UI can
    /// report a bad choice without a try/catch.
    /// </summary>
    public bool RemoveItem(int index)
    {
        if (index < 0 || index >= _items.Count) return false;

        _items.RemoveAt(index);
        return true;
    }

    /// <summary>
    /// Returns a record by index. O(1): an array list computes the address
    /// directly, which is the reason the cart is backed by one.
    /// </summary>
    public Product GetItemAt(int index) => _items.Get(index);

    /// <summary>
    /// Outputs the entire array state. O(n) over one pass of the cart.
    /// </summary>
    public void ShowAllItems()
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("The cart is empty.");
            return;
        }

        for (int i = 0; i < _items.Count; i++)
        {
            Product item = _items.Get(i);
            Console.WriteLine($"[{i}] #{item.Id} {item.Name} - ${item.Price:F2}");
        }
    }

    /// <summary>
    /// Sums the price of every item. O(n), walking the cart by index because
    /// the cart deliberately exposes no iterator.
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
    /// Search algorithm: linear search, delegated to CustomArrayList.Search.
    /// It compares each slot from index 0 upward until it finds a match.
    /// Best case O(1) when the item is first, worst and average case O(n).
    /// Linear search is the right fit here because the cart is only sorted on
    /// demand, and binary search would need the data sorted at all times.
    /// Returns the item's position, or -1 when it is not in the cart.
    /// </summary>
    public int SearchItem(Product product) => _items.Search(product);

    /// <summary>
    /// Sorting algorithm: insertion sort, delegated to CustomArrayList.Sort.
    /// It grows a sorted region at the front of the array, taking each next
    /// item and shifting larger items right until the item drops into place.
    /// Best case O(n) when the cart is already ordered, worst and average case
    /// O(n^2), with O(1) extra space since it sorts in place. That suits a
    /// shopping cart, which holds few items and is often nearly sorted already.
    /// Product.CompareTo orders by price, so the cheapest item ends up first.
    /// </summary>
    public void SortCartByPrice() => _items.Sort();
}