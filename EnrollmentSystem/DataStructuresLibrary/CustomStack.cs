// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    // A manually implemented, array-backed, generic LIFO (Last-In-First-Out) stack.
    // Built from scratch without System.Collections.Generic, per project requirements.
    public class CustomStack<T>
    {
        // Backing array that holds the stack elements.
        private T[] _items;

        // Index of the next free slot; also doubles as the current element count.
        private int _top;

        // Starting size of the backing array before any growth occurs.
        private const int DefaultCapacity = 4;

        // Number of elements currently stored in the stack. O(1).
        public int Count
        {
            get { return _top; }
        }

        // Creates an empty stack with the default starting capacity.
        public CustomStack()
        {
            _items = new T[DefaultCapacity];
            _top = 0;
        }

        // Doubles the capacity of the backing array when it becomes full.
        // Copies existing elements into the new array, preserving order.
        // Time complexity: O(n) for the copy, but amortized O(1) per Push
        // over many pushes, since resizing happens only occasionally.
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

        // Pushes an item onto the top of the stack.
        // Grows the backing array first if it is already full.
        // Time complexity: O(1) amortized, O(n) on the rare resize call.
        public void Push(T item)
        {
            if (_top == _items.Length)
            {
                Resize();
            }

            _items[_top] = item;
            _top++;
        }

        // Removes and returns the item at the top of the stack.
        // Throws if the stack is empty, since there is nothing to remove.
        // Time complexity: O(1).
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

        // Returns the item at the top of the stack without removing it.
        // Throws if the stack is empty, since there is nothing to view.
        // Time complexity: O(1).
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot Peek: the stack is empty.");
            }

            return _items[_top - 1];
        }

        // Reports whether the stack currently holds any elements.
        // Time complexity: O(1).
        public bool IsEmpty()
        {
            return _top == 0;
        }

        // Sorts the stack's elements in ascending order using Insertion Sort.
        //
        // Mechanism: starting from the second element, each item ("key") is
        // compared backward against the already sorted portion of the array
        // and shifted right until its correct position is found, then dropped
        // into place. This repeats until the whole array is sorted in place.
        //
        // Time complexity:
        // Best case: O(n)  - array is already sorted, inner loop never shifts.
        // Average case: O(n^2) - roughly half the elements get shifted each pass.
        // Worst case: O(n^2) - array is in reverse order, maximum shifting.
        // Space complexity: O(1) extra space - sorts in place, no auxiliary array.
        // Insertion Sort was chosen because stack contents are typically small
        // and often nearly-ordered (e.g. logs pushed close to chronological order),
        // which plays to its O(n) best-case strength.
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

        // Searches for the first element matching target and returns its index,
        // or -1 if no match is found.
        //
        // Mechanism: a straightforward Linear Search - walks the array from
        // index 0 to _top-1, comparing each slot against target using the
        // supplied comparer, and stops as soon as a match is found.
        //
        // Time complexity:
        // Best case: O(1) - target is the first element checked.
        // Average case: O(n) - target is found roughly halfway through.
        // Worst case: O(n) - target is the last element, or absent entirely.
        // Space complexity: O(1) - no extra memory used.
        // Linear Search is used (rather than binary search) because a stack's
        // contents are not guaranteed to be sorted at the time of the search;
        // callers who need faster lookups should call Sort() first.
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