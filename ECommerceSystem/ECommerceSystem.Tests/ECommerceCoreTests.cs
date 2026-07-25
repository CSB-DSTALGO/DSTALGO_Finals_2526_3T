namespace ECommerceSystem.Tests;

using System;
using System.IO;
using ECommerceSystem.Core;
using Xunit;

public class ECommerceCoreTests
{
    private static readonly object ConsoleOutputLock = new();

    // =========================================================================
    // 1. SHOPPING CART TESTS
    // =========================================================================

    [Fact]
    public void ShoppingCart_AddItem_IncreasesItemCountAndCalculatesTotal()
    {
        var cart = new ShoppingCart();

        var p1 = new Product(
            101,
            "Wireless Mouse",
            25.50m);

        var p2 = new Product(
            102,
            "Mechanical Keyboard",
            89.99m);

        cart.AddItem(p1);
        cart.AddItem(p2);

        Assert.Equal(2, cart.Count);
        Assert.Equal(115.49m, cart.CalculateTotal());
    }

    [Fact]
    public void ShoppingCart_SearchItem_ReturnsCorrectIndexInCart()
    {
        var cart = new ShoppingCart();

        var p1 = new Product(
            101,
            "USB-C Hub",
            15.00m);

        var p2 = new Product(
            102,
            "4K Monitor",
            350.00m);

        cart.AddItem(p1);
        cart.AddItem(p2);

        int index = cart.SearchItem(p2);

        Assert.Equal(1, index);
    }

    [Fact]
    public void ShoppingCart_SortCartByPrice_OrdersItemsAscending()
    {
        var cart = new ShoppingCart();

        var expensive = new Product(
            101,
            "Gaming Laptop",
            1500.00m);

        var cheap = new Product(
            102,
            "Mousepad",
            12.00m);

        var mid = new Product(
            103,
            "Headphones",
            75.00m);

        cart.AddItem(expensive);
        cart.AddItem(cheap);
        cart.AddItem(mid);

        cart.SortCartByPrice();

        Assert.Equal(cheap, cart.GetItemAt(0));
        Assert.Equal(mid, cart.GetItemAt(1));
        Assert.Equal(expensive, cart.GetItemAt(2));
    }

    // =========================================================================
    // REMOVE ITEM BY INDEX TESTS
    // =========================================================================

    [Fact]
    public void ShoppingCart_RemoveItemByIndex_RemovesSelectedProduct()
    {
        var cart = new ShoppingCart();

        var p1 = new Product(
            101,
            "Mouse",
            25.00m);

        var p2 = new Product(
            102,
            "Keyboard",
            75.00m);

        cart.AddItem(p1);
        cart.AddItem(p2);

        cart.RemoveItem(0);

        Assert.Equal(1, cart.Count);
        Assert.Equal(p2, cart.GetItemAt(0));
    }

    [Fact]
    public void ShoppingCart_RemoveItemByIndex_ShiftsRemainingProducts()
    {
        var cart = new ShoppingCart();

        var p1 = new Product(
            101,
            "Mouse",
            25.00m);

        var p2 = new Product(
            102,
            "Keyboard",
            75.00m);

        var p3 = new Product(
            103,
            "Monitor",
            300.00m);

        cart.AddItem(p1);
        cart.AddItem(p2);
        cart.AddItem(p3);

        cart.RemoveItem(1);

        Assert.Equal(2, cart.Count);
        Assert.Equal(p1, cart.GetItemAt(0));
        Assert.Equal(p3, cart.GetItemAt(1));
    }

    [Fact]
    public void ShoppingCart_RemoveItemByIndex_UpdatesTotalPrice()
    {
        var cart = new ShoppingCart();

        var p1 = new Product(
            101,
            "Mouse",
            25.00m);

        var p2 = new Product(
            102,
            "Keyboard",
            75.00m);

        cart.AddItem(p1);
        cart.AddItem(p2);

        cart.RemoveItem(1);

        Assert.Equal(25.00m, cart.CalculateTotal());
    }

    // =========================================================================
    // SHOW ALL ITEMS TESTS
    // =========================================================================

    [Fact]
    public void ShoppingCart_ShowAllItems_DisplaysEmptyMessage()
    {
        var cart = new ShoppingCart();

        string output = CaptureConsoleOutput(
            cart.ShowAllItems);

        Assert.Contains(
            "The shopping cart is empty.",
            output);
    }

    [Fact]
    public void ShoppingCart_ShowAllItems_DisplaysProduct()
    {
        var cart = new ShoppingCart();

        var product = new Product(
            101,
            "Wireless Mouse",
            25.50m);

        cart.AddItem(product);

        string output = CaptureConsoleOutput(
            cart.ShowAllItems);

        Assert.Contains(
            product.Name,
            output);
    }

    [Fact]
    public void ShoppingCart_ShowAllItems_DoesNotRemoveProducts()
    {
        var cart = new ShoppingCart();

        var p1 = new Product(
            101,
            "Mouse",
            25.00m);

        var p2 = new Product(
            102,
            "Keyboard",
            75.00m);

        cart.AddItem(p1);
        cart.AddItem(p2);

        string output = CaptureConsoleOutput(
            cart.ShowAllItems);

        Assert.Contains(p1.Name, output);
        Assert.Contains(p2.Name, output);
        Assert.Equal(2, cart.Count);
    }

    // =========================================================================
    // 2. PRODUCT CATALOG TESTS
    // =========================================================================

    [Fact]
    public void ProductCatalog_AddProduct_AppendsToCatalog()
    {
        var catalog = new ProductCatalog();

        var product = new Product(
            201,
            "Ergonomic Chair",
            250.00m);

        catalog.AddProduct(product);

        Assert.Equal(1, catalog.Count);
        Assert.True(catalog.SearchProduct(product));
    }

    [Fact]
    public void ProductCatalog_RemoveProduct_UpdatesCatalogStructure()
    {
        var catalog = new ProductCatalog();

        var p1 = new Product(
            201,
            "Standing Desk",
            400.00m);

        var p2 = new Product(
            202,
            "Monitor Arm",
            60.00m);

        catalog.AddProduct(p1);
        catalog.AddProduct(p2);

        bool removed = catalog.RemoveProduct(p1);

        Assert.True(removed);
        Assert.Equal(1, catalog.Count);
        Assert.False(catalog.SearchProduct(p1));
    }

    [Fact]
    public void ProductCatalog_SortCatalog_OrdersProductsByPriceAscending()
    {
        var catalog = new ProductCatalog();

        var p1 = new Product(
            201,
            "Desk Lamp",
            45.00m);

        var p2 = new Product(
            202,
            "Webcam",
            80.00m);

        var p3 = new Product(
            203,
            "Cable Organizer",
            8.00m);

        catalog.AddProduct(p1);
        catalog.AddProduct(p2);
        catalog.AddProduct(p3);

        catalog.SortCatalog();

        Assert.True(catalog.SearchProduct(p3));
        Assert.Equal(3, catalog.Count);
    }

    // =========================================================================
    // GET PRODUCT DETAILS TESTS
    // =========================================================================

    [Fact]
    public void ProductCatalog_GetProductDetails_ReturnsFirstProduct()
    {
        var catalog = new ProductCatalog();

        var p1 = new Product(
            201,
            "Mouse",
            25.00m);

        var p2 = new Product(
            202,
            "Keyboard",
            75.00m);

        catalog.AddProduct(p1);
        catalog.AddProduct(p2);

        Product result = catalog.GetProductDetails(0);

        Assert.Equal(p1, result);
    }

    [Fact]
    public void ProductCatalog_GetProductDetails_ReturnsCorrectProduct()
    {
        var catalog = new ProductCatalog();

        var p1 = new Product(
            201,
            "Mouse",
            25.00m);

        var p2 = new Product(
            202,
            "Keyboard",
            75.00m);

        var p3 = new Product(
            203,
            "Monitor",
            300.00m);

        catalog.AddProduct(p1);
        catalog.AddProduct(p2);
        catalog.AddProduct(p3);

        Product result = catalog.GetProductDetails(2);

        Assert.Equal(p3, result);
    }

    [Fact]
    public void ProductCatalog_GetProductDetails_ThrowsForInvalidIndex()
    {
        var catalog = new ProductCatalog();

        catalog.AddProduct(
            new Product(
                201,
                "Mouse",
                25.00m));

        Assert.Throws<IndexOutOfRangeException>(
            () => catalog.GetProductDetails(1));
    }

    // =========================================================================
    // SHOW ALL PROFILES TESTS
    // =========================================================================

    [Fact]
    public void ProductCatalog_ShowAllProfiles_DisplaysEmptyMessage()
    {
        var catalog = new ProductCatalog();

        string output = CaptureConsoleOutput(
            catalog.ShowAllProfiles);

        Assert.Contains(
            "The product catalog is empty.",
            output);
    }

    [Fact]
    public void ProductCatalog_ShowAllProfiles_DisplaysProduct()
    {
        var catalog = new ProductCatalog();

        var product = new Product(
            201,
            "Ergonomic Chair",
            250.00m);

        catalog.AddProduct(product);

        string output = CaptureConsoleOutput(
            catalog.ShowAllProfiles);

        Assert.Contains(
            product.Name,
            output);
    }

    [Fact]
    public void ProductCatalog_ShowAllProfiles_DoesNotRemoveProducts()
    {
        var catalog = new ProductCatalog();

        var p1 = new Product(
            201,
            "Mouse",
            25.00m);

        var p2 = new Product(
            202,
            "Keyboard",
            75.00m);

        catalog.AddProduct(p1);
        catalog.AddProduct(p2);

        string output = CaptureConsoleOutput(
            catalog.ShowAllProfiles);

        Assert.Contains(p1.Name, output);
        Assert.Contains(p2.Name, output);
        Assert.Equal(2, catalog.Count);
    }

    // =========================================================================
    // 3. ORDER PROCESSING QUEUE TESTS
    // =========================================================================

    [Fact]
    public void OrderProcessingQueue_EnqueueAndProcess_MaintainsFIFOOrder()
    {
        var queue = new OrderProcessingQueue();

        var o1 = new Order(
            1001,
            "Customer A",
            120.00m);

        var o2 = new Order(
            1002,
            "Customer B",
            45.00m);

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

        var o1 = new Order(
            1001,
            "Customer A",
            120.00m);

        var o2 = new Order(
            1002,
            "Customer B",
            45.00m);

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

        var largeOrder = new Order(
            1001,
            "Bulk Client",
            900.00m);

        var smallOrder = new Order(
            1002,
            "Retail Client",
            30.00m);

        var midOrder = new Order(
            1003,
            "Standard Client",
            250.00m);

        queue.EnqueueOrder(largeOrder);
        queue.EnqueueOrder(smallOrder);
        queue.EnqueueOrder(midOrder);

        queue.SortOrders();

        Assert.Equal(
            smallOrder,
            queue.ProcessNextOrder());

        Assert.Equal(
            midOrder,
            queue.ProcessNextOrder());

        Assert.Equal(
            largeOrder,
            queue.ProcessNextOrder());
    }

    // =========================================================================
    // 4. RETURN HISTORY STACK TESTS
    // =========================================================================

    [Fact]
    public void ReturnHistoryStack_PushAndPop_MaintainsLIFOOrder()
    {
        var stack = new ReturnHistoryStack();

        var r1 = new ReturnRequest(
            501,
            1001,
            "Defective item");

        var r2 = new ReturnRequest(
            502,
            1002,
            "Unopened wrong item");

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

        var r1 = new ReturnRequest(
            501,
            1001,
            "Defective item");

        var r2 = new ReturnRequest(
            502,
            1002,
            "Wrong size");

        var r3 = new ReturnRequest(
            503,
            1003,
            "Damaged in transit");

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

        var r1 = new ReturnRequest(
            503,
            1001,
            "Reason A");

        var r2 = new ReturnRequest(
            501,
            1002,
            "Reason B");

        var r3 = new ReturnRequest(
            502,
            1003,
            "Reason C");

        stack.PushReturn(r1);
        stack.PushReturn(r2);
        stack.PushReturn(r3);

        stack.SortReturns();

        Assert.Equal(
            501,
            stack.PeekLatestReturn().ReturnId);
    }

    private static string CaptureConsoleOutput(
        Action action)
    {
        lock (ConsoleOutputLock)
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
}