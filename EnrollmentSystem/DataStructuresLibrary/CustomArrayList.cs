using System;

namespace DataStructuresLibrary
{
    //It grows automatically when full, and we added Quick Sort + Binary Search
    public class CustomArrayList<T>
    {
        private T[] _items; //The actual array storing our data
        private int _count; //How many items are currently in the array
        private const int DefaultCapacity = 4;  //Start small, double when full

        //Property so outsiders can see how many items we have
        public int Count
        {
            get { return _count; }
        }

        //Constructor - creates empty array with default size
        public CustomArrayList()
        {
            _items = new T[DefaultCapacity];
            _count = 0;
        }

        //Add item to the end. If array is full, resize first (double the size)
        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }
            _items[_count] = item;
            _count++;
        }

        //Get item at specific index. Throw error if index is invalid
        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range. Count: {_count}");
            }
            return _items[index];
        }

        //Remove item at index and shift everything left to fill the gap
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range. Count: {_count}");
            }

            //Shift left: copy each item to the slot before it
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            //Clear last slot so garbage collector can clean it up
            _items[_count - 1] = default!;
            _count--;
        }


        //QUICK SORT - Divide and conquer sorting

        // How it works:
        // 1. Pick a pivot (we use last element)
        // 2. Move all smaller items to the left, bigger to the right
        // 3. Recursively sort left and right parts
        //Time: O(n log n) average, O(n²) worst case
        //Space: O(log n) 

        public void QuickSort(Comparison<T> compare)
        {
            if (_count <= 1) return;  //Nothing to sort if 0 or 1 item
            QuickSortHelper(0, _count - 1, compare);
        }

        // The recursive part - keeps splitting and sorting
        private void QuickSortHelper(int low, int high, Comparison<T> compare)
        {
            if (low < high)
            {
                int pivotIndex = Partition(low, high, compare);
                QuickSortHelper(low, pivotIndex - 1, compare);   //Sort left side
                QuickSortHelper(pivotIndex + 1, high, compare);  //Sort right side
            }
        }

        //Moves items around the pivot, returns where pivot ended up
        private int Partition(int low, int high, Comparison<T> compare)
        {
            T pivot = _items[high];  //Pick last element as pivot
            int i = low - 1;          //Tracks where smaller items end

            for (int j = low; j < high; j++)
            {
                //If current item is smaller or equal to pivot, move it left
                if (compare(_items[j], pivot) <= 0)
                {
                    i++;
                    Swap(i, j);
                }
            }

            //Put pivot in its correct spot (between smaller and bigger items)
            Swap(i + 1, high);
            return i + 1;
        }

        //Simple swap of two positions
        private void Swap(int i, int j)
        {
            T temp = _items[i];
            _items[i] = _items[j];
            _items[j] = temp;
        }


        // BINARY SEARCH - Fast search on sorted data

        // How it works:
        // 1. Check middle item
        // 2. If target is smaller, search left half
        // 3. If target is bigger, search right half
        // 4. Repeat until found or no more items

        //IMPORTANT: Array MUST be sorted first!
        //Time: O(log n) - way faster than checking every item
        //Space: O(1)

        public int BinarySearch(T item, Comparison<T> compare)
        {
            int left = 0;
            int right = _count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;  //Avoid overflow
                int comparison = compare(_items[mid], item);

                if (comparison == 0)
                {
                    return mid;  //Found it!
                }
                else if (comparison < 0)
                {
                    left = mid + 1;  //Target is bigger, go right
                }
                else
                {
                    right = mid - 1;  //Target is smaller, go left
                }
            }

            return -1;  //Not found
        }

        //Double the array size when we run out of space
        private void Resize()
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(_items, newItems, _count);  //Copy old data to new bigger array
            _items = newItems;
        }
    }
}