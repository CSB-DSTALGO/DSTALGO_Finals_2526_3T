// CustomQueue.cs
// A manually implemented FIFO (First-In-First-Out) queue backed by a circular
// array, so that both Enqueue and Dequeue run in O(1) time without needing to
// shift elements around.
using System;

namespace DataStructuresLibrary
{
    /// <summary>
    /// A generic circular-array-based queue implemented from scratch.
    /// </summary>
    public class CustomQueue<T>
    {
        private T[] _items;
        private int _front; // index of the element at the front of the queue
        private int _rear;  // index of the element at the rear of the queue
        private int _count;

        private const int DefaultCapacity = 4;

        /// <summary>
        /// Number of elements currently waiting in the queue.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        public CustomQueue()
        {
            _items = new T[DefaultCapacity];
            _front = 0;
            _rear = -1;
            _count = 0;
        }

        /// <summary>
        /// Adds an item to the rear of the queue. Amortized O(1); occasionally
        /// triggers an O(n) resize when the backing array is full.
        /// </summary>
        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            // Wrap around to the start of the array once we pass the last index.
            _rear = (_rear + 1) % _items.Length;
            _items[_rear] = item;
            _count++;
        }

        /// <summary>
        /// Removes and returns the item at the front of the queue. O(1).
        /// </summary>
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

        /// <summary>
        /// Returns the item at the front of the queue without removing it. O(1).
        /// </summary>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _items[_front];
        }

        /// <summary>
        /// True if there are no items currently queued.
        /// </summary>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// Copies the queue's contents (front to rear) into a plain array without
        /// mutating the queue. Used by higher-level modules that need to inspect
        /// or sort the waiting tickets while preserving FIFO semantics afterwards.
        /// </summary>
        public T[] ToArray()
        {
            T[] result = new T[_count];
            for (int i = 0; i < _count; i++)
            {
                result[i] = _items[(_front + i) % _items.Length];
            }
            return result;
        }

        /// <summary>
        /// Empties the queue back to its initial state. Used together with
        /// ToArray() to rebuild the queue in a new order (e.g. after sorting).
        /// </summary>
        public void Clear()
        {
            _items = new T[DefaultCapacity];
            _front = 0;
            _rear = -1;
            _count = 0;
        }

        /// <summary>
        /// Doubles the capacity of the backing array, re-laying out the elements
        /// starting at index 0 so front/rear bookkeeping stays simple. O(n).
        /// </summary>
        private void Resize()
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _items[(_front + i) % _items.Length];
            }

            _items = newArray;
            _front = 0;
            _rear = _count - 1;
        }
    }
}
