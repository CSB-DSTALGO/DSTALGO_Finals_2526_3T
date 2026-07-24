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

    private Node? _head;

    public int Count { get; private set; }

<<<<<<< Updated upstream
=======
    // Adds an item to the end of the list
>>>>>>> Stashed changes
    public void Add(T item)
    {
        Node newNode = new Node(item);

        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node current = _head;
<<<<<<< Updated upstream
            while (current.Next != null)
                current = current.Next;
            current.Next = newNode;
        }

        Count++;
    }

    public bool Remove(T item)
    {
        if (_head == null) return false;
=======

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        Count++;
    }

    // Removes the first occurrence of an item
    public bool Remove(T item)
    {
        if (_head == null)
            return false;
>>>>>>> Stashed changes

        if (_head.Data.CompareTo(item) == 0)
        {
            _head = _head.Next;
            Count--;
            return true;
        }

        Node current = _head;
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        while (current.Next != null)
        {
            if (current.Next.Data.CompareTo(item) == 0)
            {
<<<<<<< Updated upstream
                current.Next = current.Next.Next; // unlink the node
                Count--;
                return true;
            }
            current = current.Next;
        }

        return false; // not found
    }

    // Linear traversal search.
    public bool Search(T item)
    {
        Node? current = _head;
=======
                current.Next = current.Next.Next;
                Count--;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    // Returns true if the item exists
    public bool Search(T item)
    {
        Node? current = _head;

>>>>>>> Stashed changes
        while (current != null)
        {
            if (current.Data.CompareTo(item) == 0)
                return true;
<<<<<<< Updated upstream
            current = current.Next;
        }
        return false;
    }

    public void Sort()
    {
        if (_head == null || _head.Next == null) return;

        Node? sorted = null;
        Node? current = _head;

        while (current != null)
        {
            Node next = current.Next; // remember where we were

            if (sorted == null || sorted.Data.CompareTo(current.Data) >= 0)
            {
                // Insert at the front of the sorted section
                current.Next = sorted;
                sorted = current;
            }
            else
            {
                Node temp = sorted;
                while (temp.Next != null && temp.Next.Data.CompareTo(current.Data) < 0)
                {
                    temp = temp.Next;
                }
                current.Next = temp.Next;
                temp.Next = current;
            }

            current = next;
        }

        _head = sorted;
    }

    public void ForEach(Action<T> action)
    {
        Node? current = _head;
        while (current != null)
        {
            action(current.Data);
            current = current.Next;
        }
    }
}
=======

            current = current.Next;
        }

        return false;
    }

    // Returns the item at the specified index
    public T GetAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        Node? current = _head;

        for (int i = 0; i < index; i++)
        {
            current = current!.Next;
        }

        return current!.Data;
    }

    // Bubble sort
    public void Sort()
    {
        if (_head == null || _head.Next == null)
            return;

        bool swapped;

        do
        {
            swapped = false;
            Node? current = _head;

            while (current!.Next != null)
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

        } while (swapped);
    }

    // Traverses the list
    public IEnumerable<T> GetAll()
    {
        Node? current = _head;

        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}
>>>>>>> Stashed changes
