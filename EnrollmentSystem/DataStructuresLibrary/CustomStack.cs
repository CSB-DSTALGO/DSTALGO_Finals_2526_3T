using System;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _count;

        public int Count => _count;

        public CustomStack()
        {
            _items = new T[4];
            _count = 0;
        }

        public void Push(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            _items[_count] = item;
            _count++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            _count--;
            T item = _items[_count];
            _items[_count] = default!;

            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return _items[_count - 1];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool Search(T item)
        {
            for (int i = _count - 1; i >= 0; i--)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], item))
                {
                    return true;
                }
            }

            return false;
        }

        public void Sort()
        {
            for (int i = 1; i < _count; i++)
            {
                T current = _items[i];
                int j = i - 1;

                while (j >= 0 &&
                       Comparer<T>.Default.Compare(_items[j], current) > 0)
                {
                    _items[j + 1] = _items[j];
                    j--;
                }

                _items[j + 1] = current;
            }
        }

        private void Resize()
        {
            T[] newItems = new T[_items.Length * 2];

            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }
    }
}