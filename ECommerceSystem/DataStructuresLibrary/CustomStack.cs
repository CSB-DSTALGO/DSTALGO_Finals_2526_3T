using System;

namespace DataStructuresLibrary;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class CustomStack<T> where T : IComparable<T>
{
    private Node<T>? _top;

    public int Count { get; private set; }

    public void Push(T item)
    {
        Node<T> newNode = new Node<T>(item);
        newNode.Next = _top;
        _top = newNode;
        Count++;
    }

    public T Pop()
    {
        if (_top == null)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        T item = _top.Data;
        _top = _top.Next;
        Count--;
        return item;
    }

    public T Peek()
    {
        if (_top == null)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return _top.Data;
    }

    // Returns 1 from top (1 = top item). Returns -1 if not found.
    public int Search(T item)
    {
        Node<T>? current = _top;
        int depth = 1;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, item) ||
               (current.Data != null && current.Data.CompareTo(item) == 0))
            {
                return depth;
            }
            current = current.Next;
            depth++;
        }

        return -1;
    }

    // Sorts the stack so that the smallest item is at the top
    public void Sort()
    {
        if (_top == null || _top.Next == null)
            return;

        CustomStack<T> tempStack = new CustomStack<T>();

        while (Count > 0)
        {
            T tmp = Pop();

            while (tempStack.Count > 0 && tempStack.Peek().CompareTo(tmp) < 0)
            {
                Push(tempStack.Pop());
            }

            tempStack.Push(tmp);
        }

        while (tempStack.Count > 0)
        {
            Push(tempStack.Pop());
        }
    }
}