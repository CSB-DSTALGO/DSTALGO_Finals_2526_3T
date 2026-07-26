// REVIEW: same as the array list, this ones living in two projects at the same time. pick one
// home for it
namespace DataStructuresLibrary;

public class CustomQueue<T>
{
    private Node<T>? _front;
    private Node<T>? _rear;
    public int Count { get; private set; }

    public void Enqueue(T value)
    {
        var newNode = new Node<T>(value);

        if (_rear is null)
        {
            _front = newNode;
            _rear = newNode;
        }
        else
        {
            _rear.Next = newNode;
            _rear = newNode;
        }

        Count++;
    }

    public T Dequeue()
    {
        if (_front is null)
            throw new InvalidOperationException("Queue is empty.");

        var value = _front.Data;
        _front = _front.Next;
        Count--;

        if (_front is null)
            _rear = null;

        return value;
    }

    public T Peek()
    {
        if (_front is null)
            throw new InvalidOperationException("Queue is empty.");

        return _front.Data;
    }

    public bool IsEmpty() => _front is null;

    public int Search(Func<T, bool> predicate)
    {
        var current = _front;
        int index = 0;

        while (current is not null)
        {
            if (predicate(current.Data))
                return index;

            current = current.Next;
            index++;
        }

        return -1;
    }

    public void Sort(Comparison<T> comparison)
    {
        if (Count <= 1) return;

        var items = new List<T>();
        var current = _front;

        while (current is not null)
        {
            items.Add(current.Data);
            current = current.Next;
        }

        items.Sort(comparison);

        _front = null;
        _rear = null;
        Count = 0;

        foreach (var item in items)
        {
            Enqueue(item);
        }
    }
}
