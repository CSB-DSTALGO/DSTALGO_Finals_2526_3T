namespace ECommerceSystem.Core
{
    public class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int productId, string name, decimal price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"{ProductId} - {Name} (${Price:F2})";
        }
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
        public int OrderId { get; set; }

        public string Reason { get; set; }


        public ReturnRequest(int returnId, int orderId, string reason)
        {
            ReturnId = returnId;
            OrderId = orderId;
            Reason = reason;
        }

        public int CompareTo(ReturnRequest? other)
        {

            if (other == null) return 1;

            if (other == null)
            {
                return 1;
            }


            return ReturnId.CompareTo(other.ReturnId);
        }

        public override string ToString()
        {

            return $"Return #{ReturnId} (Order #{OrderId}): {Reason}";
        }
    }

}


           
