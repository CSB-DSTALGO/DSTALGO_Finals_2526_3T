// CustomStack.cs
using System;
namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top;
        private int _capacity;

        // Returns how many items are currently in the stack.
        public int Count
        {
            get { return _top; }
        }

        // Initializes an empty stack with a default starting capacity.
        public CustomStack()
        {
            _capacity = 4;
            _items = new T[_capacity];
            _top = 0;
        }

        // Pushes an item onto the top of the stack. Resizes if full.
        public void Push(T item)
        {
            if (_top == _capacity)
            {
                Resize();
            }

            _items[_top] = item;
            _top++;
        }

        // Removes and returns the item at the top of the stack.
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot pop from an empty stack.");

            _top--;
            T item = _items[_top];
            _items[_top] = default!;
            return item;
        }

        // Returns the top item without removing it.
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot peek an empty stack.");

            return _items[_top - 1];
        }

        // Returns true if the stack has no elements.
        public bool IsEmpty()
        {
            return _top == 0;
        }

        // Returns a snapshot array of items in bottom-to-top order.
        // Used by AdministrativeLogs for sorting/searching without breaking encapsulation.
        public T[] ToArray()
        {
            T[] result = new T[_top];
            for (int i = 0; i < _top; i++)
            {
                result[i] = _items[i];
            }
            return result;
        }

        // Doubles the array size when full.
        private void Resize()
        {
            T[] newItems = new T[_capacity * 2];
            for (int i = 0; i < _top; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
            _capacity *= 2;
        }
    }
}