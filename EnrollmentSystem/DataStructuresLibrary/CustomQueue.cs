// CustomQueue.cs
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
            _items = new T[_count]; // Initialize the array with a default size
            _front = 0; // Front index starts at 0
            _rear = 0; // Rear index starts at 0
            _count = 0; // The queue is initially empty
        }

        // Adds an item to the end of the queue
        public void Enqueue(T item)
        {
            _items[_rear] = item; // Insert the item to the rear
            _rear = (_rear + 1) % _items.Length; // This moves the rear index forward and wraps around to use the empty space at the front if needed
            _count++;
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

            return item;
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
    }
}