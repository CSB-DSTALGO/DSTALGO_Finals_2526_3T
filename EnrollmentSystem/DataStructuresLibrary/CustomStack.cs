// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top; 

        private const int DefaultCapacity = 4;

        public int Count
        {
            get { return _top; }
        }

        public CustomStack()
        {
            _items = new T[DefaultCapacity];
            _top = 0;
        }

        private void Resize()
        {
            int newCapacity = _items.Length * 2;
            T[] newItems = new T[newCapacity];

            for (int i = 0; i < _top; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        public void Push(T item)
        {
            if (_top == _items.Length)
            {
                Resize();
            }

            _items[_top] = item;
            _top++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot Pop: the stack is empty.");
            }

            _top--;
            T item = _items[_top];
            _items[_top] = default(T);
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot Peek: the stack is empty.");
            }

            return _items[_top - 1];
        }

        public bool IsEmpty()
        {
            return _top == 0;
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
    }
}