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
        _rear = -1;
        Count = 0;
    }

    public void Enqueue(T item)
    {
        if (Count == _items.Length)
        {
            Resize();
        }
        _rear = (_rear + 1) % _items.Length;
        _items[_rear] = item;
        Count++;
    }

    public T Dequeue()
    {
        if (Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        T item = _items[_front];
        _front = (_front + 1) % _items.Length;
        Count--;
        return item;
    }

    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        return _items[_front];
    }

    public bool Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            int index = (_front + i) % _items.Length;
            if (_items[index].CompareTo(item) == 0)
                return true;
        }
        return false;
    }

    public void Sort()
    {
        T[] temp = new T[Count];
        for (int i = 0; i < Count; i++)
        {
            temp[i] = _items[(_front + i) % _items.Length];
        }

        for (int i = 1; i < temp.Length; i++)
        {
            T key = temp[i];
            int j = i - 1;
            while (j >= 0 && temp[j].CompareTo(key) > 0)
            {
                temp[j + 1] = temp[j];
                j--;
            }
            temp[j + 1] = key;
        }

        _front = 0;
        _rear = temp.Length - 1;
        for (int i = 0; i < temp.Length; i++)
        {
            _items[i] = temp[i];
        }
    }

    private void Resize()
    {
        T[] newItems = new T[_items.Length * 2];
        for (int i = 0; i < Count; i++)
        {
            newItems[i] = _items[(_front + i) % _items.Length];
        }
        _items = newItems;
        _front = 0;
        _rear = Count - 1;
    }
}