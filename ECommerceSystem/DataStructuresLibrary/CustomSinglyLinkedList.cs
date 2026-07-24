namespace DataStructuresLibrary;

public class CustomSinglyLinkedList<T> where T : IComparable<T>
{
    private class Node
    {
        public T Data;
        public Node? Next;
        public Node(T data) => Data = data;
    }

    private Node? _head;
    public int Count { get; private set; }

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
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        Count++;
    }

    public bool Remove(T item)
    {
        if (_head == null) 
            return false;
        
        if (_head.Data.Equals(item))
        {
            _head = _head.Next;
            Count--;
            return true;
        }

        Node current = _head;
        while (current.Next != null)
        {
            if (current.Next.Data.Equals(item))
            {
                current.Next = current.Next.Next;
                Count--;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public bool Search(T item)
    {
        Node? current = _head;
        while (current != null)
        {
            if (current.Data.Equals(item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }


    public void Sort()
    {
        if (_head == null || _head.Next == null) return;

        bool swapped;
        do
        {
            swapped = false;
            Node current = _head;

            while (current.Next != null)
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