// CustomStack.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomStack<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;
        private int _top; 

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
                throw new InvalidOperationException("Cannot pop from an empty stack.");
            }

            _top--;
            T item = _items[_top];
            _items[_top] = default!; 
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot peek an empty stack.");
            }

            return _items[_top - 1];
        }

        public bool IsEmpty()
        {
            return _top == 0;
        }

        private void Resize()
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }

       
        public T[] ToArray()
        {
            T[] result = new T[_top];
            for (int i = 0; i < _top; i++)
            {
                result[i] = _items[_top - 1 - i];
            }
            return result;
        }

        
        public void Sort(Comparison<T> comparison)
        {
            if (comparison is null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            if (_top <= 1)
            {
                return;
            }

            T[] snapshot = ToArray();
            QuickSort(snapshot, 0, snapshot.Length - 1, comparison);

            _top = 0;
            for (int i = snapshot.Length - 1; i >= 0; i--)
            {
                Push(snapshot[i]);
            }
        }

        private static void QuickSort(T[] array, int low, int high, Comparison<T> comparison)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high, comparison);
                QuickSort(array, low, pivotIndex - 1, comparison);
                QuickSort(array, pivotIndex + 1, high, comparison);
            }
        }

        private static int Partition(T[] array, int low, int high, Comparison<T> comparison)
        {
            T pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (comparison(array[j], pivot) <= 0)
                {
                    i++;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }

            (array[i + 1], array[high]) = (array[high], array[i + 1]);
            return i + 1;
        }

        
        public int IndexOf(Predicate<T> match)
        {
            if (match is null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            T[] snapshot = ToArray();

            for (int i = 0; i < snapshot.Length; i++)
            {
                if (match(snapshot[i]))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
