using System;

namespace DataStructuresLibrary
{
    // Custom array-based Stack (LIFO: Last In, First Out).
    // Built manually without System.Collections.Generic, as required.
    public class CustomStack<T>
    {
        private T[] _items;   // backing array
        private int _top;     // index of the current top item, -1 if empty

        private const int DefaultCapacity = 4;

        // Number of items currently in the stack.
        public int Count
        {
            get { return _top + 1; }
        }

        public CustomStack()
        {
            _items = new T[DefaultCapacity];
            _top = -1;
        }

        // Adds an item to the top of the stack. Resizes if the array is full.
        public void Push(T item)
        {
            if (_top + 1 == _items.Length)
            {
                Resize();
            }

            _top++;
            _items[_top] = item;
        }

        // Removes and returns the top item. Throws if the stack is empty.
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot Pop: the stack is empty.");
            }

            T item = _items[_top];
            _items[_top] = default!;
            _top--;
            return item;
        }

        // Returns the top item without removing it. Throws if the stack is empty.
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot Peek: the stack is empty.");
            }

            return _items[_top];
        }

        // Returns true if the stack has no items.
        public bool IsEmpty()
        {
            return _top == -1;
        }

        // Returns a copy of all items, ordered top to bottom.
        // Used for sorting/searching without disturbing the real stack.
        public T[] ToArray()
        {
            T[] snapshot = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                snapshot[i] = _items[_top - i];
            }
            return snapshot;
        }

        // Doubles the array's capacity when full.
        private void Resize()
        {
            int newCapacity = _items.Length * 2;
            T[] newArray = new T[newCapacity];
            for (int i = 0; i < _items.Length; i++)
            {
                newArray[i] = _items[i];
            }
            _items = newArray;
        }
    }
}