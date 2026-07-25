namespace ECommerceSystem.Tests;

using System;
using Xunit;
using ECommerceSystem.Core;

public class ECommerceCoreTests
{
    // =========================================================================
    // 1. ShoppingCart Tests (Integrates CustomArrayList<T>)
    // =========================================================================

    [Fact]
    public void ShoppingCart_AddItem_IncreasesItemCountAndCalculatesTotal()
    {
        var cart = new ShoppingCart();
        var p1 = new Product(101, "Wireless Mouse", 25.50m);
        var p2 = new Product(102, "Mechanical Keyboard", 89.99m);

        cart.AddItem(p1);
        cart.AddItem(p2);

        Assert.Equal(2, cart.Count);
        Assert.Equal(115.49m, cart.CalculateTotal());
    }

    [Fact]
    public void ShoppingCart_SearchItem_ReturnsCorrectIndexInCart()
    {
        var cart = new ShoppingCart();
        var p1 = new Product(101, "USB-C Hub", 15.00m);
        var p2 = new Product(102, "4K Monitor", 350.00m);

        cart.AddItem(p1);
        cart.AddItem(p2);

        int index = cart.SearchItem(p2);

        Assert.Equal(1, index);
    }

    [Fact]
    public void ShoppingCart_SortCartByPrice_OrdersItemsAscending()
    {
        var cart = new ShoppingCart();
        var expensive = new Product(101, "Gaming Laptop", 1500.00m);
        var cheap = new Product(102, "Mousepad", 12.00m);
        var mid = new Product(103, "Headphones", 75.00m);

        cart.AddItem(expensive);
        cart.AddItem(cheap);
        cart.AddItem(mid);

        cart.SortCartByPrice();

        Assert.Equal(cheap, cart.GetItemAt(0));
        Assert.Equal(mid, cart.GetItemAt(1));
        Assert.Equal(expensive, cart.GetItemAt(2));
    }

    // =========================================================================
    // 2. ProductCatalog Tests (Integrates CustomSinglyLinkedList<T>)
    // =========================================================================

    // AddProduct tests
    [Fact]
    public void ProductCatalog_AddProduct_AppendsToCatalog()
    {
        var catalog = new ProductCatalog();
        var product = new Product(201, "Ergonomic Chair", 250.00m);

        catalog.AddProduct(product);

        Assert.Equal(1, catalog.Count);
        Assert.True(catalog.SearchProduct(product));
    }

    [Fact]
    public void ProductCatalog_AddProduct_MultipleProducts()
    {
        var catalog = new ProductCatalog();
        catalog.AddProduct(new Product(1, "P1", 10m));
        catalog.AddProduct(new Product(2, "P2", 20m));
        catalog.AddProduct(new Product(3, "P3", 30m));

        Assert.Equal(3, catalog.Count);
        Assert.Equal("P3", catalog.GetProductDetails(2).Name);
    }

    [Fact]
    public void ProductCatalog_AddProduct_SameProductMultipleTimes()
    {
        var catalog = new ProductCatalog();
        var p = new Product(1, "Test", 10m);
        catalog.AddProduct(p);
        catalog.AddProduct(p);

        Assert.Equal(2, catalog.Count);
    }

    // RemoveProduct tests
    [Fact]
    public void ProductCatalog_RemoveProduct_UpdatesCatalogStructure()
    {
        var catalog = new ProductCatalog();
        var p1 = new Product(201, "Standing Desk", 400.00m);
        var p2 = new Product(202, "Monitor Arm", 60.00m);

        catalog.AddProduct(p1);
        catalog.AddProduct(p2);

        bool removed = catalog.RemoveProduct(p1);

        Assert.True(removed);
        Assert.Equal(1, catalog.Count);
        Assert.False(catalog.SearchProduct(p1));
    }

    [Fact]
    public void ProductCatalog_RemoveProduct_NonExistentProduct()
    {
        var catalog = new ProductCatalog();
        var p1 = new Product(1, "A", 10m);
        var p2 = new Product(2, "B", 20m);
        catalog.AddProduct(p1);

        bool removed = catalog.RemoveProduct(p2);

        Assert.False(removed);
        Assert.Equal(1, catalog.Count);
    }

    [Fact]
    public void ProductCatalog_RemoveProduct_FromEmptyCatalog()
    {
        var catalog = new ProductCatalog();
        var p = new Product(1, "A", 10m);

        bool removed = catalog.RemoveProduct(p);

        Assert.False(removed);
        Assert.Equal(0, catalog.Count);
    }

    // SearchProduct tests
    [Fact]
    public void ProductCatalog_SearchProduct_ReturnsTrueIfExists()
    {
        var catalog = new ProductCatalog();
        var p = new Product(1, "Test", 10m);
        catalog.AddProduct(p);
        Assert.True(catalog.SearchProduct(p));
    }

    [Fact]
    public void ProductCatalog_SearchProduct_ReturnsFalseIfNotExists()
    {
        var catalog = new ProductCatalog();
        var p1 = new Product(1, "A", 10m);
        var p2 = new Product(2, "B", 20m);
        catalog.AddProduct(p1);
        Assert.False(catalog.SearchProduct(p2));
    }

    [Fact]
    public void ProductCatalog_SearchProduct_EmptyCatalog()
    {
        var catalog = new ProductCatalog();
        var p = new Product(1, "A", 10m);
        Assert.False(catalog.SearchProduct(p));
    }

    // SortCatalog tests
    [Fact]
    public void ProductCatalog_SortCatalog_OrdersProductsByPriceAscending()
    {
        var catalog = new ProductCatalog();
        var p1 = new Product(201, "Desk Lamp", 45.00m);
        var p2 = new Product(202, "Webcam", 80.00m);
        var p3 = new Product(203, "Cable Organizer", 8.00m);

        catalog.AddProduct(p1);
        catalog.AddProduct(p2);
        catalog.AddProduct(p3);

        catalog.SortCatalog();

        Assert.Equal(p3, catalog.GetProductDetails(0));
        Assert.Equal(p1, catalog.GetProductDetails(1));
        Assert.Equal(p2, catalog.GetProductDetails(2));
    }

    [Fact]
    public void ProductCatalog_SortCatalog_AlreadySorted()
    {
        var catalog = new ProductCatalog();
        var p1 = new Product(1, "A", 10m);
        var p2 = new Product(2, "B", 20m);

        catalog.AddProduct(p1);
        catalog.AddProduct(p2);

        catalog.SortCatalog();

        Assert.Equal(p1, catalog.GetProductDetails(0));
        Assert.Equal(p2, catalog.GetProductDetails(1));
    }

    [Fact]
    public void ProductCatalog_SortCatalog_EmptyCatalog()
    {
        var catalog = new ProductCatalog();
        catalog.SortCatalog();
        Assert.Equal(0, catalog.Count);
    }

    // GetProductDetails tests
    [Fact]
    public void ProductCatalog_GetProductDetails_ValidIndex()
    {
        var catalog = new ProductCatalog();
        var p1 = new Product(1, "A", 10m);
        catalog.AddProduct(p1);
        Assert.Equal(p1, catalog.GetProductDetails(0));
    }

    [Fact]
    public void ProductCatalog_GetProductDetails_NegativeIndexThrows()
    {
        var catalog = new ProductCatalog();
        catalog.AddProduct(new Product(1, "A", 10m));
        Assert.Throws<System.ArgumentOutOfRangeException>(() => catalog.GetProductDetails(-1));
    }

    [Fact]
    public void ProductCatalog_GetProductDetails_OutOfBoundsThrows()
    {
        var catalog = new ProductCatalog();
        catalog.AddProduct(new Product(1, "A", 10m));
        Assert.Throws<System.ArgumentOutOfRangeException>(() => catalog.GetProductDetails(1));
    }

    // ShowAllProfiles tests
    [Fact]
    public void ProductCatalog_ShowAllProfiles_PrintsToConsole()
    {
        var catalog = new ProductCatalog();
        var p1 = new Product(1, "A", 10m);
        catalog.AddProduct(p1);
        
        using var sw = new System.IO.StringWriter();
        Console.SetOut(sw);
        
        catalog.ShowAllProfiles();
        
        var output = sw.ToString().Trim();
        Assert.Contains("ECommerceSystem.Core.Product", output);
        
        var standardOutput = new System.IO.StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
    }

    [Fact]
    public void ProductCatalog_ShowAllProfiles_EmptyCatalog()
    {
        var catalog = new ProductCatalog();
        
        using var sw = new System.IO.StringWriter();
        Console.SetOut(sw);
        
        catalog.ShowAllProfiles();
        
        var output = sw.ToString();
        Assert.Empty(output);
        
        var standardOutput = new System.IO.StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
    }

    [Fact]
    public void ProductCatalog_ShowAllProfiles_MultipleProfiles()
    {
        var catalog = new ProductCatalog();
        catalog.AddProduct(new Product(1, "A", 10m));
        catalog.AddProduct(new Product(2, "B", 20m));
        
        using var sw = new System.IO.StringWriter();
        sw.NewLine = "\n";
        Console.SetOut(sw);
        
        catalog.ShowAllProfiles();
        
        var output = sw.ToString().Trim();
        Assert.Equal("ECommerceSystem.Core.Product\nECommerceSystem.Core.Product", output.Replace("\r\n", "\n"));
        
        var standardOutput = new System.IO.StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
    }

    // =========================================================================
    // 3. OrderProcessingQueue Tests (Integrates CustomQueue<T>)
    // =========================================================================

    [Fact]
    public void OrderProcessingQueue_EnqueueAndProcess_MaintainsFIFOOrder()
    {
        var queue = new OrderProcessingQueue();
        var o1 = new Order(1001, "Customer A", 120.00m);
        var o2 = new Order(1002, "Customer B", 45.00m);

        queue.EnqueueOrder(o1);
        queue.EnqueueOrder(o2);

        Assert.Equal(2, queue.Count);
        Assert.Equal(o1, queue.ProcessNextOrder());
        Assert.Equal(1, queue.Count);
        Assert.Equal(o2, queue.ProcessNextOrder());
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void OrderProcessingQueue_SearchOrder_FindsOrderWithoutModifyingQueue()
    {
        var queue = new OrderProcessingQueue();
        var o1 = new Order(1001, "Customer A", 120.00m);
        var o2 = new Order(1002, "Customer B", 45.00m);

        queue.EnqueueOrder(o1);
        queue.EnqueueOrder(o2);

        bool found = queue.SearchOrder(o2);

        Assert.True(found);
        Assert.Equal(2, queue.Count);
        Assert.Equal(o1, queue.PeekNextOrder());
    }

    [Fact]
    public void OrderProcessingQueue_SortOrders_OrdersByTotalAmountAscending()
    {
        var queue = new OrderProcessingQueue();
        var largeOrder = new Order(1001, "Bulk Client", 900.00m);
        var smallOrder = new Order(1002, "Retail Client", 30.00m);
        var midOrder = new Order(1003, "Standard Client", 250.00m);

        queue.EnqueueOrder(largeOrder);
        queue.EnqueueOrder(smallOrder);
        queue.EnqueueOrder(midOrder);

        queue.SortOrders();

        Assert.Equal(smallOrder, queue.ProcessNextOrder());
        Assert.Equal(midOrder, queue.ProcessNextOrder());
        Assert.Equal(largeOrder, queue.ProcessNextOrder());
    }

    // =========================================================================
    // 4. ReturnHistoryStack Tests (Integrates CustomStack<T>)
    // =========================================================================

    [Fact]
    public void ReturnHistoryStack_PushAndPop_MaintainsLIFOOrder()
    {
        var stack = new ReturnHistoryStack();
        var r1 = new ReturnRequest(501, 1001, "Defective item");
        var r2 = new ReturnRequest(502, 1002, "Unopened wrong item");

        stack.PushReturn(r1);
        stack.PushReturn(r2);

        Assert.Equal(2, stack.Count);
        Assert.Equal(r2, stack.PopReturn());
        Assert.Equal(1, stack.Count);
        Assert.Equal(r1, stack.PopReturn());
    }

    [Fact]
    public void ReturnHistoryStack_SearchReturn_ReturnsDepthFromTop()
    {
        var stack = new ReturnHistoryStack();
        var r1 = new ReturnRequest(501, 1001, "Defective item");
        var r2 = new ReturnRequest(502, 1002, "Wrong size");
        var r3 = new ReturnRequest(503, 1003, "Damaged in transit");

        stack.PushReturn(r1);
        stack.PushReturn(r2);
        stack.PushReturn(r3);

        int topDepth = stack.SearchReturn(r3);
        int bottomDepth = stack.SearchReturn(r1);

        Assert.Equal(1, topDepth);
        Assert.Equal(3, bottomDepth);
    }

    [Fact]
    public void ReturnHistoryStack_SortReturns_ReordersStackByReturnIdAscending()
    {
        var stack = new ReturnHistoryStack();
        var r1 = new ReturnRequest(503, 1001, "Reason A");
        var r2 = new ReturnRequest(501, 1002, "Reason B");
        var r3 = new ReturnRequest(502, 1003, "Reason C");

        stack.PushReturn(r1);
        stack.PushReturn(r2);
        stack.PushReturn(r3);

        stack.SortReturns();

        Assert.Equal(501, stack.PeekLatestReturn().ReturnId);
    }
}