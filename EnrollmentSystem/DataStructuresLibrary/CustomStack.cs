// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    // Custom implementation of a stack using a dynamic array.
    public class CustomStack<T>
    {
        // Backing array that stores the stack elements.
        private T[] _items;
        private int _top;

        // Returns the current number of elements in the stack.
        public int Count
        {
            get { return _top; }
        }

        // Initializes an empty stack with a default capacity of 4.
        public CustomStack()
        {
            _items = new T[4];
            _top = 0;
        }

        // Pushes a new item onto the top of the stack.
        // Automatically grows the backing array when it becomes full.
        // Time Complexity: O(1) average, O(n) when resizing.
        public void Push(T item)
        {
            if (_top == _items.Length)
            {
                Resize();
            }

            _items[_top] = item;
            _top++;
        }

        // Removes and returns the item at the top of the stack.
        // Throws an exception if the stack is empty.
        // Time Complexity: O(1)
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("the stack is empty.");
            }

            _top--;
            
            T item = _items[_top];

            _items[_top] = default!;
            
            return item;
        }

        // Returns the item at the top of the stack
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot peek: the stack is empty.");
            }

            return _items[_top - 1];
        }

        // Checks whether the stack contains any elements.
        // Returns true if the stack is empty; otherwise, false.
        // Time Complexity: O(1)
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public int Search(T item)
        {
            for (int i = 0; i < _top; i++)
            {
                if (object.Equals(_items[i], item))
                {
                    return i;
                }
            }
            return -1; // Item not found
        }
        private void Resize()
        {
           int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
           var newItems = new T[newCapacity];

           for (int i = 0; i < _top; i++)
              {
                 newItems[i] = _items[i];
              }
           _items = newItems;
        }
    }
}