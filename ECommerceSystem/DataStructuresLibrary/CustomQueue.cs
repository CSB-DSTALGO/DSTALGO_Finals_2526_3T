namespace DataStructuresLibrary;

// A queue built using linked nodes instead of an array or built-in list.
// First item added is the first one removed (FIFO).
public class CustomQueue<T> where T : IComparable<T>
{
    private class Node
    {
        public T Value;
        public Node? Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node? _front; // the next item to come out
    private Node? _rear;  // the last item added

    public int Count { get; private set; }

    // Adds an item to the back of the line. 
    // position is always known directly.
    public void Enqueue(T item)
    {
        Node newNode = new Node(item);

        if (_rear == null)
        {
            // Nothing in the queue yet, so this item is both front and rear.
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

    // Removes and returns the item at the front of the line.
    public T Dequeue()
    {
        if (_front == null)
            throw new InvalidOperationException("Cannot dequeue: the queue is empty.");

        T value = _front.Value;
        _front = _front.Next;

        if (_front == null)
            _rear = null; // queue is now empty, so rear resets too

        Count--;
        return value;
    }

    // Returns the front item without removing it.
    public T Peek()
    {
        if (_front == null)
            throw new InvalidOperationException("Cannot peek: the queue is empty.");

        return _front.Value;
    }

    // Checks if an item exists anywhere in the queue, without changing
    // the queue. Items are checked one by one from front to back, so
    // worst case every item gets checked
    public bool Search(T item)
    {
        Node? current = _front;
        while (current != null)
        {
            if (current.Value.CompareTo(item) == 0)
                return true;

            current = current.Next;
        }

        return false;
    }

    public void Sort()
    {
        if (Count <= 1)
            return; // 0 or 1 items is already sorted

        CustomQueue<T> sorted = new CustomQueue<T>();

        while (Count > 0)
        {
            T current = Dequeue();

            int sortedSizeAtStart = sorted.Count;
            for (int i = 0; i < sortedSizeAtStart; i++)
            {
                T x = sorted.Dequeue();
                if (x.CompareTo(current) <= 0)
                {
                    sorted.Enqueue(x); // stays where it is
                }
                else
                {
                    Enqueue(x); 
                }
            }

            sorted.Enqueue(current);
        }

        while (sorted.Count > 0)
        {
            Enqueue(sorted.Dequeue());
        }
    }
}