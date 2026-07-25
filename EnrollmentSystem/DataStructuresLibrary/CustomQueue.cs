// CustomQueue.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomQueue<T>
    {
        private T[] _items;
        private int _front;
        private int _rear;
        private int _count;

        public int Count 
        { 
            get { return _count; } 
        }

        public CustomQueue()
        {
            _items = new T [10];
            _front = 0;
            _rear = -1;
            _count = 0;
        }

        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            _rear = (_rear + 1) % _items.Length;
            _items[_rear] = item;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T item = _items[_front];
            _front = (_front + 1) % _items.Length;
            _count--;

            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            return _items[_front];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public int Search(T item)
{
    var comparer = System.Collections.Generic.EqualityComparer<T>.Default;
    for (int i = 0; i < _count; i++)
    {
        if (comparer.Equals(_items[(_front + i) % _items.Length], item))
        {
            return i;
        }
    }
    return -1;
}

public void Sort()
{
    var comparer = System.Collections.Generic.Comparer<T>.Default;
    // Linearize into a temp array first since indices wrap around
    T[] temp = new T[_count];
    for (int i = 0; i < _count; i++)
    {
        temp[i] = _items[(_front + i) % _items.Length];
    }

    // Insertion sort on the linear copy
    for (int i = 1; i < _count; i++)
    {
        T key = temp[i];
        int j = i - 1;
        while (j >= 0 && comparer.Compare(temp[j], key) > 0)
        {
            temp[j + 1] = temp[j];
            j--;
        }
        temp[j + 1] = key;
    }

    // Write back, resetting front/rear since order is now linear
    for (int i = 0; i < _count; i++)
    {
        _items[i] = temp[i];
    }
    _front = 0;
    _rear = _count - 1;
}

        private void Resize()
        {
            T[] newItems = new T[_items.Length * 2];

            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[(_front + i) % _items.Length];
            }
            
            _items = newItems;
            _front = 0;
            _rear = _count - 1;
        }
    }
}
