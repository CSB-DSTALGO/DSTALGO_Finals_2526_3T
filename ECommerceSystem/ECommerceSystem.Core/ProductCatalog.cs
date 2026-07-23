namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ProductCatalog
{
    private readonly CustomSinglyLinkedList<Product> _products = new();

    public int Count => _products.Count;

    // Adds a new product to the catalog.
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Removes the specified product from the catalog.
    public bool RemoveProduct(Product product)
    {
        return _products.Remove(product);
    }

    // Searches for the specified product in the catalog.
    public bool SearchProduct(Product product)
    {
        return _products.Search(product);
    }

    // Sorts the catalog in ascending order by product price.
    public void SortCatalog()
    {
        _products.Sort();
    }
}