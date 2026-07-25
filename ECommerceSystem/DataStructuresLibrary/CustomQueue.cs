namespace DataStructuresLibrary;

public class CustomQueue<T> where T : IComparable<T>
{
    private T[] _items;
    private int _front;
    private int _rear;

    public int Count { get; private set; }

    public CustomQueue(int initialCapacity = 10)
    {
        _items = new T[initialCapacity];
        _front = 0;
        _rear = 0;
        Count = 0;
    }

    public void Enqueue(T item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        if (Count == _items.Length)
        {
            Resize();
        }

        _items[_rear] = item;
        _rear = (_rear + 1) % _items.Length;
        Count++;
    }

    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        T item = _items[_front];
        _items[_front] = default!;
        _front = (_front + 1) % _items.Length;
        Count--;

        return item;
    }

    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return _items[_front];
    }

    public bool Search(T item)
    {
        if (item == null || Count == 0) return false;

        for (int i = 0; i < Count; i++)
        {
            int index = (_front + i) % _items.Length;
            if (_items[index].CompareTo(item) == 0)
            {
                return true;
            }
        }

        return false;
    }

    public void Sort()
    {
        if (Count <= 1) return;

        T[] temp = new T[Count];
        for (int i = 0; i < Count; i++)
        {
            temp[i] = _items[(_front + i) % _items.Length];
        }

        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = 0; j < Count - i - 1; j++)
            {
                if (temp[j].CompareTo(temp[j + 1]) > 0)
                {
                    (temp[j], temp[j + 1]) = (temp[j + 1], temp[j]);
                }
            }
        }

        _items = temp;
        _front = 0;
        _rear = Count % _items.Length;
    }

    private void Resize()
    {
        T[] newArray = new T[_items.Length * 2];
        for (int i = 0; i < Count; i++)
        {
            newArray[i] = _items[(_front + i) % _items.Length];
        }

        _items = newArray;
        _front = 0;
        _rear = Count;
    }
}