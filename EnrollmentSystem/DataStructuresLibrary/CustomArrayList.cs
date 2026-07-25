// CustomArrayList.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomArrayList<T>
    {
        private T[] _items;
        private int _count;

        // Returns the number of elements currently stored.
        public int Count
        {
            get { return _count; }
        }

        // Initializes the array with a starting capacity of 2.
        public CustomArrayList()
        {
            _items = new T[2];
            _count = 0;
        }

        // Adds a new item to the end of the list.
        public void Add(T item)
        {
            // If the array is full, increase its capacity.
            if (_count == _items.Length)
            {
                Resize();
            }

            // Store the item in the next available position.
            _items[_count] = item;

            // Increase the number of stored elements.
            _count++;
        }

        // Returns the item at the specified index.
        public T Get(int index)
        {
            // Check if the index is valid.
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            // Return the requested item.
            return _items[index];
        }

        // Removes the item at the specified index.
        public void RemoveAt(int index)
        {
            // Check if the index is valid.
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            // Shift all elements after the removed item
            // one position to the left.
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            // Decrease the number of elements.
            _count--;

            // Clear the unused last element.
            _items[_count] = default(T);
        }

        // Doubles the size of the internal array.
        private void Resize()
        {
            // Create a new array with twice the capacity.
            T[] NewArray = new T[_items.Length * 2];

            // Copy all existing elements into the new array.
            for (int i = 0; i < _items.Length; i++)
            {
                NewArray[i] = _items[i];
            }

            // Replace the old array with the new one.
            _items = NewArray;
        }

        // Replaces the item at the specified index.
        public void Set(int index, T item)
        {
            // Check if the index is valid.
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException();
            }

            // Update the value at the specified index.
            _items[index] = item;
        }
    }
}