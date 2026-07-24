using System;

namespace DataStructuresLibrary;

public class CustomQueue<T> where T : IComparable<T>
{
    private T[] _items;
    private int _head;
    private int _tail;
    private const int InitialCapacity = 4;

    public int Count { get; private set; }

    public CustomQueue()
    {
        _items = new T[InitialCapacity];
        _head = 0;
        _tail = 0;
        Count = 0;
    }

    public void Enqueue(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Cannot enqueue a null item.");
        }

        if (Count == _items.Length)
        {
            Resize();
        }

        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        Count++;
    }

    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Cannot dequeue from an empty queue.");
        }

        T item = _items[_head];
        _items[_head] = default!;
        _head = (_head + 1) % _items.Length;
        Count--;

        return item;
    }

    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Cannot peek into an empty queue.");
        }

        return _items[_head];
    }

    public bool Search(T item)
    {
        if (Count == 0 || item == null)
        {
            return false;
        }

        for (int i = 0; i < Count; i++)
        {
            int index = (_head + i) % _items.Length;
            if (_items[index].CompareTo(item) == 0)
            {
                return true;
            }
        }

        return false;
    }

    public void Sort()
    {
        if (Count <= 1)
        {
            return;
        }

        T[] temp = new T[Count];
        for (int i = 0; i < Count; i++)
        {
            temp[i] = _items[(_head + i) % _items.Length];
        }

        for (int i = 1; i < Count; i++)
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

        _items = new T[Math.Max(InitialCapacity, temp.Length)];
        for (int i = 0; i < temp.Length; i++)
        {
            _items[i] = temp[i];
        }

        _head = 0;
        _tail = Count % _items.Length;
    }

    private void Resize()
    {
        T[] newArray = new T[_items.Length * 2];

        for (int i = 0; i < Count; i++)
        {
            newArray[i] = _items[(_head + i) % _items.Length];
        }

        _items = newArray;
        _head = 0;
        _tail = Count;
    }
}