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
        private int _capacity;

        // Returns how many items are currently in the queue.
        public int Count
        {
            get { return _count; }
        }

        // Initializes an empty queue with a default starting capacity.
        public CustomQueue()
        {
            _capacity = 4;
            _items = new T[_capacity];
            _front = 0;
            _rear = -1;
            _count = 0;
        }

        // Adds an item to the rear of the queue. Resizes if full.
        public void Enqueue(T item)
        {
            if (_count == _capacity)
            {
                Resize();
            }

            _rear = (_rear + 1) % _capacity;
            _items[_rear] = item;
            _count++;
        }

        // Removes and returns the item at the front of the queue.
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot dequeue from an empty queue.");

            T item = _items[_front];
            _items[_front] = default!;
            _front = (_front + 1) % _capacity;
            _count--;
            return item;
        }

        // Returns the front item without removing it.
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot peek an empty queue.");

            return _items[_front];
        }

        // Returns true if the queue has no elements.
        public bool IsEmpty()
        {
            return _count == 0;
        }

        // Returns a snapshot array of items in front-to-rear order.
        // Used by AdmissionsDesk for sorting/searching without breaking encapsulation.
        public T[] ToArray()
        {
            T[] result = new T[_count];
            for (int i = 0; i < _count; i++)
            {
                result[i] = _items[(_front + i) % _capacity];
            }
            return result;
        }

        // Doubles the array size when full, realigning elements from index 0.
        private void Resize()
        {
            T[] newItems = new T[_capacity * 2];
            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[(_front + i) % _capacity];
            }
            _items = newItems;
            _front = 0;
            _rear = _count - 1;
            _capacity *= 2;
        }
    }
}
