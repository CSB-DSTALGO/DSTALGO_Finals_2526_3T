namespace ECommerceSystem.Tests;

using System;
using System.IO;
using ECommerceSystem.Core;
using Xunit;

public class ShoppingCartTests
{
    // =====================================================
    // ADD ITEM TESTS
    // =====================================================

    [Fact]
    public void AddItem_ShouldIncreaseCount()
    {
        var cart = new ShoppingCart();

        cart.AddItem(CreateProduct(1, 25.00m));

        Assert.Equal(1, cart.Count);
    }

    [Fact]
    public void AddItem_ShouldStoreProductAtEnd()
    {
        var cart = BuildCart(
            CreateProduct(1, 25.00m),
            CreateProduct(2, 75.00m));

        Assert.Equal(2, cart.GetItemAt(1).Id);
    }

    [Fact]
    public void AddItem_ShouldAllowMultipleProducts()
    {
        var cart = BuildCart(
            CreateProduct(1, 25.00m),
            CreateProduct(2, 75.00m),
            CreateProduct(3, 300.00m));

        Assert.Equal(3, cart.Count);
    }

    // =====================================================
    // REMOVE ITEM BY PRODUCT TESTS
    // =====================================================

    [Fact]
    public void RemoveItemByProduct_ShouldRemoveMatchingProduct()
    {
        Product p1 = CreateProduct(1, 25.00m);
        Product p2 = CreateProduct(2, 75.00m);
        var cart = BuildCart(p1, p2);

        bool removed = cart.RemoveItem(p1);

        Assert.True(removed);
        Assert.Equal(1, cart.Count);
        Assert.Equal(p2, cart.GetItemAt(0));
    }

    [Fact]
    public void RemoveItemByProduct_ShouldReturnFalse_WhenProductIsMissing()
    {
        var cart = BuildCart(CreateProduct(1, 25.00m));

        bool removed = cart.RemoveItem(CreateProduct(99, 999.00m));

        Assert.False(removed);
        Assert.Equal(1, cart.Count);
    }

    [Fact]
    public void RemoveItemByProduct_ShouldRemoveFirstMatchingProduct()
    {
        Product p1 = CreateProduct(1, 25.00m);
        Product p2 = CreateProduct(2, 25.00m);
        Product p3 = CreateProduct(3, 75.00m);
        var cart = BuildCart(p1, p2, p3);

        cart.RemoveItem(new Product(99, "Same Price", 25.00m));

        Assert.Equal(2, cart.Count);
        Assert.Equal(p2, cart.GetItemAt(0));
        Assert.Equal(p3, cart.GetItemAt(1));
    }

    // =====================================================
    // REMOVE ITEM BY INDEX TESTS
    // =====================================================

    [Fact]
    public void RemoveItemByIndex_ShouldRemoveSelectedProduct()
    {
        Product p1 = CreateProduct(1, 25.00m);
        Product p2 = CreateProduct(2, 75.00m);
        var cart = BuildCart(p1, p2);

        cart.RemoveItem(0);

        Assert.Equal(1, cart.Count);
        Assert.Equal(p2, cart.GetItemAt(0));
    }

    [Fact]
    public void RemoveItemByIndex_ShouldShiftLaterProductsLeft()
    {
        Product p1 = CreateProduct(1, 25.00m);
        Product p2 = CreateProduct(2, 75.00m);
        Product p3 = CreateProduct(3, 300.00m);
        var cart = BuildCart(p1, p2, p3);

        cart.RemoveItem(1);

        Assert.Equal(p1, cart.GetItemAt(0));
        Assert.Equal(p3, cart.GetItemAt(1));
    }

    [Fact]
    public void RemoveItemByIndex_ShouldThrow_WhenIndexIsInvalid()
    {
        var cart = BuildCart(CreateProduct(1, 25.00m));

        Assert.Throws<ArgumentOutOfRangeException>(
            () => cart.RemoveItem(1));
    }

    // =====================================================
    // GET ITEM AT TESTS
    // =====================================================

    [Fact]
    public void GetItemAt_ShouldReturnFirstProduct()
    {
        Product p1 = CreateProduct(1, 25.00m);
        var cart = BuildCart(p1, CreateProduct(2, 75.00m));

        Assert.Equal(p1, cart.GetItemAt(0));
    }

    [Fact]
    public void GetItemAt_ShouldReturnProductAtSpecifiedIndex()
    {
        Product p3 = CreateProduct(3, 300.00m);
        var cart = BuildCart(
            CreateProduct(1, 25.00m),
            CreateProduct(2, 75.00m),
            p3);

        Assert.Equal(p3, cart.GetItemAt(2));
    }

    [Fact]
    public void GetItemAt_ShouldThrow_WhenIndexIsInvalid()
    {
        var cart = new ShoppingCart();

        Assert.Throws<ArgumentOutOfRangeException>(
            () => cart.GetItemAt(0));
    }

    // =====================================================
    // SHOW ALL ITEMS TESTS
    // =====================================================

    [Fact]
    public void ShowAllItems_ShouldDisplayEmptyMessage_WhenCartIsEmpty()
    {
        var cart = new ShoppingCart();

        string output = CaptureConsoleOutput(cart.ShowAllItems);

        Assert.Contains("The shopping cart is empty.", output);
    }

    [Fact]
    public void ShowAllItems_ShouldDisplayEveryProductDetail()
    {
        var cart = BuildCart(
            new Product(101, "Mouse", 25.00m),
            new Product(102, "Keyboard", 75.00m));

        string output = CaptureConsoleOutput(cart.ShowAllItems);

        Assert.Contains("ID: 101", output);
        Assert.Contains("Name: Mouse", output);
        Assert.Contains("Name: Keyboard", output);
        Assert.Contains($"Price: {75.00m:0.00}", output);
    }

    [Fact]
    public void ShowAllItems_ShouldNotRemoveProducts()
    {
        var cart = BuildCart(
            CreateProduct(1, 25.00m),
            CreateProduct(2, 75.00m));

        CaptureConsoleOutput(cart.ShowAllItems);

        Assert.Equal(2, cart.Count);
    }

    // =====================================================
    // CALCULATE TOTAL TESTS
    // =====================================================

    [Fact]
    public void CalculateTotal_ShouldReturnZero_WhenCartIsEmpty()
    {
        var cart = new ShoppingCart();

        Assert.Equal(0m, cart.CalculateTotal());
    }

    [Fact]
    public void CalculateTotal_ShouldSumAllProductPrices()
    {
        var cart = BuildCart(
            CreateProduct(1, 25.50m),
            CreateProduct(2, 74.50m));

        Assert.Equal(100.00m, cart.CalculateTotal());
    }

    [Fact]
    public void CalculateTotal_ShouldUpdateAfterRemoval()
    {
        var cart = BuildCart(
            CreateProduct(1, 25.00m),
            CreateProduct(2, 75.00m));

        cart.RemoveItem(1);

        Assert.Equal(25.00m, cart.CalculateTotal());
    }

    // =====================================================
    // SEARCH ITEM TESTS
    // =====================================================

    [Fact]
    public void SearchItem_ShouldReturnCorrectIndex_WhenProductExists()
    {
        Product target = CreateProduct(2, 75.00m);
        var cart = BuildCart(CreateProduct(1, 25.00m), target);

        Assert.Equal(1, cart.SearchItem(target));
    }

    [Fact]
    public void SearchItem_ShouldReturnMinusOne_WhenProductIsMissing()
    {
        var cart = BuildCart(CreateProduct(1, 25.00m));

        Assert.Equal(
            -1,
            cart.SearchItem(CreateProduct(99, 999.00m)));
    }

    [Fact]
    public void SearchItem_ShouldReturnFirstIndex_WhenEqualPricesExist()
    {
        var cart = BuildCart(
            CreateProduct(1, 25.00m),
            CreateProduct(2, 25.00m),
            CreateProduct(3, 75.00m));

        Assert.Equal(
            0,
            cart.SearchItem(new Product(99, "Same Price", 25.00m)));
    }

    // =====================================================
    // SORT CART TESTS
    // =====================================================

    [Fact]
    public void SortCartByPrice_ShouldOrderProductsAscending()
    {
        var cart = BuildCart(
            CreateProduct(1, 300.00m),
            CreateProduct(2, 25.00m),
            CreateProduct(3, 75.00m));

        cart.SortCartByPrice();

        Assert.Equal(25.00m, cart.GetItemAt(0).Price);
        Assert.Equal(75.00m, cart.GetItemAt(1).Price);
        Assert.Equal(300.00m, cart.GetItemAt(2).Price);
    }

    [Fact]
    public void SortCartByPrice_ShouldHandleDuplicatePrices()
    {
        var cart = BuildCart(
            CreateProduct(1, 50.00m),
            CreateProduct(2, 25.00m),
            CreateProduct(3, 50.00m));

        cart.SortCartByPrice();

        Assert.Equal(25.00m, cart.GetItemAt(0).Price);
        Assert.Equal(50.00m, cart.GetItemAt(1).Price);
        Assert.Equal(50.00m, cart.GetItemAt(2).Price);
    }

    [Fact]
    public void SortCartByPrice_ShouldNotChangeCount()
    {
        var cart = BuildCart(
            CreateProduct(1, 300.00m),
            CreateProduct(2, 25.00m),
            CreateProduct(3, 75.00m));

        cart.SortCartByPrice();

        Assert.Equal(3, cart.Count);
    }

    private static ShoppingCart BuildCart(params Product[] products)
    {
        var cart = new ShoppingCart();

        foreach (Product product in products)
        {
            cart.AddItem(product);
        }

        return cart;
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
