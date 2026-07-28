using System;

namespace DataStructuresLibrary
{
    public class CustomArrayList<T> 
    {
        private T[] _items;                    // Internal array that holds the actual items
        private int _count;                    // Tracks how many items are currently in the list
        private const int DefaultCapacity = 4; // Sets starting array size to 4

        // Exposes the current number of items safely (read-only)
        public int Count 
        {
            get { return _count; }
        }

        // Initializes a new empty list with the default capacity
        public CustomArrayList()
        {
            _items = new T[DefaultCapacity];
            _count = 0;
        }

        // Adds an item to the end of the list, resizes automatically if full
        public void Add(T item)
        {
            if (_count == _items.Length)  // Is internal array full? 
            {
                Resize();                 // YES, resize
            }
            _items[_count++] = item;      // Place the new item inside the next open slot and increment count
        }


        public T Get(int index)
        {
            if (index < 0 || index >= _count)  // Is index invalid and outside the bounds of the current list?
            {
                throw new IndexOutOfRangeException("Index is out of range."); // YES, throw exception
            }
            return _items[index];
        }

        // Removes item at a specific index, shifts remaining elements to fill the gap
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            for (int i = index; i < _count - 1; i++) // Shifts elements down to overwrite removed element
            {
                _items[i] = _items[i + 1];
            }

            _items[--_count] = default(T)!;          // Decrease count and clear the last slot reference
        }

        // Doubles the internal array's capacity to store more items
        private void Resize()
        {
            int newCapacity = _items.Length * 2;  // Double the size of the current capacity
            T[] newArray = new T[newCapacity];    // Create a larger temporary array
            Array.Copy(_items, newArray, _count); // Copy existing items over to the new array
            _items = newArray;                    // Point the internal reference to the new array
        }
    }
}