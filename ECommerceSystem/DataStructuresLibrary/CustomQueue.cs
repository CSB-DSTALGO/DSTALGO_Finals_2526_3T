namespace DataStructuresLibrary;

/// <summary>
/// A custom queue that follows FIFO:
/// First In, First Out.
///
/// This implementation uses linked nodes instead of
/// C#'s built-in Queue<T>.
/// </summary>
public class CustomQueue<T> where T : IComparable<T>
{
    /// <summary>
    /// Each node stores one item and points to
    /// the next item behind it in line.
    /// </summary>
    private class Node
    {
        public T Data;
        public Node? Next;

        public Node(T data) => Data = data;
    }

    // Points to the item that has been waiting the longest.
    private Node? _front;

    // Points to the most recently added item.
    private Node? _rear;

    /// <summary>
    /// Number of items currently stored in the queue.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Adds a new item to the back of the queue.
    /// Time complexity: O(1)
    /// </summary>
    public void Enqueue(T item)
    {
        Node newNode = new Node(item);

        if (_rear == null)
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

    /// <summary>
    /// Removes and returns the item at the front.
    /// Time complexity: O(1)
    /// </summary>
    public T Dequeue()
    {
        if (_front == null)
        {
            throw new InvalidOperationException(
                "Cannot dequeue from an empty queue.");
        }

        T removedItem = _front.Data;
        _front = _front.Next;

        if (_front == null)
        {
            _rear = null;
        }

        Count--;

        return removedItem;
    }

    /// <summary>
    /// Returns the front item without removing it.
    /// Time complexity: O(1)
    /// </summary>
    public T Peek()
    {
        if (_front == null)
        {
            throw new InvalidOperationException(
                "Cannot peek at an empty queue.");
        }

        return _front.Data;
    }

    /// <summary>
    /// Searches for an item from front to back.
    /// Time complexity: O(n)
    /// </summary>
    public bool Search(T item)
    {
        Node? current = _front;

        while (current != null)
        {
            if (current.Data.CompareTo(item) == 0)
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Sorts the queue in ascending order using bubble sort.
    /// Time complexity: O(n²)
    /// Space complexity: O(1)
    /// </summary>
    public void Sort()
    {
        if (_front == null)
        {
            return;
        }

        bool swapped;

        do
        {
            swapped = false;
            Node current = _front;

            while (current != null && current.Next != null)
            {
                if (current.Data.CompareTo(current.Next.Data) > 0)
                {
                    T temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;

                    swapped = true;
                }

                current = current.Next;
            }
        }
        while (swapped);
    }
}