// CustomStack.cs
// A manually implemented LIFO (Last-In-First-Out) stack backed by a plain array.
using System;

namespace DataStructuresLibrary
{
    /// <summary>
    /// A generic array-based stack implemented from scratch.
    /// </summary>
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top; // number of elements currently on the stack; also the
                           // index just past the top element in _items

        private const int DefaultCapacity = 4;

        /// <summary>
        /// Number of elements currently on the stack.
        /// </summary>
        public int Count
        {
            get { return _top; }
        }

        public CustomStack()
        {
            _items = new T[DefaultCapacity];
            _top = 0;
        }

        /// <summary>
        /// Pushes an item onto the top of the stack. Amortized O(1); occasionally
        /// triggers an O(n) resize when the backing array is full.
        /// </summary>
        public void Push(T item)
        {
            if (_top == _items.Length)
            {
                Resize();
            }

            _items[_top] = item;
            _top++;
        }

        /// <summary>
        /// Removes and returns the item on top of the stack. O(1).
        /// </summary>
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

        /// <summary>
        /// Returns the item on top of the stack without removing it. O(1).
        /// </summary>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _items[_top - 1];
        }

        /// <summary>
        /// True if there are no items currently on the stack.
        /// </summary>
        public bool IsEmpty()
        {
            return _top == 0;
        }

        /// <summary>
        /// Copies the stack's contents (bottom to top) into a plain array without
        /// mutating the stack. Used by higher-level modules that need to inspect
        /// or sort the logs while preserving LIFO semantics afterwards.
        /// </summary>
        public T[] ToArray()
        {
            T[] result = new T[_top];
            for (int i = 0; i < _top; i++)
            {
                result[i] = _items[i];
            }
            return result;
        }

        /// <summary>
        /// Empties the stack back to its initial state. Used together with
        /// ToArray() to rebuild the stack in a new order (e.g. after sorting).
        /// </summary>
        public void Clear()
        {
            _items = new T[DefaultCapacity];
            _top = 0;
        }

        /// <summary>
        /// Doubles the capacity of the backing array and copies existing elements
        /// across. O(n).
        /// </summary>
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
