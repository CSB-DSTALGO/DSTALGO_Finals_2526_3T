using System;

namespace DataStructuresLibrary
{
    /// <summary>
    /// Custom dynamic array list implementation developed without using System.Collections.Generic.
    /// Manages internal memory allocation, dynamic resizing, element shifting, QuickSort, and Binary Search.
    /// </summary>
    /// <typeparam name="T">The data type of elements stored in the custom array.</typeparam>
    public class CustomArrayList<T>
    {
        // Backing fixed-size array storing current items
        private T[] _items;

        // Tracks current count of populated elements
        private int _count;

        /// <summary>
        /// Gets the active element count currently stored in the array list.
        /// </summary>
        public int Count 
        { 
            get { return _count; } 
        }

        /// <summary>
        /// Initializes a new instance of CustomArrayList with a custom or default capacity.
        /// </summary>
        /// <param name="initialCapacity">Starting internal array capacity (defaults to 4).</param>
        public CustomArrayList(int initialCapacity = 4)
        {
            if (initialCapacity <= 0)
            {
                initialCapacity = 4;
            }

            _items = new T[initialCapacity];
            _count = 0;
        }

        /// <summary>
        /// Appends an element to the end of the dynamic array list. Triggers array resize if full.
        /// </summary>
        /// <param name="item">The element to add.</param>
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
        /// Retrieves the element stored at a zero-based index position.
        /// </summary>
        /// <param name="index">Zero-based index position.</param>
        /// <returns>Element located at target index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if index is outside bounds [0, Count - 1].</exception>
        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is outside valid array bounds.");
            }

            return _items[index];
        }

        /// <summary>
        /// Removes the item at the specified index and shifts subsequent elements left by one slot.
        /// </summary>
        /// <param name="index">Zero-based index position to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if index is outside bounds [0, Count - 1].</exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is outside valid array bounds.");
            }

            // Left-shift elements past the target index to overwrite deleted item
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            // Clear former tail reference
            _items[_count - 1] = default(T)!;
            _count--;
        }

        /// <summary>
        /// Sorts internal array in-place using the QuickSort algorithm and a custom comparison delegate.
        /// </summary>
        /// <param name="comparer">Delegate function comparing two items (returns negative, zero, or positive integer).</param>
        public void QuickSort(Func<T, T, int> comparer)
        {
            if (_count <= 1) return;
            QuickSortInternal(0, _count - 1, comparer);
        }

        /// <summary>
        /// Recursive helper method executing partition and divide-and-conquer steps for QuickSort.
        /// </summary>
        private void QuickSortInternal(int low, int high, Func<T, T, int> comparer)
        {
            if (low < high)
            {
                int pivotIndex = Partition(low, high, comparer);
                QuickSortInternal(low, pivotIndex - 1, comparer);
                QuickSortInternal(pivotIndex + 1, high, comparer);
            }
        }

        /// <summary>
        /// Partitions array section around a pivot element.
        /// </summary>
        private int Partition(int low, int high, Func<T, T, int> comparer)
        {
            T pivot = _items[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (comparer(_items[j], pivot) <= 0)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, high);
            return i + 1;
        }

        /// <summary>
        /// Swaps positions of two elements inside internal array.
        /// </summary>
        private void Swap(int i, int j)
        {
            T temp = _items[i];
            _items[i] = _items[j];
            _items[j] = temp;
        }

        /// <summary>
        /// Searches sorted array using Binary Search algorithm and custom search key comparison.
        /// </summary>
        /// <typeparam name="TKey">Data type of search lookup key.</typeparam>
        /// <param name="key">Search target key value.</param>
        /// <param name="keySelector">Function extracting lookup key from stored element.</param>
        /// <param name="keyComparer">Function comparing extracted key with search target key.</param>
        /// <returns>Zero-based index of matched element, or -1 if not found.</returns>
        public int BinarySearch<TKey>(TKey key, Func<T, TKey> keySelector, Func<TKey, TKey, int> keyComparer)
        {
            int low = 0;
            int high = _count - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                TKey midKey = keySelector(_items[mid]);
                int comparison = keyComparer(midKey, key);

                if (comparison == 0)
                {
                    return mid; // Target match found
                }
                if (comparison < 0)
                {
                    low = mid + 1; // Target lies in upper right half
                }
                else
                {
                    high = mid - 1; // Target lies in lower left half
                }
            }

            return -1; // Target not found
        }

        /// <summary>
        /// Private memory management routine doubling internal capacity upon saturation.
        /// </summary>
        private void Resize()
        {
            int newCapacity = _items.Length * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _items[i];
            }

            _items = newArray;
        }
    }
}

      