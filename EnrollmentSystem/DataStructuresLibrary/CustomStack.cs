// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items; // store elements in array
        private int _top;   // index of next available slot / count of items

        public int Count
        {
            get { return _top; } // returns the count of elements in stack
        }

        public CustomStack()
        {
            _items = new T[4]; // initializes array with default size 4
            _top = 0;          // stack starts empty (0 items)
        }

        public void Push(T item)
        {
            if (_top == _items.Length) // resize if full
            {
                Resize();
            }

            _items[_top] = item; // place item at top
            _top++;              // increment top index
        }

        public T Pop()
        {
            if (IsEmpty()) // error handling for empty stack
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            _top--;                             // decrement top index to point to last item
            T item = _items[_top];             // saves item at top to return later
            _items[_top] = default(T)!;         // clears slot / remove reference

            return item;                        // return removed item
        }

        public T Peek() // checks item at top of stack without removing it
        {
            if (IsEmpty()) // error if stack is empty
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _items[_top - 1]; // return top item
        }

        public bool IsEmpty() // checks if stack is empty
        {
            return _top == 0; // returns true if empty, false if not
        }

        private void Resize() // resizes array when stack is full
        {
            T[] newItems = new T[_items.Length * 2]; // creates new array with double the size

            for (int i = 0; i < _top; i++) // copy existing items
            {
                newItems[i] = _items[i];
            }

            _items = newItems; // make _items reference the new larger array
        }

        public int Search(T item, Func<T, T, bool> comparer) // searches item in stack using custom comparer
        {
            for (int i = 0; i < _top; i++)
            {
                if (comparer(_items[i], item)) // check if match
                {
                    return i; // return index if found
                }
            }

            return -1; // return -1 if not found
        }

        public void Sort(Func<T, T, bool> shouldSwap) // sorts items in stack
        {
            for (int i = 0; i < _top - 1; i++)
            {
                for (int j = 0; j < _top - i - 1; j++)
                {
                    if (shouldSwap(_items[j], _items[j + 1])) // check if needs to swap
                    {
                        T temp = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temp;
                    }
                }
            }
        }
    }
}