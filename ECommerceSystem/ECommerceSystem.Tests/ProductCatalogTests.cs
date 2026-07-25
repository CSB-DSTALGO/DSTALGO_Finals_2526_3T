namespace ECommerceSystem.Tests;

using System;
using System.IO;
using ECommerceSystem.Core;
using Xunit;

public class ProductCatalogTests
{
    // =====================================================
    // ADD PRODUCT TESTS
    // =====================================================

    [Fact]
    public void AddProduct_ShouldIncreaseCount()
    {
        var catalog = new ProductCatalog();

        catalog.AddProduct(CreateProduct(1, 25.00m));

        Assert.Equal(1, catalog.Count);
    }

    [Fact]
    public void AddProduct_ShouldAppendProductToEnd()
    {
        Product p2 = CreateProduct(2, 75.00m);
        var catalog = BuildCatalog(CreateProduct(1, 25.00m), p2);

        Assert.Equal(p2, catalog.GetProductDetails(1));
    }

    [Fact]
    public void AddProduct_ShouldAllowMultipleProducts()
    {
        var catalog = BuildCatalog(
            CreateProduct(1, 25.00m),
            CreateProduct(2, 75.00m),
            CreateProduct(3, 300.00m));

        Assert.Equal(3, catalog.Count);
    }

    // =====================================================
    // REMOVE PRODUCT TESTS
    // =====================================================

    [Fact]
    public void RemoveProduct_ShouldRemoveMatchingProduct()
    {
        Product p1 = CreateProduct(1, 25.00m);
        Product p2 = CreateProduct(2, 75.00m);
        var catalog = BuildCatalog(p1, p2);

        bool removed = catalog.RemoveProduct(p1);

        Assert.True(removed);
        Assert.Equal(1, catalog.Count);
        Assert.Equal(p2, catalog.GetProductDetails(0));
    }

    [Fact]
    public void RemoveProduct_ShouldReturnFalse_WhenProductIsMissing()
    {
        var catalog = BuildCatalog(CreateProduct(1, 25.00m));

        bool removed = catalog.RemoveProduct(CreateProduct(99, 999.00m));

        Assert.False(removed);
        Assert.Equal(1, catalog.Count);
    }

    [Fact]
    public void RemoveProduct_ShouldReconnectNodesAfterMiddleRemoval()
    {
        Product p1 = CreateProduct(1, 25.00m);
        Product p2 = CreateProduct(2, 75.00m);
        Product p3 = CreateProduct(3, 300.00m);
        var catalog = BuildCatalog(p1, p2, p3);

        catalog.RemoveProduct(p2);

        Assert.Equal(2, catalog.Count);
        Assert.Equal(p1, catalog.GetProductDetails(0));
        Assert.Equal(p3, catalog.GetProductDetails(1));
    }

    // =====================================================
    // SEARCH PRODUCT TESTS
    // =====================================================

    [Fact]
    public void SearchProduct_ShouldReturnTrue_WhenProductExists()
    {
        Product target = CreateProduct(2, 75.00m);
        var catalog = BuildCatalog(CreateProduct(1, 25.00m), target);

        Assert.True(catalog.SearchProduct(target));
    }

    [Fact]
    public void SearchProduct_ShouldReturnFalse_WhenProductIsMissing()
    {
        var catalog = BuildCatalog(CreateProduct(1, 25.00m));

        Assert.False(
            catalog.SearchProduct(CreateProduct(99, 999.00m)));
    }

    [Fact]
    public void SearchProduct_ShouldNotChangeCatalogCountOrOrder()
    {
        Product p1 = CreateProduct(1, 25.00m);
        Product p2 = CreateProduct(2, 75.00m);
        var catalog = BuildCatalog(p1, p2);

        catalog.SearchProduct(p2);

        Assert.Equal(2, catalog.Count);
        Assert.Equal(p1, catalog.GetProductDetails(0));
    }

    // =====================================================
    // GET PRODUCT DETAILS TESTS
    // =====================================================

    [Fact]
    public void GetProductDetails_ShouldReturnFirstProduct()
    {
        Product p1 = CreateProduct(1, 25.00m);
        var catalog = BuildCatalog(p1, CreateProduct(2, 75.00m));

        Assert.Equal(p1, catalog.GetProductDetails(0));
    }

    [Fact]
    public void GetProductDetails_ShouldReturnProductAtSpecifiedIndex()
    {
        Product p3 = CreateProduct(3, 300.00m);
        var catalog = BuildCatalog(
            CreateProduct(1, 25.00m),
            CreateProduct(2, 75.00m),
            p3);

        Assert.Equal(p3, catalog.GetProductDetails(2));
    }

    [Fact]
    public void GetProductDetails_ShouldThrow_WhenIndexIsInvalid()
    {
        var catalog = new ProductCatalog();

        Assert.Throws<IndexOutOfRangeException>(
            () => catalog.GetProductDetails(0));
    }

    // =====================================================
    // SHOW ALL PROFILES TESTS
    // =====================================================

    [Fact]
    public void ShowAllProfiles_ShouldDisplayEmptyMessage_WhenCatalogIsEmpty()
    {
        var catalog = new ProductCatalog();

        string output = CaptureConsoleOutput(catalog.ShowAllProfiles);

        Assert.Contains("The product catalog is empty.", output);
    }

    [Fact]
    public void ShowAllProfiles_ShouldDisplayEveryProductDetail()
    {
        var catalog = BuildCatalog(
            new Product(201, "Mouse", 25.00m),
            new Product(202, "Keyboard", 75.00m));

        string output = CaptureConsoleOutput(catalog.ShowAllProfiles);

        Assert.Contains("ID: 201", output);
        Assert.Contains("Name: Mouse", output);
        Assert.Contains("Name: Keyboard", output);
        Assert.Contains($"Price: {75.00m:0.00}", output);
    }

    [Fact]
    public void ShowAllProfiles_ShouldNotRemoveProducts()
    {
        var catalog = BuildCatalog(
            CreateProduct(1, 25.00m),
            CreateProduct(2, 75.00m));

        CaptureConsoleOutput(catalog.ShowAllProfiles);

        Assert.Equal(2, catalog.Count);
    }

    // =====================================================
    // SORT CATALOG TESTS
    // =====================================================

    [Fact]
    public void SortCatalog_ShouldOrderProductsAscendingByPrice()
    {
        var catalog = BuildCatalog(
            CreateProduct(1, 300.00m),
            CreateProduct(2, 25.00m),
            CreateProduct(3, 75.00m));

        catalog.SortCatalog();

        Assert.Equal(25.00m, catalog.GetProductDetails(0).Price);
        Assert.Equal(75.00m, catalog.GetProductDetails(1).Price);
        Assert.Equal(300.00m, catalog.GetProductDetails(2).Price);
    }

    [Fact]
    public void SortCatalog_ShouldHandleDuplicatePrices()
    {
        var catalog = BuildCatalog(
            CreateProduct(1, 50.00m),
            CreateProduct(2, 25.00m),
            CreateProduct(3, 50.00m));

        catalog.SortCatalog();

        Assert.Equal(25.00m, catalog.GetProductDetails(0).Price);
        Assert.Equal(50.00m, catalog.GetProductDetails(1).Price);
        Assert.Equal(50.00m, catalog.GetProductDetails(2).Price);
    }

    [Fact]
    public void SortCatalog_ShouldNotChangeCount()
    {
        var catalog = BuildCatalog(
            CreateProduct(1, 300.00m),
            CreateProduct(2, 25.00m),
            CreateProduct(3, 75.00m));

        catalog.SortCatalog();

        Assert.Equal(3, catalog.Count);
    }

    private static ProductCatalog BuildCatalog(params Product[] products)
    {
        var catalog = new ProductCatalog();

        foreach (Product product in products)
        {
            catalog.AddProduct(product);
        }

        return catalog;
    }

    private static Product CreateProduct(int id, decimal price)
    {
        return new Product(id, $"Product{id}", price);
    }

    private static string CaptureConsoleOutput(Action action)
    {
        TextWriter originalOutput = Console.Out;

        using var writer = new StringWriter();

        try
        {
            Console.SetOut(writer);
            action();
            return writer.ToString();
        }
        finally
        {
            Console.SetOut(originalOutput);
        }
    }
}
