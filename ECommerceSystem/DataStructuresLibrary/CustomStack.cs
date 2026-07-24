// 12521269 Joaquin Bryan G. Ross
namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
{
    // Index 0 is the bottom of the stack; index Count - 1 is the top.
    private T[] _items = new T[4];

    public int Count { get; private set; }

    // Adds on top. O(1) amortised.
    public void Push(T item)
    {
        if (Count == _items.Length) Grow();
        _items[Count] = item;
        Count++;
    }

    // Removes and returns the top. O(1).
    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException("Cannot pop from an empty stack.");

        Count--;
        T top = _items[Count];
        _items[Count] = default!; // release the duplicate reference in the vacated slot
        return top;
    }

    // Reads the top without removing it. O(1).
    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Cannot peek at an empty stack.");

        return _items[Count - 1];
    }

    // True when nothing is stacked. O(1).
    public bool IsEmpty() => Count == 0;

    // Returns how deep the item sits, counting the top as 1, or -1 if absent.
    // Depth is reported instead of an array index because callers of a stack
    // reason in "how many pops away" terms, not in storage positions.
    public int Search(T item)
    {
        for (int i = Count - 1; i >= 0; i--)
        {
            if (Equals(_items[i], item)) return Count - i;
        }

        return -1;
    }

    // Reorders the stack so that popping yields ascending order, which puts the
    // smallest item on top. Because the top is the highest index, that means the
    // backing array runs descending from bottom to top.
    public void Sort()
    {
        for (int i = 1; i < Count; i++)
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

    private void Grow()
    {
        T[] larger = new T[_items.Length * 2];

        for (int i = 0; i < Count; i++)
        {
            larger[i] = _items[i];
        }

        _items = larger;
    }
}