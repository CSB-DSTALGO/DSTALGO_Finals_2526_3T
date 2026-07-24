// 12521269 Joaquin Bryan G. Ross
namespace ECommerceSystem.Core;

using DataStructuresLibrary;

public class ProductCatalog
{
    private readonly CustomSinglyLinkedList<Product> _products = new();

    public int Count => _products.Count;

    /// <summary>
    /// Appends a product node to the end of the chain. O(n) here, because the
    /// list keeps no tail pointer and has to walk to the last node first.
    /// Holding a tail pointer would make this O(1), at the cost of one more
    /// field to keep correct on every removal.
    /// </summary>
    public void AddProduct(Product product) => _products.Add(product);

    /// <summary>
    /// Removes a targeted node. O(n): finding the node is a linear walk, and
    /// the unlink itself is O(1) once the predecessor is known.
    /// </summary>
    public bool RemoveProduct(Product product) => _products.Remove(product);

    /// <summary>
    /// Locates and returns a node by position. O(n), since a linked list has
    /// no random access and reaching index i costs i hops from the head.
    /// </summary>
    public Product GetProductDetails(int index) => _products.GetAt(index);

    /// <summary>
    /// Traverses and prints the continuous chain. O(n) over one pass.
    /// </summary>
    public void ShowAllProfiles()
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("The catalog is empty.");
            return;
        }

        for (int i = 0; i < _products.Count; i++)
        {
            Product product = _products.GetAt(i);
            Console.WriteLine($"[{i}] #{product.Id} {product.Name} - ${product.Price:F2}");
        }
    }

    /// <summary>
    /// Search algorithm: linear search, delegated to CustomSinglyLinkedList.Search.
    /// It follows Next from the head until the data matches or the chain ends.
    /// Best case O(1) at the head, worst and average case O(n). A linked list
    /// cannot do better than linear, because there is no way to jump to the
    /// middle without walking there first. That rules out binary search no
    /// matter how well sorted the catalog is.
    /// Returns whether the product is stocked. Position is not reported because
    /// the chain has no meaningful index to hand back.
    /// </summary>
    public bool SearchProduct(Product product) => _products.Search(product);

    /// <summary>
    /// Sorting algorithm: insertion sort by re-linking, delegated to
    /// CustomSinglyLinkedList.Sort. It builds a second, sorted chain and moves
    /// each node into place by pointer surgery, so no payload is ever copied.
    /// Best case O(n) when already ordered, worst and average case O(n^2), with
    /// O(1) extra space since only the existing nodes are relinked.
    /// Merge sort would give O(n log n) and is the usual choice for long lists,
    /// but insertion sort keeps the pointer work readable and the catalog small.
    /// Product.CompareTo orders by price, so the cheapest product ends up at the head.
    /// </summary>
    public void SortCatalog() => _products.Sort();
}