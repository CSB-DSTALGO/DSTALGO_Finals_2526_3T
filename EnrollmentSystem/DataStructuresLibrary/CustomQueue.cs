using System;

namespace DataStructuresLibrary
{
    public class CustomQueue<T>
    {
        private T[] _items; // Array to hold the queue elements
        private int _front; // Index of the front element
        private int _rear; // Next element
        private int _count; // Number of elements in the queue

        public int Count
        {
            get { return _count; } // Property to get the number of elements in the queue
        }

        public CustomQueue()
        {
            _items = new T[4]; // Initial capacity of the queue
            _front = 0; // Front index starts at 0
            _rear = 0; // Rear index starts at 0
            _count = 0; // The queue is initially empty
        }

        // Adds an item to the end of the queue
        public void Enqueue(T item)
        {
            _items[_rear] = item; // Insert the item to the rear
            _rear = (_rear + 1) % _items.Length; // This moves the rear index forward and wraps around to use the empty space at the front if needed
            _count++; // Increases the count of items
        }

        // Removes and returns the item at the front of the queue
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty."); // This checks if the queue is empty and throws an exception if it is
            }
            T item = _items[_front]; // Store the front item
            _front = (_front + 1) % _items.Length; // Move front to the next item
            _count--; // Decrease the count of items

            return item; // Return the dequeued item
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty."); //Checks and throws an exception if queue is empty
            }
            return _items[_front]; // Returns the item at the front without removing it
        }

        public bool IsEmpty()
        {
            return _count == 0; // Returns true if the queue is empty
        }

        public void Sort(Comparison<T> comparison)
        {
            if (_count <= 1) return; // No need to sort if the queue has less than or equal to 1
            T[] temp = new T[_count]; // Create a temporary array to hold the items
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _items[(_front + i) % _items.Length]; // Copy items from the queue to the temporary array
            }
            Array.Sort(temp, comparison); // Sort the temporary array using the provided comparison
            for (int i = 0; i < _count; i++)
            {
                _items[(_front + i) % _items.Length] = temp[i]; // Copy sorted items back to the queue
            }
        }

        public bool Search(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[(_front + i) % _items.Length].Equals(item)) // Check each item in the queue
                {
                    return true; // True if the item is found
                }
            }
            return false; // False if the item is not found
        }
    }
}

