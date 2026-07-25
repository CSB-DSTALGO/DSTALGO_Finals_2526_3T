// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T> where T : IComparable<T>
    {
        private T[] _items;
        private int _top;

        public int Count
        {
            get { return _top + 1; }
        }

        public CustomStack()
        {
            _items = new T[0];
            _top = -1;
        }

        // Pushes an item onto the top of the stack.
        public void Push(T item)
        {
            if (_top + 1 == _items.Length)
            {
                Resize();
            }

            _top++;
            _items[_top] = item;
        }

        // Removes and returns the top item.
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T item = _items[_top];
            _top--;

            return item;
        }

        // Returns the top item without removing it.
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _items[_top];
        }

        // Checks whether the stack is empty.
        public bool IsEmpty()
        {
            return _top == -1;
        }

        // Increases the array capacity by one intially then multiplied by 2 onwards.
        private void Resize()
        {
            T[] newItems = new T[_items.Length == 0 ? 1 : _items.Length * 2];

            for (int i = 0; i <= _top; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        // Searches for an item in the stack.
        public bool Search(T item)
        {
            for (int i = 0; i <= _top; i++)
            {
                if (_items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        // Sorts the stack in ascending order.
        public void Sort()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - i - 1; j++)
                {
                    if (_items[j].CompareTo(_items[j + 1]) > 0)
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