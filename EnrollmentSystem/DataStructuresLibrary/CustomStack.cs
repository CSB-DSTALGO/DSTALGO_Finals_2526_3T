// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top;

        public int Count
        {
            get { return _top + 1; } // top index plus 1 gives the actual count
        }

        public CustomStack()
        {
            _items = new T[4];
            _top = -1; // -1 means empty
        }

        public void Push(T item)
        {
            if (_top == _items.Length - 1) // if array is full
            {
                Resize();
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
            _items[_top] = default!; //clear the memory slot
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

        private void Resize()
        {
            T[] newArray = new T[_items.Length * 2]; //double the size
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }

        public T[] GetInternalArray()
        {
            return _items;
        }

        // Bubble Sort
        // Loops through active items only and swaps adjacent elements if out of order.
        public void Sort(Comparison<T> comparison)
        {
            if (Count <= 1) return;

            for (int i = 0; i < Count - 1; i++) //outer loop
            {
                for (int j = 0; j < Count - i - 1; j++) // inner loop for comparing
                {
                    if (comparison(_items[j], _items[j + 1]) > 0) // if out of order
                    {
                        T temp = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temp;
                    }
                }
            }
        }

        // Reverse Linear Search
        // Scans the array backwards from _top down to index 0.
        public T? Search(Func<T, bool> match)
        {
            for (int i = _top; i >= 0; i--) // starts at top and goes down
            {
                if (match(_items[i])) return _items[i]; // returns if match is found
            }
            return default;
        }
    }
}