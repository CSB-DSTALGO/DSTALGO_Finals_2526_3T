using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top;

        public int Count => _top;

        public CustomStack(int initialCapacity = 4)
        {
            if (initialCapacity <= 0)
                initialCapacity = 4;

            _items = new T[initialCapacity];
            _top = 0;
        }

        public void Push(T item)
        {
            if (_top == _items.Length)
            {
                Resize();
            }

            _items[_top++] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            _top--;
            T item = _items[_top];
            _items[_top] = default!;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _items[_top - 1];
        }

        public bool IsEmpty()
        {
            return _top == 0;
        }

        public int Search(T target, Comparison<T> comparer)
        {
            for (int i = 0; i < _top; i++)
            {
                if (comparer(_items[i], target) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Sort(Comparison<T> comparer)
        {
            for (int i = 1; i < _top; i++)
            {
                T key = _items[i];
                int j = i - 1;

                while (j >= 0 && comparer(_items[j], key) > 0)
                {
                    _items[j + 1] = _items[j];
                    j--;
                }

                _items[j + 1] = key;
            }
        }

        private void Resize()
        {
            int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;

            T[] newItems = new T[newCapacity];
            Array.Copy(_items, newItems, _items.Length);

            _items = newItems;
        }
    }
}