using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        // _top will represent the index of the topmost element. 
        // -1 means the stack is empty.
        private int _top; 

        private const int DefaultCapacity = 4;

        public int Count 
        { 
            get { return _top + 1; } 
        }

        public CustomStack()
        {
            _items = new T[DefaultCapacity];
            _top = -1;
        }

        public void Push(T item)
        {
            // Resize the array if it's full
            if (_top == _items.Length - 1)
            {
                int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
                Array.Resize(ref _items, newCapacity);
            }
            
            _top++;
            _items[_top] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            
            T item = _items[_top];
            _items[_top] = default(T); // Clear the reference for garbage collection
            _top--;
            
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            
            return _items[_top];
        }

        public bool IsEmpty()
        {
            return _top == -1;
        }

        public int Search(T item)
        {
            for (int i = _top; i >= 0; i--)
            {
                if (_items[i].Equals(item))
                {
                    return _top - i + 1; // Return the position from the top (1-based index)
                }
            }
            return -1; // Item not found
        }

        public void Sort()
        {
            if (Count <= 1) return;

            // Create a temporary array to hold the stack elements
            T[] tempArray = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                tempArray[i] = _items[i];
            }

            // Sort the temporary array
            Array.Sort(tempArray);

            // Copy the sorted elements back to the stack
            for (int i = 0; i < Count; i++)
            {
                _items[i] = tempArray[i];
            }
        }
    }
}