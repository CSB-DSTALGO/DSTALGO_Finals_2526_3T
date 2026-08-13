// CustomArrayList.cs
// A manually implemented, dynamically resizing array-based list.
// Mimics the core behavior of List<T> without relying on System.Collections.Generic.
using System;

namespace DataStructuresLibrary
{
    /// <summary>
    /// A generic, dynamically resizable array-based list implemented from scratch.
    /// Backed by a plain T[] array that doubles in size whenever it runs out of room.
    /// </summary>
    public class CustomArrayList<T>
    {
        // Internal backing storage. Only the first _count slots hold "live" data;
        // anything from _count to _items.Length - 1 is unused capacity.
        private T[] _items;
        private int _count;

        // Starting size for a brand-new list. Small so an empty list is cheap,
        // but big enough that we don't resize immediately after the first Add.
        private const int DefaultCapacity = 4;

        /// <summary>
        /// Number of elements currently stored in the list (not the same as the
        /// underlying array's physical capacity).
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// The current physical size of the backing array. Exposed mainly so tests
        /// can verify that Resize() actually grows the array when needed.
        /// </summary>
        public int Capacity
        {
            get { return _items.Length; }
        }

        /// <summary>
        /// Creates an empty list with a small starting capacity.
        /// </summary>
        public CustomArrayList()
        {
            _items = new T[DefaultCapacity];
            _count = 0;
        }

        /// <summary>
        /// Appends an item to the end of the list in amortized O(1) time.
        /// Triggers a resize (O(n)) whenever the backing array is full.
        /// </summary>
        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            _items[_count] = item;
            _count++;
        }

        /// <summary>
        /// Returns the element stored at the given index. O(1) because arrays
        /// support direct random access.
        /// </summary>
        public T Get(int index)
        {
            ValidateIndex(index);
            return _items[index];
        }

        /// <summary>
        /// Overwrites the element stored at the given index. O(1). This is not part
        /// of the original required signature list, but is provided so higher-level
        /// modules (e.g. StudentRegistry's sorting routine) can rearrange elements
        /// in place without needing to Remove/Add.
        /// </summary>
        public void Set(int index, T item)
        {
            ValidateIndex(index);
            _items[index] = item;
        }

        /// <summary>
        /// Removes the element at the given index by shifting every element after
        /// it one position to the left. O(n) in the worst case because of the shift.
        /// </summary>
        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            // Clear the now-unused trailing slot so we don't keep a stray reference alive.
            _items[_count - 1] = default!;
            _count--;
        }

        /// <summary>
        /// Doubles the capacity of the backing array and copies existing elements
        /// across. O(n) - this cost is amortized across many Add calls, which is
        /// why Add is described as amortized O(1) rather than strict O(1).
        /// </summary>
        private void Resize()
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _items[i];
            }

            _items = newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is outside the bounds of the list.");
            }
        }
    }
}
