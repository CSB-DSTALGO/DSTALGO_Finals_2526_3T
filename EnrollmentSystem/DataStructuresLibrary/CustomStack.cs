// CustomStack.cs
using System;
namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top; // number of items currently in the stack

        public int Count
        {
            get { return _top; }
        }

        public CustomStack()
        {
            _items = new T[4]; // starting capacity
            _top = 0;
        }

        // Pushes an item onto the top of the stack
        public void Push(T item)
        {
            if (_top == _items.Length)
                Resize();
            _items[_top] = item;
            _top++;
        }

        // Removes and returns the top item
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            _top--;
            return _items[_top];
        }

        // Returns the top item without removing it
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return _items[_top - 1];
        }

        // Returns true if the stack has no items
        public bool IsEmpty()
        {
            return _top == 0;
        }

        // Doubles the internal array size when full
        private void Resize()
        {
            T[] bigger = new T[_items.Length * 2];
            for (int i = 0; i < _top; i++)
                bigger[i] = _items[i];
            _items = bigger;
        }
    }
}