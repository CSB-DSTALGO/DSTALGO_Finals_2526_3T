namespace ECommerceSystem.Core;

using DataStructuresLibrary;


public class ProductCatalog
{
    private readonly CustomSinglyLinkedList<Product> _products = new();

    public int Count => _products.Count;

    public void AddProduct(Product product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product), "Cannot add a null product.");

        _products.Add(product);
    }


    public bool RemoveProduct(Product product)
    {
        if (product is null) return false;
        return _products.Remove(product);
    }

    public bool SearchProduct(Product product)
    {
        if (product is null) return false;
        return _products.Search(product);
    }

    public void SortCatalog() => _products.Sort();

    public Product GetProductDetails(int index)
    {
        if (index < 0 || index >= _products.Count)
            throw new ArgumentOutOfRangeException(nameof(index), "No product exists at that position.");

        int i = 0;
        foreach (var product in _products.GetAll())
        {
            if (i == index) return product;
            i++;
        }

        throw new ArgumentOutOfRangeException(nameof(index));
    }

    public void ShowAllProfiles()
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("The catalog is empty.");
            return;
        }

        Console.WriteLine("=== Product Catalog ===");
        int i = 0;
        foreach (var product in _products.GetAll())
        {
            Console.WriteLine($"[{i}] {product.Name} - ${product.Price:F2}");
            i++;
        }
    }
}
