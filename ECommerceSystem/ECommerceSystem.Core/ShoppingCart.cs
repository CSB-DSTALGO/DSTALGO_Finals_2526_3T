namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    public int Count
    {
        get { return _items.Count; }
    }

    public void AddItem(Product product)
    {
        _items.Add(product);
    }

    public bool RemoveItem(Product product)
    {
        return _items.Remove(product);
    }

    public Product GetItemAt(int index)
    {
        return _items.Get(index);
    }

    public decimal CalculateTotal()
    {
        decimal total = 0m;

        for (int i = 0; i < _items.Count; i++)
        {
            Product currentProduct = _items.Get(i);
            total = total + currentProduct.Price;
        }

        return total;
    }

    public int SearchItem(Product product)
    {
        return _items.Search(product);
    }

    public void SortCartByPrice()
    {
        _items.Sort();
    }
}