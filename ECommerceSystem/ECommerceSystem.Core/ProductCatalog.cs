namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ProductCatalog
{
    private readonly CustomSinglyLinkedList<Product> _products = new();

    public int Count => _products.Count;

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public bool RemoveProduct(Product product)
    {
        return _products.Remove(product);
    }

    public bool SearchProduct(Product product)
    {
        return _products.Search(product);
    }

    /// <summary>
    /// Returns the product stored at the specified index.
    /// </summary>
    public Product GetProductDetails(int index)
    {
        return _products.Get(index);
    }

    /// <summary>
    /// Displays all products stored in the catalog.
    /// </summary>
    public void ShowAllProfiles()
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("The product catalog is empty.");
            return;
        }

        for (int i = 0; i < _products.Count; i++)
        {
            Console.WriteLine(_products.Get(i));
        }
    }

    public void SortCatalog()
    {
        _products.Sort();
    }
}