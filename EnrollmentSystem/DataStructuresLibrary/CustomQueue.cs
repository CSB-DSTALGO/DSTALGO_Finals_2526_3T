// 12521269 Joaquin Bryan G. Ross
// CustomQueue.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomQueue<T> where T : IComparable<T>
    {
        // Circular buffer. The queue occupies _count slots starting at _front
        // and wrapping past the end of the array. Wrapping is what keeps
        // Dequeue O(1), since a plain array would have to shift every
        // remaining item left instead.
        private T[] _items;
        private int _front;
        private int _rear;
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        // Starts with a small buffer, with front and rear both at slot 0.
        public CustomQueue()
        {
            _items = new T[4];
            _front = 0;
            _rear = 0;
            _count = 0;
        }

        // Amortised O(1).
        public void Enqueue(T item)
        {
            if (_count == _items.Length) Resize();
            _items[_rear] = item;
            _rear = (_rear + 1) % _items.Length;
            _count++;
        }

        // O(1). The front index moves forward rather than the queue shifting.
        public T Dequeue()
        {
            if (_count == 0)
                throw new InvalidOperationException("Cannot dequeue from an empty queue.");

            T head = _items[_front];
            _items[_front] = default!; // release the duplicate reference in the vacated slot
            _front = (_front + 1) % _items.Length;
            _count--;
            return head;
        }

        // Reads the front without removing it. O(1).
        public T Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("Cannot peek at an empty queue.");

            return _items[_front];
        }

        // True when nothing is queued. O(1).
        public bool IsEmpty()
        {
            return _count == 0;
        }

        // Linear search that steps from the front through _count slots,
        // wrapping with modulo. Non-destructive, so the queue order survives
        // the lookup. Searching naively would mean draining and rebuilding.
        public bool Search(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_items[(_front + i) % _items.Length], item)) return true;
            }

            return false;
        }

        // Insertion sort, ascending, so that dequeueing yields ascending order.
        // The buffer is realigned to index 0 first so the wrapped region
        // becomes contiguous and can be treated as an ordinary array.
        public void Sort()
        {
            Realign();

            for (int i = 1; i < _count; i++)
            {
                T key = _items[i];
                int j = i - 1;

                while (j >= 0 && _items[j].CompareTo(key) > 0)
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

            // Copy in queue order, which also unwraps the buffer.
            for (int i = 0; i < _count; i++)
            {
                larger[i] = _items[(_front + i) % _items.Length];
            }

            _items = larger;
            _front = 0;
            _rear = _count;
        }

        // Slides the queue back to index 0 so the items sit contiguously.
        private void Realign()
        {
            if (_front == 0) return;

            T[] straightened = new T[_items.Length];

            for (int i = 0; i < _count; i++)
            {
                straightened[i] = _items[(_front + i) % _items.Length];
            }

            _items = straightened;
            _front = 0;
            _rear = _count % _items.Length;
        }
    }
}
