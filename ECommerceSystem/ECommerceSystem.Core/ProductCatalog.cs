namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ProductCatalog
{
    private readonly CustomSinglyLinkedList<Product> _products = new();
    public int Count => _products.Count;

    // adds product 
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // removes product 
    public bool RemoveProduct(Product product)
    {
        return _products.Remove(product);
    }

    // to check if a product exists
    public bool SearchProduct(Product product)
    {
        return _products.Search(product);
    }

    // Sorts all products
    public void SortCatalog()
    {
        _products.Sort();
    }
}