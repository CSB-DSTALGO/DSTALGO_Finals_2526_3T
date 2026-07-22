using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top;

        public int Count
        {
            get { return _top + 1; }
        }

        public CustomStack()
        {
            _items = new T[10];
            _top = -1;
        }

        public void Push(T item)
        {
            if (_top == _items.Length - 1)
            {
                T[] newArray = new T[_items.Length * 2];

                for (int i = 0; i < _items.Length; i++)
                {
                    newArray[i] = _items[i];
                }

                _items = newArray;
            }

            _items[++_top] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return _items[_top--];
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return _items[_top];
        }

        public bool IsEmpty()
        {
            return _top == -1;
        }
    }
}