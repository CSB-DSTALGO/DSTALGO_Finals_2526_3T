namespace ECommerceSystem.Core
{
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        // Compare by Price for sorting
        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public override string ToString() => $"{Name} - ₱{Price}";
    }

    public class Order : IComparable<Order>
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }

        public Order(int orderId, string customerName, decimal totalAmount)
        {
            OrderId = orderId;
            CustomerName = customerName;
            TotalAmount = totalAmount;
        }

        // Compare by TotalAmount for sorting
        public int CompareTo(Order? other)
        {
            if (other == null) return 1;
            return TotalAmount.CompareTo(other.TotalAmount);
        }

        public override string ToString() => $"{CustomerName} - ₱{TotalAmount}";
    }

    public class ReturnRequest : IComparable<ReturnRequest>
    {
        public int ReturnId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;

        public ReturnRequest(int returnId, string customerName, string reason)
        {
            ReturnId = returnId;
            CustomerName = customerName;
            Reason = reason;
        }

        public int CompareTo(ReturnRequest? other)
        {
            if (other == null)
                return 1;

            return ReturnId.CompareTo(other.ReturnId);
        }

        public override string ToString()
        {
            return $"Return #{ReturnId} - {CustomerName}: {Reason}";
        }
    }
}

