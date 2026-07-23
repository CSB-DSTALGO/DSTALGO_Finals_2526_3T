namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ShoppingCart
{
    private readonly CustomArrayList<Product> _items = new();

    public int Count => _items.Count;

    public void AddItem(Product product) => _items.Add(product);
    
    public bool RemoveItem(Product product)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if(_items.Get(i).Id == product.Id)
            {
                _items.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
    public Product GetItemAt(int index) => _items.Get(index);

    // Calculates the total price of all products in the shopping cart.
    public decimal CalculateTotal()
    {
        decimal total = 0;

        for (int i = 0; i < _items.Count; i++)
        {
            total += _items.Get(i).Price;
        }

        return total;
    }


    // Searches for a product in the shopping cart.
    public int SearchItem(Product product) => _items.Search(product);
    // Sorts the shopping cart by product price in ascending order.
    public void SortCartByPrice() => _items.Sort();
}