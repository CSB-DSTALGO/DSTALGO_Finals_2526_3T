namespace DataStructuresLibrary;

/// <summary>
/// A custom stack that follows LIFO:
/// Last In, First Out.
///
/// This implementation uses linked nodes instead of
/// C#'s built-in Stack<T>.
/// </summary>
public class CustomStack<T> where T : IComparable<T>
{
    /// <summary>
    /// Each node stores one item and points to
    /// the next item below it.
    /// </summary>
    private sealed class Node
    {
        public T Data;
        public Node? Next;

        public Node(T data, Node? next = null)
        {
            Data = data;
            Next = next;
        }
    }

    // Points to the item currently at the top of the stack.
    private Node? _top;

    /// <summary>
    /// Number of items currently stored in the stack.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Adds a new item to the top of the stack.
    ///
    /// Time complexity: O(1)
    /// </summary>
    public void Push(T item)
    {
        // The new node points to the previous top.
        Node newNode = new Node(item, _top);

        // The new node becomes the top.
        _top = newNode;

        Count++;
    }

    /// <summary>
    /// Removes and returns the top item.
    ///
    /// Time complexity: O(1)
    /// </summary>
    public T Pop()
    {
        if (_top is null)
        {
            throw new InvalidOperationException(
                "Cannot pop from an empty stack.");
        }

        // Save the item before removing its node.
        T removedItem = _top.Data;

        // Move the top pointer to the next node.
        _top = _top.Next;

        Count--;

        return removedItem;
    }

    /// <summary>
    /// Returns the top item without removing it.
    ///
    /// Time complexity: O(1)
    /// </summary>
    public T Peek()
    {
        if (_top is null)
        {
            throw new InvalidOperationException(
                "Cannot peek at an empty stack.");
        }

        return _top.Data;
    }

    /// <summary>
    /// Searches for an item from top to bottom.
    ///
    /// Returns:
    /// 1 if the item is at the top,
    /// 2 if it is second from the top,
    /// and -1 if the item is not found.
    ///
    /// Time complexity: O(n)
    /// </summary>
    public int Search(T item)
    {
        Node? current = _top;
        int depth = 1;

        while (current is not null)
        {
            if (current.Data.CompareTo(item) == 0)
            {
                return depth;
            }

            current = current.Next;
            depth++;
        }

        return -1;
    }

    /// <summary>
    /// Sorts the stack in ascending order using insertion sort.
    ///
    /// After sorting, the smallest item is placed on top.
    ///
    /// Average and worst-case time complexity: O(n²)
    /// Best-case time complexity: O(n)
    /// Space complexity: O(1)
    /// </summary>
    public void Sort()
    {
        Node? sortedTop = null;
        Node? current = _top;

        while (current is not null)
        {
            // Save the next unsorted node before changing links.
            Node? nextUnsorted = current.Next;

            // Insert at the beginning if it is the smallest item.
            if (sortedTop is null ||
                current.Data.CompareTo(sortedTop.Data) < 0)
            {
                current.Next = sortedTop;
                sortedTop = current;
            }
            else
            {
                // Find the correct position in the sorted section.
                Node scan = sortedTop;

                while (scan.Next is not null &&
                       scan.Next.Data.CompareTo(current.Data) <= 0)
                {
                    scan = scan.Next;
                }

                current.Next = scan.Next;
                scan.Next = current;
            }

            current = nextUnsorted;
        }

        // The sorted linked nodes become the new stack.
        _top = sortedTop;
    }
}