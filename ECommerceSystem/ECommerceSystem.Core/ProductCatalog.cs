namespace ECommerceSystem.Core;

using DataStructuresLibrary;

/// <summary>
/// Manages the product catalog using a custom singly linked list.
/// </summary>
public class ProductCatalog
{
    private readonly CustomSinglyLinkedList<Product> _products = new();

    /// <summary>
    /// Gets the number of products currently stored in the catalog.
    /// </summary>
    public int Count => _products.Count;

    /// <summary>
    /// Appends a product node to the end of the catalog.
    /// Time complexity: O(n).
    /// </summary>
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    /// <summary>
    /// Removes the first product node that compares equal to the target.
    /// Time complexity: O(n).
    /// </summary>
    public bool RemoveProduct(Product product)
    {
        return _products.Remove(product);
    }

    /// <summary>
    /// Performs a linear traversal to check whether a product exists.
    /// Time complexity: O(n).
    /// </summary>
    public bool SearchProduct(Product product)
    {
        return _products.Search(product);
    }

    /// <summary>
    /// Locates and returns the product at the specified zero-based index.
    /// Time complexity: O(n).
    /// </summary>
    public Product GetProductDetails(int index)
    {
        return _products.Get(index);
    }

    /// <summary>
    /// Traverses and prints every product in the continuous node chain.
    /// Time complexity: O(n^2) with the current indexed Get traversal.
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
            Product product = _products.Get(i);

            Console.WriteLine(
                $"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:0.00}");
        }
    }

    /// <summary>
    /// Sorts product nodes by price using the linked list's bubble sort.
    /// Time complexity: O(n^2).
    /// </summary>
    public void SortCatalog()
    {
        _products.Sort();
    }
}
