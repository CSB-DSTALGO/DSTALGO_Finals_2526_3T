// 12521269 Joaquin Bryan G. Ross
namespace ECommerceSystem.Core;

public class Product : IComparable<Product>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    // Builds a catalogue product. Price is what CompareTo orders by.
    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    // Hint: Compare by Price for cart and catalog sorting
    public int CompareTo(Product? other)
    {
        if (other == null) return 1;
        return Price.CompareTo(other.Price);
    }
}

public class Order : IComparable<Order>
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }

    // Builds a customer order. TotalAmount is what CompareTo orders by.
    public Order(int orderId, string customerName, decimal totalAmount)
    {
        OrderId = orderId;
        CustomerName = customerName;
        TotalAmount = totalAmount;
    }

    // Hint: Compare by TotalAmount for processing queue sorting
    public int CompareTo(Order? other)
    {
        if (other == null) return 1;
        return TotalAmount.CompareTo(other.TotalAmount);
    }
}

public class ReturnRequest : IComparable<ReturnRequest>
{
    public int ReturnId { get; set; }
    public int OrderId { get; set; }
    public string Reason { get; set; }

    // Builds a return request. ReturnId is what CompareTo orders by.
    public ReturnRequest(int returnId, int orderId, string reason)
    {
        ReturnId = returnId;
        OrderId = orderId;
        Reason = reason;
    }

    // Hint: Compare by ReturnId for return history sorting
    public int CompareTo(ReturnRequest? other)
    {
        if (other == null) return 1;
        return ReturnId.CompareTo(other.ReturnId);
    }
}
