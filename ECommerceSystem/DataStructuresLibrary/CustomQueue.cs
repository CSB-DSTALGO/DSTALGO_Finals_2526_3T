namespace DataStructuresLibrary;

public class CustomQueue<T> where T : IComparable<T>
{
    private T[] _items;
    private int _front;
    private int _rear;
    public int Count { get; private set; }

    public CustomQueue(int initialCapacity = 4)
    {
        _items = new T[initialCapacity];
        _front = 0;
        _rear = 0;
        Count = 0;
    }

    public void Enqueue(T item)
    {
        if (Count == _items.Length)
        {
            Grow();
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

    // Returns true/false or index depending on search check
    public bool Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            int index = (_front + i) % _items.Length;
            if (_items[index] != null && _items[index].CompareTo(item) == 0)
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
            for (int j = 0; j < Count - 1 - i; j++)
            {
                if (temp[j].CompareTo(temp[j + 1]) < 0)
                {
                    T swap = temp[j];
                    temp[j] = temp[j + 1];
                    temp[j + 1] = swap;
                }
            }
        }

        _items = temp;
        _front = 0;
        _rear = Count;
    }

    private void Grow()
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