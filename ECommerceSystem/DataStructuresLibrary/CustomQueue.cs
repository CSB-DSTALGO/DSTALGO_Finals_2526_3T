namespace DataStructuresLibrary;

public class CustomQueue<T> where T : IComparable<T>
{
    private readonly List<T> _items = new();

    public int Count => _items.Count;

    public void Enqueue(T item)
    {
        _items.Add(item);
    }
    public T Dequeue()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        T item = _items[0];
        _items.RemoveAt(0);

        return item;
    }
    public T Peek()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        return _items[0];
    }
    public bool Search(T item)
    {
        return _items.Contains(item);
    }
    public void Sort()
    {
        _items.Sort();
    }
}