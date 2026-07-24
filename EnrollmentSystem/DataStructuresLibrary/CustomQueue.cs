using System;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public class CustomQueue<T>
    {
        // Array that stores the queue items
        private T[] _items;

        // Index of the first item
        private int _front;

        // Index where the next item will be added
        private int _rear;

        // Current number of items
        private int _count;

        // Default size of the queue
        private const int DefaultCapacity = 4;

        // Returns the number of items in the queue
        public int Count => _count;

        // Creates a new queue
        public CustomQueue(int initialCapacity = DefaultCapacity)
        {
            if (initialCapacity <= 0)
                initialCapacity = DefaultCapacity;

            _items = new T[initialCapacity];
            _front = 0;
            _rear = 0;
            _count = 0;
        }

        // Adds an item to the back of the queue
        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            _items[_rear] = item;
            _rear = (_rear + 1) % _items.Length;
            _count++;
        }

        // Removes and returns the first item
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T item = _items[_front];
            _items[_front] = default!;
            _front = (_front + 1) % _items.Length;
            _count--;

            return item;
        }

        // Returns the first item without removing it
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot peek: the queue is empty.");
            }

            return _items[_front];
        }

        // Checks if the queue is empty
        public bool IsEmpty()
        {
            return _count == 0;
        }

        // Searches for an item in the queue
        public int Search(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                int actualIndex = (_front + i) % _items.Length;

                if (EqualityComparer<T>.Default.Equals(_items[actualIndex], item))
                {
                    return i;
                }
            }

            return -1;
        }

        // Sorts the queue using insertion sort
        public void Sort()
        {
            if (_count <= 1)
                return;

            T[] temp = new T[_count];

            // Copy queue items to a temporary array
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _items[(_front + i) % _items.Length];
            }

            // Perform insertion sort
            for (int i = 1; i < temp.Length; i++)
            {
                T key = temp[i];
                int j = i - 1;

                while (j >= 0 && Comparer<T>.Default.Compare(temp[j], key) > 0)
                {
                    temp[j + 1] = temp[j];
                    j--;
                }

                temp[j + 1] = key;
            }

            // Copy sorted items back to the queue
            for (int i = 0; i < temp.Length; i++)
            {
                _items[i] = temp[i];
            }

            _front = 0;
            _rear = _count;
        }

        // Checks if any item matches the given condition
        public bool Contains(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException(nameof(match));

            for (int i = 0; i < _count; i++)
            {
                int actualIndex = (_front + i) % _items.Length;

                if (match(_items[actualIndex]))
                {
                    return true;
                }
            }

            return false;
        }

        // Doubles the size of the queue when it is full
        private void Resize()
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            T[] newItems = new T[newCapacity];

            // Copy existing items to the new array
            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[(_front + i) % _items.Length];
            }

            _items = newItems;
            _front = 0;
            _rear = _count;
        }
    }
}