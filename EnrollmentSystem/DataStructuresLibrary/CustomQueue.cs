using System;

namespace DataStructuresLibrary
{
    public class CustomQueue<T>
    {
        // Internal array to hold items
        private T[] _items;
        // Index of the front element (next to be dequeued)
        private int _front;
        // Index of the rear element (last enqueued)
        private int _rear;
        // Current number of elements in the queue
        private int _count;
        // Maximum capacity of the queue
        private int _capacity;

        // Public property to expose the number of items
        public int Count
        {
            get { return _count; }
        }

        // Constructor: initializes the queue with a given capacity (default 10)
        public CustomQueue(int capacity = 10)
        {
            if (capacity <= 0)
                throw new ArgumentException("Queue capacity must be greater than zero.");

            _capacity = capacity;
            _items = new T[_capacity];
            _front = 0;   // start at index 0
            _rear = -1;   // rear is -1 until first enqueue
            _count = 0;   // queue starts empty
        }

        // Adds an item to the rear of the queue
        public void Enqueue(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Cannot enqueue: Queue is full.");

            // Move rear forward in circular fashion
            _rear = (_rear + 1) % _capacity;
            _items[_rear] = item;
            _count++;
        }

        // Removes and returns the item at the front of the queue
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot dequeue: Queue is empty.");

            T value = _items[_front];
            _items[_front] = default(T); // clear slot (avoid memory leaks for reference types)
            _front = (_front + 1) % _capacity; // move front forward circularly
            _count--;
            return value;
        }

        // Returns the item at the front without removing it
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot peek: Queue is empty.");

            return _items[_front];
        }
        // Checks if the queue has no items
        public bool IsEmpty()
        {
            return _count == 0;
        }

        // Checks if the queue is at full capacity
        public bool IsFull()
        {
            return _count == _capacity;
        }

        // Displays all items in the queue (for debugging/demo purposes)
        public void ShowAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            Console.WriteLine("Queue contents:");
            for (int i = 0; i < _count; i++)
            {
                int index = (_front + i) % _capacity; // circular traversal
                Console.WriteLine(_items[index]);
            }
        }
    }
}