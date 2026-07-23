using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top;

        public int Count => _top + 1;

        public CustomStack()
        {
            _items = new T[4];
            _top = -1;
        }

        public void Push(T item)
        {
            if (_top == _items.Length - 1)
            {
                Resize();
            }
            _items[++_top] = item;
        }

        public T Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty.");
            T item = _items[_top];
            _items[_top--] = default!;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty.");
            return _items[_top];
        }

        public bool IsEmpty() => _top == -1;

        private void Resize()
        {
            T[] newArray = new T[_items.Length * 2];
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }

        public T[] GetInternalArray() => _items;
    }
}