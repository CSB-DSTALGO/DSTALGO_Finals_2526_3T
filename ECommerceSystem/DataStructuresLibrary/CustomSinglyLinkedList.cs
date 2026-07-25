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
        var newNode = new Node(item);

        if (_head is null)
        {
            _head = newNode;
        }
        else
        {
            Node current = _head;
            while (current.Next is not null)
                current = current.Next;

            current.Next = newNode;
        }

        Count++;
    }

    
    public bool Remove(T item)
    {
        Node? current = _head;
        Node? previous = null;

        while (current is not null)
        {
            if (current.Data.CompareTo(item) == 0)
            {
                if (previous is null)
                    _head = current.Next;   // removing the head node
                else
                    previous.Next = current.Next; // bridge over the removed node

                Count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }

    
    public bool Search(T item)
    {
        Node? current = _head;
        while (current is not null)
        {
            if (current.Data.CompareTo(item) == 0)
                return true;

            current = current.Next;
        }

        return false;
    }

    
    public void Sort()
    {
        if (Count < 2) return;

        bool swapped;
        do
        {
            swapped = false;
            Node? current = _head;

            while (current is not null && current.Next is not null)
            {
                if (current.Data.CompareTo(current.Next.Data) > 0)
                {
                    (current.Data, current.Next.Data) = (current.Next.Data, current.Data);
                    swapped = true;
                }

                current = current.Next;
            }
        } while (swapped);
    }

    
    public IEnumerable<T> GetAll()
    {
        Node? current = _head;
        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}
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

    public void Add(T item) => throw new NotImplementedException();
    public bool Remove(T item) => throw new NotImplementedException();

    public bool Search(T item) => throw new NotImplementedException();

    
    public void Sort() => throw new NotImplementedException();
}
