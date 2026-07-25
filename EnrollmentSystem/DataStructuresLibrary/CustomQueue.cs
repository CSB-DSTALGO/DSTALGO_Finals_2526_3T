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

        public CustomQueue(int capacity = 50)
        {
            _items = new T[capacity];
            _front = 0;
            _rear = 0;
            _count = 0;

        }

        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                throw new InvalidOperationException("Queue line is full.");
            }
            _items[_rear] = item;
            _rear = (_rear + 1) % _items.Length;
            _count++;
        }

        public T Dequeue()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Queue line is empty.");
            }
            T item = _items[_front];
            _front = (_front + 1) % _items.Length;
            _count--;
            return item;
        }

        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Queue line is empty.");
            }
            return _items[_front];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool Search(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                int index = (_front + i) % _items.Length;
                if (_items[index].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void Sort()
        {
            if (_count <= 1) return;
            T[] temp = new T[_count];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _items[(_front + i) % _items.Length];
            }
            Array.Sort(temp);
            for (int i = 0; i < _count; i++)
            {
                _items[(_front + i) % _items.Length] = temp[i];
            }
        }
    }
}
