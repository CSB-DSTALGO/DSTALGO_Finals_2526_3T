using DataStructuresLibrary;

namespace ECommerceSystem.Core
{
    public class ShoppingCart
    {
        private readonly CustomArrayList<Product> _items = new();

        public int Count => _items.Count;

        public void AddItem(Product product) => throw new NotImplementedException();
        public bool RemoveItem(Product product) => throw new NotImplementedException();
        public Product GetItemAt(int index) => throw new NotImplementedException();

        public decimal CalculateTotal() => throw new NotImplementedException();


        public int SearchItem(Product product) => throw new NotImplementedException();
        public void SortCartByPrice() => throw new NotImplementedException();
    }
}