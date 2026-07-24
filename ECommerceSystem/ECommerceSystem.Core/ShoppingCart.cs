using DataStructuresLibrary;

namespace ECommerceSystem.Core
{
    public class ShoppingCart
    {
        private readonly CustomArrayList<Product> _items = new();

        public int Count => _items.Count;

<<<<<<< Updated upstream
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
        decimal total = 0;
        for (int i = 0; i < _items.Count; i++)
        {
            total += _items.Get(i).Price;
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
=======
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
            decimal total = 0;
            for (int i = 0; i < _items.Count; i++)
            {
                total += _items.Get(i).Price;
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

        public void ShowAllItems()
        {
            _items.ShowAllItems();
        }
    }
}

>>>>>>> Stashed changes
