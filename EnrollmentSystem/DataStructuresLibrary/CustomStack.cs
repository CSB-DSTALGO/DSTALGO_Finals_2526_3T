// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top; // number of elements currently on the stack (also the next free slot index)

        public int Count
        {
            get { return _top; }
        }

        // creates the initial array with a capacity of 4
        public CustomStack()
        {
            _items = new T[4];
            _top = 0;
        }

        public void Push(T item)
        {
            // Check if array is full
            if (_top == _items.Length)
            {
                Resize();
            }
            _items[_top] = item; // stores the new item at the top slot
            _top++; // moves the top pointer up
        }

        public T Pop()
        {
            if (IsEmpty()) // checks if there is anything to remove
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            _top--; // moves the top pointer down to the last pushed item
            T item = _items[_top];
            _items[_top] = default!; // clears the slot so it isn't held onto

            return item;
        }

        public T Peek()
        {
            if (IsEmpty()) // checks if there is anything to look at
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return _items[_top - 1]; // returns the topmost item without removing it
        }

        public bool IsEmpty()
        {
            return _top == 0;
        }

        private void Resize()
        {
            T[] newItems = new T[_items.Length * 2]; // create new array with double the length
            for (int i = 0; i < _top; i++) // loop that copies elements from old to new array
            {
                newItems[i] = _items[i];
            }
            _items = newItems; // replace old array with the new array
        }

        // ---------------------------------------------------------------
        // Search and Sort (delegated to by AdministrativeLogs)
        // ---------------------------------------------------------------

        // Linear Search: scans from the top of the stack downward and returns the
        // 1-based distance from the top (1 = the top item itself), or -1 if not found.
        public int Search(T item)
        {
            for (int i = _top - 1; i >= 0; i--)
            {
                if (Equals(_items[i], item)) // reference/value equality check on each element
                {
                    return _top - i; // distance counted from the top of the stack
                }
            }
            return -1; // not found
        }

        // Insertion Sort: rearranges the underlying array in place (bottom to top)
        // according to the given comparison delegate.

        public void Sort(Comparison<T> comparison)
        {
            for (int i = 1; i < _top; i++)
            {
                T key = _items[i];
                int j = i - 1;
                while (j >= 0 && comparison(_items[j], key) > 0)
                {
                    _items[j + 1] = _items[j]; // shift larger element one position to the right
                    j--;
                }
                _items[j + 1] = key; // drop the key into its correct sorted position
            }
        }
    }
}