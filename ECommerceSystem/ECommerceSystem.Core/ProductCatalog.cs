namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ProductCatalog
{
    private readonly CustomArrayList<Product> _products = new();

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
        return _products.Search(product) != -1;
    }

    public void SortCatalog()
    {
        _products.Sort();
    }
}