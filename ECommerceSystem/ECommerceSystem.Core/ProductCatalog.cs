namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ProductCatalog
{
    private readonly CustomSinglyLinkedList<Product> _products = new();

    public int Count => _products.Count;

    public void AddProduct(Product product) => throw new NotImplementedException();
    public bool RemoveProduct(Product product) => throw new NotImplementedException();

    
    public bool SearchProduct(Product product) => throw new NotImplementedException();
    public void SortCatalog() => throw new NotImplementedException();
}