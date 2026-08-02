// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    // Custom implementation of a stack using a dynamic array.
    public class CustomStack<T>
    {
        // Backing array that stores the stack elements.
        private T[] _items;

        // Index of the top element in the stack.
        // A value of -1 indicates that the stack is empty.
        private int _top;

        // Returns the current number of elements in the stack.
        public int Count
        {
            get { return _top + 1; }
        }

        // Initializes an empty stack with a default capacity of 4.
        public CustomStack()
        {
            _items = new T[4];
            _top = -1;
        }

        // Pushes a new item onto the top of the stack.
        // Automatically grows the backing array when it becomes full.
        // Time Complexity: O(1) average, O(n) when resizing.
        public void Push(T item)
        {
            if (Count == _items.Length)
            {
                Grow();
            }

            _items[++_top] = item;
        }

        // Removes and returns the item at the top of the stack.
        // Throws an exception if the stack is empty.
        // Time Complexity: O(1)
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot pop: the stack is empty.");
            }

            T item = _items[_top];

            // Clear the reference to help garbage collection.
            _items[_top] = default!;

            _top--;

            return item;
        }

        // Returns the item at the top of the stack
        // without removing it.
        // Time Complexity: O(1)
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot peek: the stack is empty.");
            }

            return _items[_top];
        }

        // Checks whether the stack contains any elements.
        // Returns true if the stack is empty; otherwise, false.
        // Time Complexity: O(1)
        public bool IsEmpty()
        {
            return Count == 0;
        }

        // Doubles the capacity of the backing array
        // when the current array becomes full.
        // Time Complexity: O(n)
        private void Grow()
        {
            T[] biggerArray = new T[_items.Length * 2];

            // Copy all existing elements into the larger array.
            for (int i = 0; i < Count; i++)
            {
                biggerArray[i] = _items[i];
            }

            _items = biggerArray;
        }
    }
}