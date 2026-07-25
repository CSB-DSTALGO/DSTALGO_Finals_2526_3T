using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    /// <summary>
    /// A generic circular queue implementation using a dynamic array (RAM-based).
    /// Implements FIFO (First-In-First-Out) behavior with automatic resizing.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the queue.</typeparam>
    public class CustomQueue<T> : IEnumerable<T>
    {
        // ==================== PRIVATE FIELDS ====================
        private T[] _array;          // Internal storage array
        private int _head;           // Index of the front element (dequeue position)
        private int _tail;           // Index of the next available slot (enqueue position)
        private int _count;          // Number of actual elements in the queue
        private const int _defaultCapacity = 4; // Starting capacity

        // ==================== PUBLIC PROPERTIES ====================
        /// <summary>
        /// Gets the number of elements contained in the queue.
        /// </summary>
        public int Count => _count;

        // ==================== CONSTRUCTORS ====================
        /// <summary>
        /// Initializes a new instance of the CustomQueue class with the default capacity (4).
        /// </summary>
        public CustomQueue()
        {
            _array = new T[_defaultCapacity];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        /// <summary>
        /// Initializes a new instance of the CustomQueue class with a specified initial capacity.
        /// </summary>
        /// <param name="capacity">The initial number of elements the queue can hold.</param>
        public CustomQueue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity cannot be negative.");

            _array = new T[capacity];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        // ==================== CORE QUEUE METHODS ====================

        /// <summary>
        /// Adds an item to the rear (tail) of the queue.
        /// If the internal array is full, it automatically doubles in size.
        /// Time Complexity: O(1) amortized, O(n) when resizing.
        /// </summary>
        /// <param name="item">The item to add to the queue.</param>
        public void Enqueue(T item)
        {
            if (_count == _array.Length)
            {
                Resize(_array.Length * 2);
            }

            _array[_tail] = item;
            _tail = (_tail + 1) % _array.Length;
            _count++;
        }

        /// <summary>
        /// Removes and returns the item at the front (head) of the queue.
        /// Time Complexity: O(1).
        /// </summary>
        /// <returns>The item at the front of the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty. Cannot dequeue.");

            T item = _array[_head];
            _array[_head] = default(T)!;
            _head = (_head + 1) % _array.Length;
            _count--;

            if (_count > 0 && _count <= _array.Length / 4 && _array.Length > _defaultCapacity)
            {
                Resize(_array.Length / 2);
            }

            return item;
        }

        /// <summary>
        /// Returns the item at the front of the queue without removing it.
        /// Time Complexity: O(1).
        /// </summary>
        /// <returns>The item at the front of the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty. Cannot peek.");

            return _array[_head];
        }

        /// <summary>
        /// Checks whether the queue is empty.
        /// Time Complexity: O(1).
        /// </summary>
        /// <returns>True if the queue contains no elements; otherwise, false.</returns>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// Removes all elements from the queue and resets it to the default capacity.
        /// Time Complexity: O(1).
        /// </summary>
        public void Clear()
        {
            _array = new T[_defaultCapacity];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        // ==================== SORTING ALGORITHM (MERGE SORT) ====================

        /// <summary>
        /// Sorts the elements in the queue in ascending order using the Merge Sort algorithm.
        /// Time Complexity: O(n log n) in all cases.
        /// Space Complexity: O(n) for the temporary array.
        /// </summary>
        public void Sort()
        {
            if (_count <= 1)
                return;

            T[] items = new T[_count];
            int currentIndex = 0;
            int currentPosition = _head;
            while (currentIndex < _count)
            {
                items[currentIndex] = _array[currentPosition];
                currentPosition = (currentPosition + 1) % _array.Length;
                currentIndex++;
            }

            MergeSort(items, 0, items.Length - 1);

            int newCapacity = Math.Max(_defaultCapacity, _count * 2);
            _array = new T[newCapacity];
            for (int i = 0; i < items.Length; i++)
            {
                _array[i] = items[i];
            }

            _head = 0;
            _tail = _count;
            _count = items.Length;
        }

        private void MergeSort(T[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private void Merge(T[] arr, int left, int mid, int right)
        {
            int leftSize = mid - left + 1;
            int rightSize = right - mid;

            T[] leftArray = new T[leftSize];
            T[] rightArray = new T[rightSize];

            for (int i = 0; i < leftSize; i++)
                leftArray[i] = arr[left + i];
            for (int j = 0; j < rightSize; j++)
                rightArray[j] = arr[mid + 1 + j];

            int leftIndex = 0;
            int rightIndex = 0;
            int mergeIndex = left;

            var comparer = Comparer<T>.Default;

            while (leftIndex < leftSize && rightIndex < rightSize)
            {
                if (comparer.Compare(leftArray[leftIndex], rightArray[rightIndex]) <= 0)
                {
                    arr[mergeIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    arr[mergeIndex] = rightArray[rightIndex];
                    rightIndex++;
                }
                mergeIndex++;
            }

            while (leftIndex < leftSize)
            {
                arr[mergeIndex] = leftArray[leftIndex];
                leftIndex++;
                mergeIndex++;
            }

            while (rightIndex < rightSize)
            {
                arr[mergeIndex] = rightArray[rightIndex];
                rightIndex++;
                mergeIndex++;
            }
        }

        // ==================== SEARCH ALGORITHM (LINEAR SEARCH) ====================

        /// <summary>
        /// Searches for a specific item in the queue using Linear Search.
        /// Time Complexity: O(n) in worst case, O(1) in best case.
        /// </summary>
        /// <param name="item">The item to search for.</param>
        /// <returns>True if the item is found; otherwise, false.</returns>
        public bool Contains(T item)
        {
            if (IsEmpty())
                return false;

            int currentPosition = _head;
            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_array[currentPosition], item))
                {
                    return true;
                }
                currentPosition = (currentPosition + 1) % _array.Length;
            }

            return false;
        }

        // ==================== PRIVATE HELPER METHODS ====================

        private void Resize(int newCapacity)
        {
            if (newCapacity < _count)
                throw new ArgumentOutOfRangeException(nameof(newCapacity), "New capacity cannot be smaller than the current element count.");

            T[] newArray = new T[newCapacity];
            int currentIndex = 0;
            int currentPosition = _head;
            while (currentIndex < _count)
            {
                newArray[currentIndex] = _array[currentPosition];
                currentPosition = (currentPosition + 1) % _array.Length;
                currentIndex++;
            }

            _array = newArray;
            _head = 0;
            _tail = _count;
        }

        // ==================== IENUMERABLE IMPLEMENTATION ====================

        public IEnumerator<T> GetEnumerator()
        {
            int currentPosition = _head;
            for (int i = 0; i < _count; i++)
            {
                yield return _array[currentPosition];
                currentPosition = (currentPosition + 1) % _array.Length;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            if (IsEmpty())
                return "Queue is empty.";

            var elements = new List<string>();
            int currentPosition = _head;
            for (int i = 0; i < _count; i++)
            {
                elements.Add(_array[currentPosition]?.ToString() ?? "null");
                currentPosition = (currentPosition + 1) % _array.Length;
            }

            return $"[ {string.Join(", ", elements)} ]";
        }
    }
}