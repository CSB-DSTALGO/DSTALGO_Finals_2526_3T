namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    private readonly CustomArrayList<T> _items = new();
    public int Count => _items.Count;

    public void Push(T item)
    {
        _items.Add(item);
    }
    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        T item = _items.Get(Count - 1);
        _items.Remove(item);
        return item;
    }
    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        return _items.Get(Count - 1);
    }
    public int Search(T item)
    {
        int index = _items.Search(item);
        if (index == -1)
            return -1;

        return Count - index;
    }
    public void Sort()
    {
        _items.Sort();
    }
}