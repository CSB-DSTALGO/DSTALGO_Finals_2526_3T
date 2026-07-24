// 12521269 Joaquin Bryan G. Ross
namespace DataStructuresLibrary;

public class CustomQueue<T> where T : IComparable<T>
{
    // Circular buffer: the queue occupies Count slots starting at _front and
    // wrapping past the end of the array. Wrapping is what keeps Dequeue O(1),
    // since a plain array would have to shift every remaining element left.
    private T[] _items = new T[4];
    private int _front;

    public int Count { get; private set; }

    // Adds at the rear. O(1) amortised.
    public void Enqueue(T item)
    {
        if (Count == _items.Length) Grow();
        _items[(_front + Count) % _items.Length] = item;
        Count++;
    }

    // Removes from the front. O(1), because the front index moves instead of the data.
    public T Dequeue()
    {
        if (Count == 0)
            throw new InvalidOperationException("Cannot dequeue from an empty queue.");

        T head = _items[_front];
        _items[_front] = default!; // release the duplicate reference in the vacated slot
        _front = (_front + 1) % _items.Length;
        Count--;
        return head;
    }

    // Reads the front without removing it. O(1).
    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Cannot peek at an empty queue.");

        return _items[_front];
    }

    // True when nothing is queued. O(1).
    public bool IsEmpty() => Count == 0;

    // Reports membership without disturbing queue order, so callers can check for
    // an order without draining and rebuilding the queue to do it.
    public bool Search(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Equals(_items[(_front + i) % _items.Length], item)) return true;
        }

        return false;
    }

    // Reorders the queue so that dequeueing yields ascending order.
    public void Sort()
    {
        Realign();

        for (int i = 1; i < Count; i++)
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

    private void Grow()
    {
        T[] larger = new T[_items.Length * 2];

        // Copy in queue order, which also unwraps the buffer.
        for (int i = 0; i < Count; i++)
        {
            larger[i] = _items[(_front + i) % _items.Length];
        }

        _items = larger;
        _front = 0;
    }

    // Slides the queue back to index 0 so the elements sit contiguously,
    // letting Sort treat the buffer as an ordinary array.
    private void Realign()
    {
        if (_front == 0) return;

        T[] straightened = new T[_items.Length];

        for (int i = 0; i < Count; i++)
        {
            straightened[i] = _items[(_front + i) % _items.Length];
        }

        _items = straightened;
        _front = 0;
    }
}