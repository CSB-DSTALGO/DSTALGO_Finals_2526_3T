using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top;

        public int Count { get; private set; }

        public CustomStack()
        {
            _items = new T[4];
            _top = -1;
            Count = 0;
        }

        public void Push(T item)
        {
            if (Count == _items.Length)
            {
                T[] newArray = new T[_items.Length * 2];
                Array.Copy(_items, newArray, _items.Length);
                _items = newArray;
            }

            _items[++_top] = item;
            Count++;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            T item = _items[_top];
            _items[_top] = default!;
            _top--;
            Count--;

            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return _items[_top];
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public int Search(T item)
        {
            for (int i = _top; i >= 0; i--)
            {
                if (Equals(_items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Sort()
        {
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new InvalidOperationException("Type must implement IComparable.");

            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - i - 1; j++)
                {
                    IComparable current = (IComparable)_items[j]!;

                    if (current.CompareTo(_items[j + 1]) > 0)
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
