namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ProductCatalog
{
    private readonly CustomSinglyLinkedList<Product> _products = new();

    public int Count => _products.Count;

    public void AddProduct(Product product) => _products.Add(product);
    public bool RemoveProduct(Product product) => _products.Remove(product);

    
    public bool SearchProduct(Product product) => _products.Search(product);
    public void SortCatalog() => _products.Sort();
}