namespace DataStructuresLibrary;

public class CustomStack<T> where T : IComparable<T>
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

    private Node? top;

    public int Count { get; private set; }

    // Push

    public void Push(T item)
    {
        Node newNode = new Node(item);
        newNode.Next = top;
        top = newNode;
        Count++;
    }

    //Pop
    public T Pop()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        T item = top!.Data;
        top = top.Next;
        Count--;

        return item;
    }

    // Peek
    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        return top!.Data;
    }

    //Search (Linear)
    public int Search(T item)
    {
        Node? current = top;
        int position = 1;

        while (current != null)
        {
            if (current.Data.CompareTo(item) == 0)
                return position;

            current = current.Next;
            position++;
        }

        return -1;
    }

    //Sorting Method (Insertion)
    public void Sort()
    {
        if (Count <= 1)
        return;

        Node? sorted = null;
        Node? current = top;

        while (current != null)
        {
            Node? next = current.Next;
            if (sorted == null || current.Data.CompareTo(sorted.Data) < 0)
            {
                current.Next = sorted;
                sorted = current;
            }
            else
            {
                Node? temp = sorted;

                while (temp.Next != null &&
                       temp.Next.Data.CompareTo(current.Data) <= 0)
                {
                    temp = temp.Next;
                }

                current.Next = temp.Next;
                temp.Next = current;
            }

            current = next;
        }

        top = sorted;
    }
}