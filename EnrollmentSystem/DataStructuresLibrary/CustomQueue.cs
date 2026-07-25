// CustomQueue.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomQueue<T> where T : IComparable<T>
    {
        private T[] _items;
        private int _front;
        private int _rear;
        private int _count;

        // Returns the number of items currently in the queue.
        public int Count
        {
            get { return _count; }
        }

        public CustomQueue()
        {
            _items = new T[0];
            _front = 0;
            _rear = -1;
            _count = 0;
        }

        // Adds an item to the rear of the queue.
        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            _rear++;
            _items[_rear] = item;
            _count++;
        }

        // Removes and returns the front item.
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T item = _items[_front];

            for (int i = 0; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _rear--;
            _count--;

            return item;
        }

        // Returns the front item without removing it.
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            return _items[_front];
        }

        // Checks whether the queue is empty.
        public bool IsEmpty()
        {
            return _count == 0;
        }

        // Increases the array capacity by one intially then multiplied by 2 onwards.
        private void Resize()
        {
            T[] newItems = new T[_items.Length == 0 ? 1 : _items.Length * 2];

            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        public bool Search(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void Sort()
        {
            for (int i = 0; i < _count - 1; i++)
            {
                for (int j = 0; j < _count - i - 1; j++)
                {
                    if (((IComparable<T>)_items[j]).CompareTo(_items[j + 1]) > 0)
                    {
                        T temp = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temp;
                    }
                }
            }
        }
    }
}