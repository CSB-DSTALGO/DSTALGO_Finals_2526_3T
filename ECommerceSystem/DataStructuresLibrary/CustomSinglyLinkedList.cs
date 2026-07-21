namespace DataStructuresLibrary;

public class CustomSinglyLinkedList<T> where T : IComparable<T>
{

    private class Node
    {
        public T Data;
        public Node? Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    // points to the first node
    private Node? _head;

    // to keep track of the number of elements
    public int Count { get; private set; }

    // adds a new item at the end of the list
    public void Add(T item)
    {
        Node newNode = new Node(item);

        // if the list is empty the new node becomes the head
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            // move to the last node
            Node current = _head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            // to link the last node to the new node
            current.Next = newNode;
        }

        Count++;
    }

    // removes the first matching item
    public bool Remove(T item)
    {
        // nothing is removed if list is empty
        if (_head == null)
            return false;

        // if the head contains the item
        if (_head.Data.CompareTo(item) == 0)
        {
            _head = _head.Next;
            Count--;
            return true;
        }

        Node current = _head;

        // to search the rest of the list
        while (current.Next != null)
        {
            if (current.Next.Data.CompareTo(item) == 0)
            {
                current.Next = current.Next.Next;
                Count--;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    // checks if an item exists
    public bool Search(T item)
    {
        Node? current = _head;

        while (current != null)
        {
            if (current.Data.CompareTo(item) == 0)
                return true;

            current = current.Next;
        }

        return false;
    }

    // Sorts the linked list using bubble sort
    public void Sort()
    {
        // no need to sort if there are 0-1 items
        if (_head == null || _head.Next == null)
            return;

        bool swapped;

        do
        {
            swapped = false;

            Node? current = _head;

            while (current != null && current.Next != null)
            {
                // if items are out of order, swap data
                if (current.Data.CompareTo(current.Next.Data) > 0)
                {
                    // Swap the DATA instead of changing node links.
                    T temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;

                    swapped = true;
                }

                current = current.Next;
            }

        } while (swapped);
    }
}