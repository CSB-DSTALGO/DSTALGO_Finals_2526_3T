using System;

namespace ECommerceSystem.Core
{
    public class ECommerceSystem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public Product Next { get; set; }

        public void Product(int id, string name, double price)
        {
            ProductID = id;
            ProductName = name;
            Price = price;
            Next = null;
        }

        public override string ToString()
        {
            return $"ID: {ProductID}, Name: {ProductName}, Price: {Price:C}";
        }
    }
}