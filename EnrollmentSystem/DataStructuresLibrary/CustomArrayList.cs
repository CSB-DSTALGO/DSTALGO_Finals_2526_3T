using System;

namespace DataStructuresLibrary
{
    // Our own dynamic array - grows automatically when full
    // Added Quick Sort and Binary Search
    public class CustomArrayList<T>
    {
        private T[] _items;      // Array that stores the data
        private int _count;      // How many items currently stored
        private const int DefaultCapacity = 4;  // Start small, double when full

        // Property to check how many items
        public int Count
        {
            get { return _count; }
        }

        // Constructor - make empty array with default size
        public CustomArrayList()
        {
            _items = new T[DefaultCapacity];
            _count = 0;
        }

        // Add item to the end. Resize if array is full
        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }
            _items[_count] = item;
            _count++;
        }

        // Get item at index. Throw error if bad index
        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range. Count: {_count}");
            }
            return _items[index];
        }

        // Remove item at index. Shift everything left to fill gap
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range. Count: {_count}");
            }

            // Shift left
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            // Clear last slot for garbage collector
            _items[_count - 1] = default!;
            _count--;
        }

        // Quick Sort - divide and conquer sorting
        // Pick pivot, put smaller left and bigger right, repeat
        // Time: O(n log n) average, O(n²) worst
        public void QuickSort(Comparison<T> compare)
        {
            if (_count <= 1) return;
            QuickSortHelper(0, _count - 1, compare);
        }

        // Binary Search - fast search on sorted data
        // Keep cutting search space in half
        // IMPORTANT: Must sort first!
        // Time: O(log n)
        public int BinarySearch(T item, Comparison<T> compare)
        {
            int left = 0;
            int right = _count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = compare(_items[mid], item);

                if (comparison == 0)
                {
                    return mid;  // Found!
                }
                else if (comparison < 0)
                {
                    left = mid + 1;  // Go right
                }
                else
                {
                    right = mid - 1;  // Go left
                }
            }

            return -1;  // Not found
        }

        // Double array size when full
        private void Resize()
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(_items, newItems, _count);
            _items = newItems;
        }

        // Recursive quick sort helper
        private void QuickSortHelper(int low, int high, Comparison<T> compare)
        {
            if (low < high)
            {
                int pivotIndex = Partition(low, high, compare);
                QuickSortHelper(low, pivotIndex - 1, compare);
                QuickSortHelper(pivotIndex + 1, high, compare);
            }
        }

        // Move items around pivot, return pivot final position
        private int Partition(int low, int high, Comparison<T> compare)
        {
            T pivot = _items[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (compare(_items[j], pivot) <= 0)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, high);
            return i + 1;
        }

        // Swap two items using tuple 
        private void Swap(int i, int j)
        {
            (_items[i], _items[j]) = (_items[j], _items[i]);
        }
    }
}