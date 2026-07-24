// 12521269 Joaquin Bryan G. Ross
namespace ECommerceSystem.Tests;

using System;
using Xunit;
using ECommerceSystem.Core;

public class ECommerceCoreTests
{
    // =========================================================================
    // 1. ShoppingCart Tests (Integrates CustomArrayList<T>)
    // =========================================================================

    // --- AddItem ---

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
    public void ShoppingCart_AddItem_AllowsTheSameProductTwice()
    {
        var cart = new ShoppingCart();
        var product = new Product(101, "AA Batteries", 5.00m);

        cart.AddItem(product);
        cart.AddItem(product);

        Assert.Equal(2, cart.Count);
        Assert.Equal(10.00m, cart.CalculateTotal());
    }

    [Fact]
    public void ShoppingCart_AddItem_PreservesItems_WhenCartGrowsPastInitialCapacity()
    {
        // The array list starts with four slots, so a ten-item cart forces a resize.
        var cart = new ShoppingCart();

        for (int i = 0; i < 10; i++)
        {
            cart.AddItem(new Product(i, $"Item {i}", 1.00m));
        }

        Assert.Equal(10, cart.Count);
        Assert.Equal(10.00m, cart.CalculateTotal());
    }

    // --- RemoveItem ---

    [Fact]
    public void ShoppingCart_RemoveItem_RemovesByIndexAndShrinksTheCart()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new Product(101, "Laptop Sleeve", 30.00m));

        bool removed = cart.RemoveItem(0);

        Assert.True(removed);
        Assert.Equal(0, cart.Count);
    }

    [Fact]
    public void ShoppingCart_RemoveItem_ShiftsLaterItemsDownOneIndex()
    {
        var cart = new ShoppingCart();
        var first = new Product(101, "Cable", 10.00m);
        var middle = new Product(102, "Adapter", 20.00m);
        var last = new Product(103, "Dock", 30.00m);
        cart.AddItem(first);
        cart.AddItem(middle);
        cart.AddItem(last);

        cart.RemoveItem(1);

        Assert.Equal(first, cart.GetItemAt(0));
        Assert.Equal(last, cart.GetItemAt(1)); // slid down from index 2
    }

    [Fact]
    public void ShoppingCart_RemoveItem_ReturnsFalse_WhenIndexIsOutsideTheCart()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new Product(101, "Laptop Sleeve", 30.00m));

        Assert.False(cart.RemoveItem(5));
        Assert.False(cart.RemoveItem(-1));
        Assert.Equal(1, cart.Count);
    }

    // --- GetItemAt ---

    [Fact]
    public void ShoppingCart_GetItemAt_ReturnsTheProductAtThatPosition()
    {
        var cart = new ShoppingCart();
        var first = new Product(101, "Cable", 10.00m);
        var second = new Product(102, "Adapter", 20.00m);
        cart.AddItem(first);
        cart.AddItem(second);

        Assert.Equal(second, cart.GetItemAt(1));
    }

    [Fact]
    public void ShoppingCart_GetItemAt_Throws_WhenIndexIsNegative()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new Product(101, "Cable", 10.00m));

        Assert.Throws<ArgumentOutOfRangeException>(() => cart.GetItemAt(-1));
    }

    [Fact]
    public void ShoppingCart_GetItemAt_Throws_WhenIndexIsBeyondTheLastItem()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new Product(101, "Cable", 10.00m));

        Assert.Throws<ArgumentOutOfRangeException>(() => cart.GetItemAt(1));
    }

    // --- ShowAllItems ---

    [Fact]
    public void ShoppingCart_ShowAllItems_WritesOneLinePerItem()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new Product(101, "Cable", 10.00m));
        cart.AddItem(new Product(102, "Adapter", 20.00m));

        string output = CaptureConsole(cart.ShowAllItems);

        Assert.Contains("Cable", output);
        Assert.Contains("Adapter", output);
        Assert.Equal(2, CountLines(output));
    }

    [Fact]
    public void ShoppingCart_ShowAllItems_ReportsAnEmptyCart()
    {
        var cart = new ShoppingCart();

        string output = CaptureConsole(cart.ShowAllItems);

        Assert.Contains("empty", output, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void ShoppingCart_ShowAllItems_ListsItemsInCartOrder()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new Product(101, "Expensive", 500.00m));
        cart.AddItem(new Product(102, "Cheap", 5.00m));

        cart.SortCartByPrice();
        string output = CaptureConsole(cart.ShowAllItems);

        Assert.True(output.IndexOf("Cheap", StringComparison.Ordinal)
                  < output.IndexOf("Expensive", StringComparison.Ordinal));
    }

    // --- CalculateTotal ---

    [Fact]
    public void ShoppingCart_CalculateTotal_ReturnsZero_ForAnEmptyCart()
    {
        var cart = new ShoppingCart();

        Assert.Equal(0m, cart.CalculateTotal());
    }

    [Fact]
    public void ShoppingCart_CalculateTotal_DropsThePriceOfRemovedItems()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new Product(101, "Keyboard", 89.99m));
        cart.AddItem(new Product(102, "Mouse", 25.50m));

        cart.RemoveItem(1);

        Assert.Equal(89.99m, cart.CalculateTotal());
    }

    [Fact]
    public void ShoppingCart_CalculateTotal_IsUnaffectedBySorting()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new Product(101, "Monitor", 350.00m));
        cart.AddItem(new Product(102, "Mousepad", 12.00m));

        decimal beforeSort = cart.CalculateTotal();
        cart.SortCartByPrice();

        Assert.Equal(beforeSort, cart.CalculateTotal());
    }

    // --- SearchItem ---

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
    public void ShoppingCart_SearchItem_ReturnsMinusOne_WhenProductIsAbsent()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new Product(101, "USB-C Hub", 15.00m));

        Assert.Equal(-1, cart.SearchItem(new Product(999, "Absent", 1.00m)));
    }

    [Fact]
    public void ShoppingCart_SearchItem_ReportsTheNewIndex_AfterSorting()
    {
        var cart = new ShoppingCart();
        var expensive = new Product(101, "Gaming Laptop", 1500.00m);
        var cheap = new Product(102, "Mousepad", 12.00m);
        cart.AddItem(expensive);
        cart.AddItem(cheap);

        cart.SortCartByPrice();

        Assert.Equal(0, cart.SearchItem(cheap));
        Assert.Equal(1, cart.SearchItem(expensive));
    }

    // --- SortCartByPrice ---

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

    [Fact]
    public void ShoppingCart_SortCartByPrice_KeepsEveryItemInTheCart()
    {
        var cart = new ShoppingCart();
        cart.AddItem(new Product(101, "Desk Lamp", 45.00m));
        cart.AddItem(new Product(102, "Webcam", 80.00m));
        cart.AddItem(new Product(103, "Cable Organizer", 8.00m));

        cart.SortCartByPrice();

        Assert.Equal(3, cart.Count);
    }

    [Fact]
    public void ShoppingCart_SortCartByPrice_HandlesAnEmptyCart()
    {
        var cart = new ShoppingCart();

        cart.SortCartByPrice();

        Assert.Equal(0, cart.Count);
    }

    // =========================================================================
    // 2. ProductCatalog Tests (Integrates CustomSinglyLinkedList<T>)
    // =========================================================================

    // --- AddProduct ---

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
    public void ProductCatalog_AddProduct_AppendsToTheTail_NotTheHead()
    {
        var catalog = new ProductCatalog();
        var first = new Product(201, "Chair", 250.00m);
        var second = new Product(202, "Desk", 400.00m);

        catalog.AddProduct(first);
        catalog.AddProduct(second);

        Assert.Equal(first, catalog.GetProductDetails(0));
        Assert.Equal(second, catalog.GetProductDetails(1));
    }

    [Fact]
    public void ProductCatalog_AddProduct_AllowsTheSameProductTwice()
    {
        var catalog = new ProductCatalog();
        var product = new Product(201, "Chair", 250.00m);

        catalog.AddProduct(product);
        catalog.AddProduct(product);

        Assert.Equal(2, catalog.Count);
    }

    // --- RemoveProduct ---

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
    public void ProductCatalog_RemoveProduct_ReturnsFalse_WhenProductIsNotStocked()
    {
        var catalog = new ProductCatalog();
        catalog.AddProduct(new Product(201, "Standing Desk", 400.00m));

        bool removed = catalog.RemoveProduct(new Product(999, "Absent", 1.00m));

        Assert.False(removed);
        Assert.Equal(1, catalog.Count);
    }

    [Fact]
    public void ProductCatalog_RemoveProduct_RemovesTheTailProduct()
    {
        // The tail is the node the traversal reaches last, so it exercises a
        // different re-linking path than removing the head.
        var catalog = new ProductCatalog();
        var head = new Product(201, "Chair", 250.00m);
        var tail = new Product(202, "Desk", 400.00m);
        catalog.AddProduct(head);
        catalog.AddProduct(tail);

        bool removed = catalog.RemoveProduct(tail);

        Assert.True(removed);
        Assert.True(catalog.SearchProduct(head));
        Assert.False(catalog.SearchProduct(tail));
    }

    // --- GetProductDetails ---

    [Fact]
    public void ProductCatalog_GetProductDetails_ReturnsTheNodeAtThatPosition()
    {
        var catalog = new ProductCatalog();
        var first = new Product(201, "Chair", 250.00m);
        var last = new Product(203, "Lamp", 45.00m);
        catalog.AddProduct(first);
        catalog.AddProduct(new Product(202, "Desk", 400.00m));
        catalog.AddProduct(last);

        Assert.Equal(first, catalog.GetProductDetails(0));
        Assert.Equal(last, catalog.GetProductDetails(2));
    }

    [Fact]
    public void ProductCatalog_GetProductDetails_Throws_WhenIndexIsNegative()
    {
        var catalog = new ProductCatalog();
        catalog.AddProduct(new Product(201, "Chair", 250.00m));

        Assert.Throws<ArgumentOutOfRangeException>(() => catalog.GetProductDetails(-1));
    }

    [Fact]
    public void ProductCatalog_GetProductDetails_Throws_WhenIndexIsBeyondTheChain()
    {
        var catalog = new ProductCatalog();
        catalog.AddProduct(new Product(201, "Chair", 250.00m));

        Assert.Throws<ArgumentOutOfRangeException>(() => catalog.GetProductDetails(1));
    }

    // --- ShowAllProfiles ---

    [Fact]
    public void ProductCatalog_ShowAllProfiles_WritesOneLinePerProduct()
    {
        var catalog = new ProductCatalog();
        catalog.AddProduct(new Product(201, "Chair", 250.00m));
        catalog.AddProduct(new Product(202, "Desk", 400.00m));

        string output = CaptureConsole(catalog.ShowAllProfiles);

        Assert.Contains("Chair", output);
        Assert.Contains("Desk", output);
        Assert.Equal(2, CountLines(output));
    }

    [Fact]
    public void ProductCatalog_ShowAllProfiles_ReportsAnEmptyCatalog()
    {
        var catalog = new ProductCatalog();

        string output = CaptureConsole(catalog.ShowAllProfiles);

        Assert.Contains("empty", output, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void ProductCatalog_ShowAllProfiles_TraversesInChainOrder()
    {
        var catalog = new ProductCatalog();
        catalog.AddProduct(new Product(201, "Expensive", 500.00m));
        catalog.AddProduct(new Product(202, "Cheap", 5.00m));

        catalog.SortCatalog();
        string output = CaptureConsole(catalog.ShowAllProfiles);

        Assert.True(output.IndexOf("Cheap", StringComparison.Ordinal)
                  < output.IndexOf("Expensive", StringComparison.Ordinal));
    }

    // --- SearchProduct ---

    [Fact]
    public void ProductCatalog_SearchProduct_ReturnsTrue_WhenProductIsStocked()
    {
        var catalog = new ProductCatalog();
        var product = new Product(201, "Webcam", 80.00m);
        catalog.AddProduct(new Product(202, "Filler", 1.00m));
        catalog.AddProduct(product);

        Assert.True(catalog.SearchProduct(product));
    }

    [Fact]
    public void ProductCatalog_SearchProduct_ReturnsFalse_WhenProductIsNotStocked()
    {
        var catalog = new ProductCatalog();
        catalog.AddProduct(new Product(201, "Webcam", 80.00m));

        Assert.False(catalog.SearchProduct(new Product(999, "Absent", 1.00m)));
    }

    [Fact]
    public void ProductCatalog_SearchProduct_ReturnsFalse_ForAnEmptyCatalog()
    {
        var catalog = new ProductCatalog();

        Assert.False(catalog.SearchProduct(new Product(201, "Webcam", 80.00m)));
    }

    // --- SortCatalog ---

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
    public void ProductCatalog_SortCatalog_KeepsEveryProductStocked()
    {
        var catalog = new ProductCatalog();
        var p1 = new Product(201, "Desk Lamp", 45.00m);
        var p2 = new Product(202, "Webcam", 80.00m);
        catalog.AddProduct(p1);
        catalog.AddProduct(p2);

        catalog.SortCatalog();

        Assert.Equal(2, catalog.Count);
        Assert.True(catalog.SearchProduct(p1));
        Assert.True(catalog.SearchProduct(p2));
    }

    [Fact]
    public void ProductCatalog_SortCatalog_HandlesEmptyAndSingleProductCatalogs()
    {
        var empty = new ProductCatalog();
        var single = new ProductCatalog();
        var product = new Product(201, "Webcam", 80.00m);
        single.AddProduct(product);

        empty.SortCatalog();
        single.SortCatalog();

        Assert.Equal(0, empty.Count);
        Assert.True(single.SearchProduct(product));
    }

    // =========================================================================
    // 3. OrderProcessingQueue Tests (Integrates CustomQueue<T>)
    // =========================================================================

    // --- EnqueueOrder ---

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
    public void OrderProcessingQueue_EnqueueOrder_IncrementsCount()
    {
        var queue = new OrderProcessingQueue();

        queue.EnqueueOrder(new Order(1001, "Customer A", 120.00m));
        queue.EnqueueOrder(new Order(1002, "Customer B", 45.00m));

        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void OrderProcessingQueue_EnqueueOrder_KeepsFIFOOrder_ForOrdersOfEqualValue()
    {
        // Equal totals compare as equal, so only insertion order can break the tie.
        var queue = new OrderProcessingQueue();
        var first = new Order(1001, "Customer A", 50.00m);
        var second = new Order(1002, "Customer B", 50.00m);

        queue.EnqueueOrder(first);
        queue.EnqueueOrder(second);

        Assert.Equal(first, queue.ProcessNextOrder());
        Assert.Equal(second, queue.ProcessNextOrder());
    }

    // --- ProcessNextOrder ---

    [Fact]
    public void OrderProcessingQueue_ProcessNextOrder_RemovesTheOrderFromTheQueue()
    {
        var queue = new OrderProcessingQueue();
        var order = new Order(1001, "Customer A", 120.00m);
        queue.EnqueueOrder(order);

        queue.ProcessNextOrder();

        Assert.Equal(0, queue.Count);
        Assert.False(queue.SearchOrder(order));
    }

    [Fact]
    public void OrderProcessingQueue_ProcessNextOrder_Throws_WhenQueueIsEmpty()
    {
        var queue = new OrderProcessingQueue();

        Assert.Throws<InvalidOperationException>(() => queue.ProcessNextOrder());
    }

    [Fact]
    public void OrderProcessingQueue_ProcessNextOrder_Throws_WhenQueueHasBeenDrained()
    {
        var queue = new OrderProcessingQueue();
        queue.EnqueueOrder(new Order(1001, "Customer A", 120.00m));
        queue.ProcessNextOrder();

        Assert.Throws<InvalidOperationException>(() => queue.ProcessNextOrder());
    }

    // --- ViewNextOrder ---

    [Fact]
    public void OrderProcessingQueue_ViewNextOrder_ReturnsFrontOrderWithoutProcessingIt()
    {
        var queue = new OrderProcessingQueue();
        var o1 = new Order(1001, "Customer A", 120.00m);
        queue.EnqueueOrder(o1);
        queue.EnqueueOrder(new Order(1002, "Customer B", 45.00m));

        Assert.Equal(o1, queue.ViewNextOrder());
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void OrderProcessingQueue_ViewNextOrder_FollowsTheFront_AfterProcessing()
    {
        var queue = new OrderProcessingQueue();
        var o1 = new Order(1001, "Customer A", 120.00m);
        var o2 = new Order(1002, "Customer B", 45.00m);
        queue.EnqueueOrder(o1);
        queue.EnqueueOrder(o2);

        queue.ProcessNextOrder();

        Assert.Equal(o2, queue.ViewNextOrder());
    }

    [Fact]
    public void OrderProcessingQueue_ViewNextOrder_Throws_WhenQueueIsEmpty()
    {
        var queue = new OrderProcessingQueue();

        Assert.Throws<InvalidOperationException>(() => queue.ViewNextOrder());
    }

    // --- CheckOrderQueueEmpty ---

    [Fact]
    public void OrderProcessingQueue_CheckOrderQueueEmpty_IsTrue_ForANewQueue()
    {
        var queue = new OrderProcessingQueue();

        Assert.True(queue.CheckOrderQueueEmpty());
    }

    [Fact]
    public void OrderProcessingQueue_CheckOrderQueueEmpty_IsFalse_WhenOrdersArePending()
    {
        var queue = new OrderProcessingQueue();
        queue.EnqueueOrder(new Order(1001, "Customer A", 120.00m));

        Assert.False(queue.CheckOrderQueueEmpty());
    }

    [Fact]
    public void OrderProcessingQueue_CheckOrderQueueEmpty_IsTrue_AfterEveryOrderIsProcessed()
    {
        var queue = new OrderProcessingQueue();
        queue.EnqueueOrder(new Order(1001, "Customer A", 120.00m));
        queue.ProcessNextOrder();

        Assert.True(queue.CheckOrderQueueEmpty());
    }

    // --- SearchOrder ---

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
        Assert.Equal(o1, queue.ViewNextOrder());
    }

    [Fact]
    public void OrderProcessingQueue_SearchOrder_ReturnsFalse_WhenOrderWasNeverQueued()
    {
        var queue = new OrderProcessingQueue();
        queue.EnqueueOrder(new Order(1001, "Customer A", 120.00m));

        Assert.False(queue.SearchOrder(new Order(9999, "Nobody", 1.00m)));
    }

    [Fact]
    public void OrderProcessingQueue_SearchOrder_ReturnsFalse_ForAnAlreadyProcessedOrder()
    {
        var queue = new OrderProcessingQueue();
        var processed = new Order(1001, "Customer A", 120.00m);
        var pending = new Order(1002, "Customer B", 45.00m);
        queue.EnqueueOrder(processed);
        queue.EnqueueOrder(pending);

        queue.ProcessNextOrder();

        Assert.False(queue.SearchOrder(processed));
        Assert.True(queue.SearchOrder(pending));
    }

    // --- SortOrders ---

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

    [Fact]
    public void OrderProcessingQueue_SortOrders_KeepsEveryOrderQueued()
    {
        var queue = new OrderProcessingQueue();
        var o1 = new Order(1001, "Bulk Client", 900.00m);
        var o2 = new Order(1002, "Retail Client", 30.00m);
        queue.EnqueueOrder(o1);
        queue.EnqueueOrder(o2);

        queue.SortOrders();

        Assert.Equal(2, queue.Count);
        Assert.True(queue.SearchOrder(o1));
        Assert.True(queue.SearchOrder(o2));
    }

    [Fact]
    public void OrderProcessingQueue_SortOrders_SortsCorrectly_AfterAnOrderWasProcessed()
    {
        // Processing advances the queue's front pointer, so this sorts a queue
        // whose storage has already shifted underneath it.
        var queue = new OrderProcessingQueue();
        queue.EnqueueOrder(new Order(1001, "First", 500.00m));
        queue.ProcessNextOrder();

        var large = new Order(1002, "Bulk Client", 900.00m);
        var small = new Order(1003, "Retail Client", 30.00m);
        queue.EnqueueOrder(large);
        queue.EnqueueOrder(small);

        queue.SortOrders();

        Assert.Equal(small, queue.ProcessNextOrder());
        Assert.Equal(large, queue.ProcessNextOrder());
    }

    // =========================================================================
    // 4. ReturnHistoryStack Tests (Integrates CustomStack<T>)
    // =========================================================================

    // --- PushReturn ---

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
        Assert.Equal(r1, stack.PopReturn());
    }

    [Fact]
    public void ReturnHistoryStack_PushReturn_IncrementsCount()
    {
        var stack = new ReturnHistoryStack();

        stack.PushReturn(new ReturnRequest(501, 1001, "Defective item"));
        stack.PushReturn(new ReturnRequest(502, 1002, "Wrong size"));

        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void ReturnHistoryStack_PushReturn_KeepsHistory_WhenItGrowsPastInitialCapacity()
    {
        var stack = new ReturnHistoryStack();

        for (int i = 0; i < 10; i++)
        {
            stack.PushReturn(new ReturnRequest(500 + i, 1000 + i, $"Reason {i}"));
        }

        Assert.Equal(10, stack.Count);
        Assert.Equal(509, stack.PeekLatestReturn().ReturnId);
    }

    // --- PopReturn ---

    [Fact]
    public void ReturnHistoryStack_PopReturn_RemovesTheLatestReturn()
    {
        var stack = new ReturnHistoryStack();
        var older = new ReturnRequest(501, 1001, "Defective item");
        var latest = new ReturnRequest(502, 1002, "Wrong size");
        stack.PushReturn(older);
        stack.PushReturn(latest);

        Assert.Equal(latest, stack.PopReturn());
        Assert.Equal(older, stack.PeekLatestReturn());
    }

    [Fact]
    public void ReturnHistoryStack_PopReturn_Throws_WhenHistoryIsEmpty()
    {
        var stack = new ReturnHistoryStack();

        Assert.Throws<InvalidOperationException>(() => stack.PopReturn());
    }

    [Fact]
    public void ReturnHistoryStack_PopReturn_Throws_WhenHistoryHasBeenCleared()
    {
        var stack = new ReturnHistoryStack();
        stack.PushReturn(new ReturnRequest(501, 1001, "Defective item"));
        stack.PopReturn();

        Assert.Throws<InvalidOperationException>(() => stack.PopReturn());
    }

    // --- PeekLatestReturn ---

    [Fact]
    public void ReturnHistoryStack_PeekLatestReturn_ReturnsTopWithoutRemovingIt()
    {
        var stack = new ReturnHistoryStack();
        stack.PushReturn(new ReturnRequest(501, 1001, "Defective item"));
        var latest = new ReturnRequest(502, 1002, "Wrong size");
        stack.PushReturn(latest);

        Assert.Equal(latest, stack.PeekLatestReturn());
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void ReturnHistoryStack_PeekLatestReturn_FollowsTheMostRecentPush()
    {
        var stack = new ReturnHistoryStack();
        var first = new ReturnRequest(501, 1001, "Defective item");
        stack.PushReturn(first);
        stack.PushReturn(new ReturnRequest(502, 1002, "Wrong size"));

        stack.PopReturn();

        Assert.Equal(first, stack.PeekLatestReturn());
    }

    [Fact]
    public void ReturnHistoryStack_PeekLatestReturn_Throws_WhenHistoryIsEmpty()
    {
        var stack = new ReturnHistoryStack();

        Assert.Throws<InvalidOperationException>(() => stack.PeekLatestReturn());
    }

    // --- PeekLastReturn (the requirements table's name for PeekLatestReturn) ---

    [Fact]
    public void ReturnHistoryStack_PeekLastReturn_MatchesPeekLatestReturn()
    {
        var stack = new ReturnHistoryStack();
        stack.PushReturn(new ReturnRequest(501, 1001, "Defective item"));
        var latest = new ReturnRequest(502, 1002, "Wrong size");
        stack.PushReturn(latest);

        Assert.Equal(stack.PeekLatestReturn(), stack.PeekLastReturn());
        Assert.Equal(latest, stack.PeekLastReturn());
    }

    [Fact]
    public void ReturnHistoryStack_PeekLastReturn_DoesNotConsumeTheReturn()
    {
        var stack = new ReturnHistoryStack();
        stack.PushReturn(new ReturnRequest(501, 1001, "Defective item"));

        stack.PeekLastReturn();
        stack.PeekLastReturn();

        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void ReturnHistoryStack_PeekLastReturn_Throws_WhenHistoryIsEmpty()
    {
        var stack = new ReturnHistoryStack();

        Assert.Throws<InvalidOperationException>(() => stack.PeekLastReturn());
    }

    // --- CheckHistoryEmpty ---

    [Fact]
    public void ReturnHistoryStack_CheckHistoryEmpty_IsTrue_ForANewHistory()
    {
        var stack = new ReturnHistoryStack();

        Assert.True(stack.CheckHistoryEmpty());
    }

    [Fact]
    public void ReturnHistoryStack_CheckHistoryEmpty_IsFalse_WhenReturnsAreLogged()
    {
        var stack = new ReturnHistoryStack();
        stack.PushReturn(new ReturnRequest(501, 1001, "Defective item"));

        Assert.False(stack.CheckHistoryEmpty());
    }

    [Fact]
    public void ReturnHistoryStack_CheckHistoryEmpty_IsTrue_AfterEverythingIsPopped()
    {
        var stack = new ReturnHistoryStack();
        stack.PushReturn(new ReturnRequest(501, 1001, "Defective item"));
        stack.PopReturn();

        Assert.True(stack.CheckHistoryEmpty());
    }

    // --- SearchReturn ---

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

        Assert.Equal(1, stack.SearchReturn(r3));
        Assert.Equal(3, stack.SearchReturn(r1));
    }

    [Fact]
    public void ReturnHistoryStack_SearchReturn_ReturnsMinusOne_WhenRequestIsNotInHistory()
    {
        var stack = new ReturnHistoryStack();
        stack.PushReturn(new ReturnRequest(501, 1001, "Defective item"));

        Assert.Equal(-1, stack.SearchReturn(new ReturnRequest(999, 9999, "Never filed")));
    }

    [Fact]
    public void ReturnHistoryStack_SearchReturn_LeavesTheHistoryIntact()
    {
        var stack = new ReturnHistoryStack();
        var r1 = new ReturnRequest(501, 1001, "Defective item");
        var latest = new ReturnRequest(502, 1002, "Wrong size");
        stack.PushReturn(r1);
        stack.PushReturn(latest);

        stack.SearchReturn(r1);

        Assert.Equal(2, stack.Count);
        Assert.Equal(latest, stack.PeekLatestReturn());
    }

    // --- SortReturns ---

    [Fact]
    public void ReturnHistoryStack_SortReturns_ReordersStackByReturnIdAscending()
    {
        var stack = new ReturnHistoryStack();
        stack.PushReturn(new ReturnRequest(503, 1001, "Reason A"));
        stack.PushReturn(new ReturnRequest(501, 1002, "Reason B"));
        stack.PushReturn(new ReturnRequest(502, 1003, "Reason C"));

        stack.SortReturns();

        Assert.Equal(501, stack.PeekLatestReturn().ReturnId);
    }

    [Fact]
    public void ReturnHistoryStack_SortReturns_MakesPoppingWalkIdsAscending()
    {
        var stack = new ReturnHistoryStack();
        stack.PushReturn(new ReturnRequest(503, 1001, "Reason A"));
        stack.PushReturn(new ReturnRequest(501, 1002, "Reason B"));
        stack.PushReturn(new ReturnRequest(502, 1003, "Reason C"));

        stack.SortReturns();

        Assert.Equal(501, stack.PopReturn().ReturnId);
        Assert.Equal(502, stack.PopReturn().ReturnId);
        Assert.Equal(503, stack.PopReturn().ReturnId);
    }

    [Fact]
    public void ReturnHistoryStack_SortReturns_KeepsEveryReturnInHistory()
    {
        var stack = new ReturnHistoryStack();
        var r1 = new ReturnRequest(503, 1001, "Reason A");
        var r2 = new ReturnRequest(501, 1002, "Reason B");
        stack.PushReturn(r1);
        stack.PushReturn(r2);

        stack.SortReturns();

        Assert.Equal(2, stack.Count);
        Assert.NotEqual(-1, stack.SearchReturn(r1));
        Assert.NotEqual(-1, stack.SearchReturn(r2));
    }

    // =========================================================================
    // 5. Scaffold method names kept alongside the requirement table names
    // =========================================================================
    // --- OrderProcessingQueue.PeekNextOrder ---

    [Fact]
    public void OrderProcessingQueue_PeekNextOrder_MatchesViewNextOrder()
    {
        var queue = new OrderProcessingQueue();
        var o1 = new Order(1001, "Customer A", 120.00m);
        queue.EnqueueOrder(o1);
        queue.EnqueueOrder(new Order(1002, "Customer B", 45.00m));

        Assert.Equal(queue.ViewNextOrder(), queue.PeekNextOrder());
        Assert.Equal(o1, queue.PeekNextOrder());
    }

    [Fact]
    public void OrderProcessingQueue_PeekNextOrder_DoesNotConsumeTheOrder()
    {
        var queue = new OrderProcessingQueue();
        queue.EnqueueOrder(new Order(1001, "Customer A", 120.00m));

        queue.PeekNextOrder();

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void OrderProcessingQueue_PeekNextOrder_Throws_WhenQueueIsEmpty()
    {
        var queue = new OrderProcessingQueue();

        Assert.Throws<InvalidOperationException>(() => queue.PeekNextOrder());
    }

    // =========================================================================
    // Test Helpers
    // =========================================================================

    // The Show methods write straight to the console, so the only way to assert
    // on them is to redirect the output stream for the duration of the call.
    private static string CaptureConsole(Action action)
    {
        TextWriter original = Console.Out;
        using var buffer = new StringWriter();

        try
        {
            Console.SetOut(buffer);
            action();
        }
        finally
        {
            Console.SetOut(original);
        }

        return buffer.ToString();
    }

    private static int CountLines(string output)
    {
        return output.Split('\n', StringSplitOptions.RemoveEmptyEntries).Length;
    }
}