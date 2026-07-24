using System;

namespace DataStructuresLibrary
{

    public class CustomStack<T> where T : IComparable<T>
    {
        // ==================== PRIVATE FIELDS ====================

        private T[] _array;
        private const int _defaultCapacity = 4;

        // ==================== PUBLIC PROPERTIES ====================
        /// Gets the number of elements contained in the stack
        public int Count { get; private set; }

        // ==================== CONSTRUCTORS ====================
        /// Initializes a new stack with the default capacity
        public CustomStack()
        {
            _array = new T[_defaultCapacity];
            Count = 0;
        }

        /// Initializes a new stack with the specified capacity
        public CustomStack(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity cannot be negative.");

            _array = new T[Math.Max(capacity, _defaultCapacity)];
            Count = 0;
        }

        // ==================== STACK METHODS ====================

        public void Push(T item)
        {
            if (Count == _array.Length)
            {
                Resize(_array.Length * 2);
            }

            _array[Count] = item;
            Count++;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty. Cannot pop.");

            Count--;

            T item = _array[Count];
            _array[Count] = default!;

            if (Count > 0 &&
                Count <= _array.Length / 4 &&
                _array.Length > _defaultCapacity)
            {
                Resize(_array.Length / 2);
            }

            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty. Cannot peek.");

            return _array[Count - 1];
        }

        /// Checks whether the stack is empty
        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// Removes all elements from the stack
        public void Clear()
        {
            _array = new T[_defaultCapacity];
            Count = 0;
        }

        // ==================== SEARCH ALGORITHM (LINEAR SEARCH) ====================

        public int Search(T item)
        {
            int position = 1;

            for (int i = Count - 1; i >= 0; i--)
            {
                if (_array[i].CompareTo(item) == 0)
                    return position;

                position++;
            }

            return -1;
        }

        // ==================== SORTING ALGORITHM (INSERTION SORT) ====================
            /// Sorts the stack elements in ascending order
        public void Sort()
        {
            for (int i = 1; i < Count; i++)
            {
                T key = _array[i];
                int j = i - 1;

                while (j >= 0 && _array[j].CompareTo(key) < 0)
                {
                    _array[j + 1] = _array[j];
                    j--;
                }

                _array[j + 1] = key;
            }
        }

        // ==================== PRIVATE HELPER METHODS ====================

        private void Resize(int newCapacity)
        {
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < Count; i++)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }

        // ==================== OVERRIDE ====================

        public override string ToString()
        {
            if (IsEmpty())
                return "Stack is empty.";

            string result = "[ ";

            for (int i = Count - 1; i >= 0; i--)
            {
                result += _array[i];

                if (i > 0)
                    result += ", ";
            }

            result += " ]";

            return result;
        }
    }
}