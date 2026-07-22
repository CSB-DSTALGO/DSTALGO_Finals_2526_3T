using DataStructuresLibrary;

namespace ECommerceSystem.Core
{
    public class ProductCatalog
    {
        private readonly CustomSinglyLinkedList<Product> _products = new();

        public int Count => _products.Count;

        public void AddProduct(Product product)
        {
            _products.AddLast(product);
        }

        public bool RemoveProduct(Product product)
        {
            return _products.Remove(product);
        }

        public bool SearchProduct(Product product)
        {
            return _products.Find(product) != null;
        }

        public void SortCatalog()
        {
            _products.Sort();
        }

        public Product GetProductDetails(int index)
        {
            return _products.GetProductDetails(index);
        }

        public void DisplayCatalog()
        {
            foreach (var product in _products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
