// 12521269 Joaquin Bryan G. Ross
﻿namespace ECommerceSystem.ConsoleApp;

using System;
using ECommerceSystem.Core;

public class Program
{
    private static readonly ProductCatalog Catalog = new();
    private static readonly ShoppingCart Cart = new();
    private static readonly OrderProcessingQueue OrderQueue = new();
    private static readonly ReturnHistoryStack ReturnStack = new();

    public static void Main(string[] args)
    {
        SeedSampleData();

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("        E-COMMERCE MANAGEMENT SYSTEM CLI          ");
            Console.WriteLine("==================================================");
            Console.WriteLine("1. Manage Product Catalog  (CustomSinglyLinkedList)");
            Console.WriteLine("2. Manage Shopping Cart    (CustomArrayList)");
            Console.WriteLine("3. Process Orders          (CustomQueue)");
            Console.WriteLine("4. Manage Returns          (CustomStack)");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==================================================");
            Console.Write("Select an option (1-5): ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1": ManageCatalogMenu(); break;
                case "2": ManageCartMenu(); break;
                case "3": ManageQueueMenu(); break;
                case "4": ManageReturnsMenu(); break;
                case "5": exit = true; break;
                default: Pause("Invalid option. Press Enter to try again..."); break;
            }
        }
    }

    // =========================================================================
    // 1. Catalog Menu (CustomSinglyLinkedList<Product>)
    // =========================================================================
    private static void ManageCatalogMenu()
    {
        Console.Clear();
        Console.WriteLine("--- Product Catalog Management ---");
        Console.WriteLine($"Total Products in Catalog: {Catalog.Count}\n");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. Search Product");
        Console.WriteLine("3. Sort Catalog by Price");
        Console.WriteLine("4. Show All Products");
        Console.WriteLine("5. Get Product Details by Index");
        Console.WriteLine("6. Return to Main Menu");
        Console.Write("\nChoice: ");

        switch (Console.ReadLine()?.Trim())
        {
            case "1":
                int id = ReadInt("Enter Product ID: ");
                string name = ReadString("Enter Product Name: ");
                decimal price = ReadDecimal("Enter Product Price ($): ");
                Catalog.AddProduct(new Product(id, name, price));
                Pause("Product added successfully!");
                break;
            case "2":
                decimal searchPrice = ReadDecimal("Enter Product Price to search: ");

                // SearchProduct matches on the product record itself, not on a
                // field, so the record has to be located before it can be searched
                // for. Passing a throwaway Product built from the price alone would
                // never match, since two products at the same price are still two
                // different records.
                Product? candidate = null;
                for (int i = 0; i < Catalog.Count; i++)
                {
                    if (Catalog.GetProductDetails(i).Price == searchPrice)
                    {
                        candidate = Catalog.GetProductDetails(i);
                        break;
                    }
                }

                bool found = candidate != null && Catalog.SearchProduct(candidate);
                Pause(found ? $"MATCH FOUND in catalog: {candidate!.Name}" : "Product NOT found in catalog.");
                break;
            case "3":
                Catalog.SortCatalog();
                Pause("Catalog sorted by price in ascending order!");
                break;
            case "4":
                Console.WriteLine();
                Catalog.ShowAllProfiles();
                Pause("End of catalog.");
                break;
            case "5":
                int detailIndex = ReadInt("Enter catalog index: ");
                try
                {
                    Product detail = Catalog.GetProductDetails(detailIndex);
                    Pause($"#{detail.Id} {detail.Name} - ${detail.Price:F2}");
                }
                catch (Exception ex)
                {
                    Pause($"Error: {ex.Message}");
                }
                break;
            case "6": return;
            default: Pause("Invalid choice."); break;
        }
    }

    // =========================================================================
    // 2. Shopping Cart Menu (CustomArrayList<Product>)
    // =========================================================================
    private static void ManageCartMenu()
    {
        Console.Clear();
        Console.WriteLine("--- Shopping Cart Management ---");
        Console.WriteLine($"Items in Cart: {Cart.Count}");
        try
        {
            Console.WriteLine($"Total Cart Value: ${Cart.CalculateTotal():F2}\n");
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("Total Cart Value: [Not Implemented Yet]\n");
        }

        Console.WriteLine("1. Add Item to Cart");
        Console.WriteLine("2. Search Item Position");
        Console.WriteLine("3. Sort Cart by Price");
        Console.WriteLine("4. Show All Items");
        Console.WriteLine("5. Remove Item by Index");
        Console.WriteLine("6. Return to Main Menu");
        Console.Write("\nChoice: ");

        switch (Console.ReadLine()?.Trim())
        {
            case "1":
                int id = ReadInt("Enter Product ID: ");
                string name = ReadString("Enter Product Name: ");
                decimal price = ReadDecimal("Enter Product Price ($): ");
                Cart.AddItem(new Product(id, name, price));
                Pause("Item added to cart!");
                break;
            case "2":
                decimal targetPrice = ReadDecimal("Enter Product Price to locate in cart: ");

                // Same as the catalog: locate the record, then search for it.
                Product? inCart = null;
                for (int i = 0; i < Cart.Count; i++)
                {
                    if (Cart.GetItemAt(i).Price == targetPrice)
                    {
                        inCart = Cart.GetItemAt(i);
                        break;
                    }
                }

                int index = inCart == null ? -1 : Cart.SearchItem(inCart);
                Pause(index != -1 ? $"Item found at Index: {index}" : "Item NOT found in cart.");
                break;
            case "3":
                Cart.SortCartByPrice();
                Pause("Cart items sorted by price!");
                break;
            case "4":
                Console.WriteLine();
                Cart.ShowAllItems();
                Pause("End of cart.");
                break;
            case "5":
                int removeIndex = ReadInt("Enter cart index to remove: ");
                bool removed = Cart.RemoveItem(removeIndex);
                Pause(removed ? $"Removed the item at index {removeIndex}." : "That index is not in the cart.");
                break;
            case "6": return;
            default: Pause("Invalid choice."); break;
        }
    }

    // =========================================================================
    // 3. Order Queue Menu (CustomQueue<Order>)
    // =========================================================================
    private static void ManageQueueMenu()
    {
        Console.Clear();
        Console.WriteLine("--- Order Processing Queue ---");
        Console.WriteLine($"Orders Pending: {OrderQueue.Count}");
        Console.WriteLine($"Queue Empty: {OrderQueue.CheckOrderQueueEmpty()}\n");
        Console.WriteLine("1. Enqueue New Order");
        Console.WriteLine("2. Process (Dequeue) Next Order");
        Console.WriteLine("3. Peek Next Order");
        Console.WriteLine("4. Search Order Status");
        Console.WriteLine("5. Sort Queue by Order Amount");
        Console.WriteLine("6. Return to Main Menu");
        Console.Write("\nChoice: ");

        switch (Console.ReadLine()?.Trim())
        {
            case "1":
                int id = ReadInt("Enter Order ID: ");
                string customer = ReadString("Enter Customer Name: ");
                decimal amount = ReadDecimal("Enter Order Total ($): ");
                OrderQueue.EnqueueOrder(new Order(id, customer, amount));
                Pause("Order enqueued successfully!");
                break;
            case "2":
                try
                {
                    Order processed = OrderQueue.ProcessNextOrder();
                    Pause($"Processed Order #{processed.OrderId} for {processed.CustomerName} (${processed.TotalAmount})");
                }
                catch (Exception ex)
                {
                    Pause($"Error: {ex.Message}");
                }
                break;
            case "3":
                try
                {
                    Order next = OrderQueue.ViewNextOrder();
                    Pause($"Next in line: Order #{next.OrderId} - {next.CustomerName} (${next.TotalAmount})");
                }
                catch (Exception ex)
                {
                    Pause($"Error: {ex.Message}");
                }
                break;
            case "4":
                decimal searchAmount = ReadDecimal("Enter Order Total to check status: ");

                // A queue exposes only its front, so locating the order means
                // cycling the whole line once. Dequeuing and re-enqueuing in the
                // same pass puts every order back in its original position.
                Order? wanted = null;
                for (int i = OrderQueue.Count; i > 0; i--)
                {
                    Order cycled = OrderQueue.ProcessNextOrder();
                    if (cycled.TotalAmount == searchAmount && wanted == null) wanted = cycled;
                    OrderQueue.EnqueueOrder(cycled);
                }

                bool exists = wanted != null && OrderQueue.SearchOrder(wanted);
                Pause(exists ? $"Order #{wanted!.OrderId} for {wanted.CustomerName} is in the queue!" : "Order NOT found in queue.");
                break;
            case "5":
                OrderQueue.SortOrders();
                Pause("Queue reordered by total amount (ascending)!");
                break;
            case "6": return;
            default: Pause("Invalid choice."); break;
        }
    }

    // =========================================================================
    // 4. Return Stack Menu (CustomStack<ReturnRequest>)
    // =========================================================================
    private static void ManageReturnsMenu()
    {
        Console.Clear();
        Console.WriteLine("--- Return Request History ---");
        Console.WriteLine($"Total Return Log Entries: {ReturnStack.Count}");
        Console.WriteLine($"History Empty: {ReturnStack.CheckHistoryEmpty()}\n");
        Console.WriteLine("1. Push New Return Request");
        Console.WriteLine("2. Pop Latest Return Request");
        Console.WriteLine("3. Peek Top Return Entry");
        Console.WriteLine("4. Search Return Depth");
        Console.WriteLine("5. Sort Returns by Return ID");
        Console.WriteLine("6. Return to Main Menu");
        Console.Write("\nChoice: ");

        switch (Console.ReadLine()?.Trim())
        {
            case "1":
                int returnId = ReadInt("Enter Return ID: ");
                int orderId = ReadInt("Enter Associated Order ID: ");
                string reason = ReadString("Enter Reason for Return: ");
                ReturnStack.PushReturn(new ReturnRequest(returnId, orderId, reason));
                Pause("Return request logged!");
                break;
            case "2":
                try
                {
                    ReturnRequest popped = ReturnStack.PopReturn();
                    Pause($"Popped Return #{popped.ReturnId} (Order #{popped.OrderId}): {popped.Reason}");
                }
                catch (Exception ex)
                {
                    Pause($"Error: {ex.Message}");
                }
                break;
            case "3":
                try
                {
                    ReturnRequest top = ReturnStack.PeekLatestReturn();
                    Pause($"Top Return Entry: #{top.ReturnId} (Order #{top.OrderId})");
                }
                catch (Exception ex)
                {
                    Pause($"Error: {ex.Message}");
                }
                break;
            case "4":
                int searchReturnId = ReadInt("Enter Return ID to check depth: ");

                // A stack exposes only its top, so locating the entry means
                // popping the whole stack into a holding stack and pushing it
                // back, which restores the original order.
                var holdingReturns = new ReturnHistoryStack();
                ReturnRequest? wantedReturn = null;
                while (!ReturnStack.CheckHistoryEmpty())
                {
                    ReturnRequest popped = ReturnStack.PopReturn();
                    if (popped.ReturnId == searchReturnId) wantedReturn = popped;
                    holdingReturns.PushReturn(popped);
                }
                while (!holdingReturns.CheckHistoryEmpty())
                {
                    ReturnStack.PushReturn(holdingReturns.PopReturn());
                }

                int returnDepth = wantedReturn == null ? -1 : ReturnStack.SearchReturn(wantedReturn);
                Pause(returnDepth != -1 ? $"Return Request found at depth level: {returnDepth}" : "Return request NOT found.");
                break;
            case "5":
                ReturnStack.SortReturns();
                Pause("Stack sorted by Return ID!");
                break;
            case "6": return;
            default: Pause("Invalid choice."); break;
        }
    }

    // =========================================================================
    // Helper Methods & Seed Data
    // =========================================================================
    private static void SeedSampleData()
    {
        try
        {
            Catalog.AddProduct(new Product(101, "Mechanical Keyboard", 120.00m));
            Catalog.AddProduct(new Product(102, "Wireless Mouse", 35.50m));
            Catalog.AddProduct(new Product(103, "UltraWide Monitor", 450.00m));

            Cart.AddItem(new Product(102, "Wireless Mouse", 35.50m));
            Cart.AddItem(new Product(101, "Mechanical Keyboard", 120.00m));

            OrderQueue.EnqueueOrder(new Order(1001, "Alice Smith", 155.50m));
            OrderQueue.EnqueueOrder(new Order(1002, "Bob Jones", 450.00m));

            ReturnStack.PushReturn(new ReturnRequest(501, 1001, "Defective Key switch"));
            ReturnStack.PushReturn(new ReturnRequest(502, 1002, "Changed mind"));
        }
        catch (NotImplementedException)
        {
            // Suppress error if student hasn't implemented methods yet
        }
    }

    private static void Pause(string message)
    {
        Console.WriteLine($"\n{message}");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    private static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        int.TryParse(Console.ReadLine(), out int val);
        return val;
    }

    private static decimal ReadDecimal(string prompt)
    {
        Console.Write(prompt);
        decimal.TryParse(Console.ReadLine(), out decimal val);
        return val;
    }

    private static string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }
}