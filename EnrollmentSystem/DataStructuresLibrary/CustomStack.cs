// CustomStack.cs
using System;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top; // number of items currently in the stack

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
                throw new InvalidOperationException("Cannot Pop from an empty stack.");
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
                throw new InvalidOperationException("Cannot Peek an empty stack.");
            }

            return _items[_top - 1];
        }

        public bool IsEmpty()
        {
            return _top == 0;
        }

        // Linear search through the stack's current items.
        // Returns the index of the first match (0 = bottom of stack),
        // or -1 if the item isn't found.
        public int Search(T item)
        {
            var comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < _top; i++)
            {
                if (comparer.Equals(_items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        // Overload that lets the caller search using custom matching logic,
        // e.g. stack.Search(log => log.LogId == "L123")
        public int Search(Predicate<T> match)
        {
            for (int i = 0; i < _top; i++)
            {
                if (match(_items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        // Sorts the items currently in the stack, in place, using the given comparer.
        // If no comparer is provided, falls back to the default comparer for T
        // (works automatically for built-in types like int, string, etc.).
        public void Sort(IComparer<T> comparer = null)
        {
            comparer ??= Comparer<T>.Default;

            // Simple insertion sort - fine for typical assignment-sized data,
            // and stable (keeps equal elements in their original relative order).
            for (int i = 1; i < _top; i++)
            {
                T key = _items[i];
                int j = i - 1;

                while (j >= 0 && comparer.Compare(_items[j], key) > 0)
                {
                    _items[j + 1] = _items[j];
                    j--;
                }

                _items[j + 1] = key;
            }
        }

        // Overload that lets the caller sort using a custom comparison,
        // e.g. stack.Sort((a, b) => string.Compare(a.LogId, b.LogId))
        public void Sort(Comparison<T> comparison)
        {
            Sort(Comparer<T>.Create(comparison));
        }

        private void Resize()
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < _top; i++)
            {
                newArray[i] = _items[i];
            }

            _items = newArray;
        }
    }
}