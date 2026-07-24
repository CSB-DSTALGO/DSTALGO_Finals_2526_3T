public class Product
{
    public int Id { get; set; }          // Unique identifier
    public string Name { get; set; }     // Product name
    public decimal Price { get; set; }   // Product price
    public int Stock { get; set; }       // Quantity available
}
public class ProductCatalog
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product) { products.Add(product); }

    public void RemoveProduct(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product != null) { products.Remove(product); }
    }

    public Product FindProductById(int id)
    {
        return products.FirstOrDefault(p => p.Id == id);
    }

    public List<Product> ListAllProducts()
    {
        return products;
    }
}
