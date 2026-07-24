namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ProductCatalog
{
    private readonly CustomSinglyLinkedList<Product> _products = new();

    public int Count => _products.Count;

    // Adds a product to the catalog
    public void AddProduct(Product product)  { _products.Add(product); }
    
    // Removes a product from the catalog
    public bool RemoveProduct(Product product) { return _products.Remove(product); }
    
    // Searches for a product in the catalog
    public bool SearchProduct(Product product) { return _products.Search(product); }
    
    // Sorts the catalog
    public void SortCatalog() { _products.Sort(); }
}