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

    public T Pop() => throw new NotImplementedException();

    public T Peek() => throw new NotImplementedException();

    public int Search(T item) => throw new NotImplementedException();

    public void Sort() => throw new NotImplementedException();
}