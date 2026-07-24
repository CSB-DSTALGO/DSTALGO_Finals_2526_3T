// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top;

<<<<<<< HEAD
        public int Count => _top;
=======
        public int Count 
        {
            get { return _top; }
        }
>>>>>>> e876f7d5389e57616ccf8699a0a73c151963e55d

        public CustomStack(int initialCapacity = 4)
        {
<<<<<<< HEAD
            _items = new T[initialCapacity];
=======
            _items = new T[4];
>>>>>>> e876f7d5389e57616ccf8699a0a73c151963e55d
            _top = 0;
        }

        public void Push(T item)
<<<<<<< HEAD
        {
            if (_top == _items.Length)
            {
                Resize();
            }

            _items[_top++] = item;
=======
        {            
            if (_top == _items.Length)
            {
                T[] newItems = new T[_items.Length * 2];

                for (int i = 0; i < _items.Length; i++)
                {
                    newItems[i] = _items[i];
                }

                _items = newItems;
            }

            _items[_top] = item;
            _top++;
>>>>>>> e876f7d5389e57616ccf8699a0a73c151963e55d
        }

        public T Pop()
        {
            if (IsEmpty())
            {
<<<<<<< HEAD
                throw new InvalidOperationException("Stack is empty");
            }

            return _items[--_top];
=======
                throw new InvalidOperationException("Stack is empty.");
            }

            _top--;
            return _items[_top];
>>>>>>> e876f7d5389e57616ccf8699a0a73c151963e55d
        }

        public T Peek()
        {
            if (IsEmpty())
            {
<<<<<<< HEAD
                throw new InvalidOperationException("Stack is empty");
=======
                throw new InvalidOperationException("Stack is empty.");
>>>>>>> e876f7d5389e57616ccf8699a0a73c151963e55d
            }

            return _items[_top - 1];
        }

        public bool IsEmpty() => _top == 0;

        private void Resize()
        {
<<<<<<< HEAD
            var doubled = new T[_items.Length * 2];
            Array.Copy(_items, doubled, _items.Length);
            _items = doubled;
=======
            return _top == 0;
        }

        public int Search(T item)
        {
            for (int i = 0; i < _top; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void SortById()
        {

>>>>>>> e876f7d5389e57616ccf8699a0a73c151963e55d
        }
    }
}