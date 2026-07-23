// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        // We use a standard array behind the scenes, and a pointer (_top) 
        // to keep track of where the most recent item is sitting.
        private T[] _items;
        private int _top;

        public int Count
        {
            get { return _top + 1; }
        }

        public CustomStack()
        {
            // We start out with a small capacity of 4. 
            // A top of -1 just means the stack is completely empty right now.
            _items = new T[4];
            _top = -1;
        }

        public void Push(T item)
        {
            // If we run out of room, we automatically double the array size 
            // so we never accidentally crash when adding new items.
            if (_top == _items.Length - 1)
            {
                Resize();
            }

            // Bump the top pointer up and drop our new item into that slot.
            _top++;
            _items[_top] = item;
        }

        public T Pop()
        {
            // We have to check if it's empty first so we don't try to pull 
            // data from a negative index and crash the program.
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty.");

            T item = _items[_top];
            _items[_top] = default!; // Clear out the memory slot to keep things clean
            _top--;

            return item;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty.");

            // Just look at the top item, but leave it exactly where it is.
            return _items[_top];
        }

        public bool IsEmpty()
        {
            return _top == -1;
        }

        private void Resize()
        {
            // Create a bigger array and copy all the old data over.
            T[] newArray = new T[_items.Length * 2];
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }

        public T[] GetInternalArray()
        {
            return _items;
        }

    
        public void Sort(Comparison<T> comparison)
        {
         
            if (Count <= 1) return;

            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - i - 1; j++)
                {
                    if (comparison(_items[j], _items[j + 1]) > 0)
                    {
                        // Swap them if they are out of order
                        T temp = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temp;
                    }
                }
            }
        }

        public T? Search(Func<T, bool> match)
        {

            for (int i = _top; i >= 0; i--)
            {
                if (match(_items[i])) return _items[i];
            }
            return default;
        }
    }
}