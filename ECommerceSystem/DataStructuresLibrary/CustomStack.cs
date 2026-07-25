namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    private T[] _items;
    private int _top;

    public int Count { get; private set; }

    public CustomStack()
    {
        _items = new T[4];
        Count = 0;
        _top = 0;
    }

    public void Push(T item)
    {
        if (_top == _items.Length)
            Resize();
        _items[_top] = item;
        _top++;
        Count++;
    }

    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");
        _top--;
        Count--;
        return _items[_top];
    }

    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");
        return _items[_top - 1];
    }

    public int Search(T item)
    {
        for (int i = _top - 1; i >= 0; i--)
            if (_items[i].CompareTo(item) == 0)
                return i;
        return -1;
    }

    public void Sort()
    {
        for (int i = 0; i < _top - 1; i++)
            for (int j = 0; j < _top - i - 1; j++)
                if (_items[j].CompareTo(_items[j + 1]) > 0)
                {
                    T temp = _items[j];
                    _items[j] = _items[j + 1];
                    _items[j + 1] = temp;
                }
    }

    private void Resize()
    {
        T[] bigger = new T[_items.Length * 2];
        for (int i = 0; i < _top; i++)
            bigger[i] = _items[i];
        _items = bigger;
    }
}