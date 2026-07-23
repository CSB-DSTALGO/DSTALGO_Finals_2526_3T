namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    private T[] _items;
    private const int InitialCapacity = 4;

    public int Count { get; private set; }

    public CustomStack()
    {
        _items = new T[InitialCapacity];
        Count = 0;
    }

    public void Push(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        if (Count == _items.Length)
        {
            T[] newArray = new T[_items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                newArray[i] = _items[i];
            }

            _items = newArray;
        }

        _items[Count] = item;
        Count++;
    }

    public T Pop()
{
    if (Count == 0)
    {
        throw new InvalidOperationException("Stack is empty.");
    }

    Count--;
    T item = _items[Count];
    _items[Count] = default!;

    return item;
}

    public T Peek()
{
    if (Count == 0)
    {
        throw new InvalidOperationException("Stack is empty.");
    }

    return _items[Count - 1];
}

    public int Search(T item)
{
    for (int i = Count - 1, depth = 1; i >= 0; i--, depth++)
    {
        if (_items[i].CompareTo(item) == 0)
            return depth;
    }

    return -1;
}
    public void Sort() => throw new NotImplementedException();
}