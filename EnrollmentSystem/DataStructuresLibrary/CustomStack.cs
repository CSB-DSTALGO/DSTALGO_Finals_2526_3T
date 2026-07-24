// 12521269 Joaquin Bryan G. Ross
// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T> where T : IComparable<T>
    {
        // Index 0 is the bottom of the stack. _top is the next free slot, so
        // the topmost item lives at _top - 1.
        private T[] _items;
        private int _top;

        public int Count
        {
            get { return _top; }
        }

        // Starts with a small array and an empty top marker.
        public CustomStack()
        {
            _items = new T[4];
            _top = 0;
        }

        // Amortised O(1).
        public void Push(T item)
        {
            if (_top == _items.Length) Resize();
            _items[_top] = item;
            _top++;
        }

        // Removes and returns the top. O(1).
        public T Pop()
        {
            if (_top == 0)
                throw new InvalidOperationException("Cannot pop from an empty stack.");

            _top--;
            T top = _items[_top];
            _items[_top] = default!; // release the duplicate reference in the vacated slot
            return top;
        }

        // Reads the top without removing it. O(1).
        public T Peek()
        {
            if (_top == 0)
                throw new InvalidOperationException("Cannot peek at an empty stack.");

            return _items[_top - 1];
        }

        // True when nothing is stacked. O(1).
        public bool IsEmpty()
        {
            return _top == 0;
        }

        // Linear search from the top down. Returns how deep the item sits,
        // counting the top as 1, or -1 when it is absent. Depth is reported
        // instead of an array index because a caller reasoning about a stack
        // thinks in "how many pops away" terms.
        public int Search(T item)
        {
            for (int i = _top - 1; i >= 0; i--)
            {
                if (Equals(_items[i], item)) return _top - i;
            }

            return -1;
        }

        // Insertion sort, arranged so that popping yields ascending order.
        // That puts the smallest item on top, and because the top is the
        // highest index, the backing array ends up descending bottom to top.
        // Note the comparison is inverted against the other structures.
        public void Sort()
        {
            for (int i = 1; i < _top; i++)
            {
                T key = _items[i];
                int j = i - 1;

                while (j >= 0 && _items[j].CompareTo(key) < 0)
                {
                    _items[j + 1] = _items[j];
                    j--;
                }

                _items[j + 1] = key;
            }
        }

        private void Resize()
        {
            T[] larger = new T[_items.Length * 2];

            for (int i = 0; i < _top; i++)
            {
                larger[i] = _items[i];
            }

            _items = larger;
        }
    }
}
