namespace ECommerceSystem.Core;

using System;
using DataStructuresLibrary;

public class ProductCatalog
{
    // Holds all the products using our custom linked list instead of List<T>
    private readonly CustomSinglyLinkedList<Product> _products = new();

    // Returns how many products are currently in the catalog
    public int Count => _products.Count;

    // Adds a new product to the catalog
    public void AddProduct(Product product)
    {
        // Don't add anything if the product passed in is null
        if (product == null) return;

        _products.Add(product);
    }

    // Removes a product from the catalog if it exists
    public bool RemoveProduct(Product product)
    {
        // Can't remove something that doesn't exist
        if (product == null) return false;

        return _products.Remove(product);
    }

    // Checks if a specific product is already in the catalog
    public bool SearchProduct(Product product)
    {
        // Nothing to search for if the product is null
        if (product == null) return false;

        return _products.Search(product);
    }

    // Sorts all products in the catalog (ascending order, based on Product's CompareTo)
    public void SortCatalog()
    {
        _products.Sort();
    }
}