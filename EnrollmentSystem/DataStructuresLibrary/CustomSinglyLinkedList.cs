// CustomSinglyLinkedList.cs
using System;

namespace DataStructuresLibrary
{
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

    public class CustomSinglyLinkedList<T>
    {
        private Node<T>? _head;

        public Node<T>? Head
        {
            get { return _head; }
        }

        public int Count { get; private set; }

        public CustomSinglyLinkedList()
        {
            _head = null;
        }

        // Appends a node to the end of the list
        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                var current = _head;
                while (current.Next != null)
                    current = current.Next;
                current.Next = newNode;
            }
            Count++;
        }

        // Removes the first node whose Data equals item
        public bool Remove(T item)
        {
            if (_head == null) return false;

            if (_head.Data!.Equals(item))
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            var current = _head;
            while (current.Next != null)
            {
                if (current.Next.Data!.Equals(item))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // Removes the first node matching the predicate
        public bool RemoveWhere(Func<T, bool> predicate)
        {
            if (_head == null) return false;

            if (predicate(_head.Data))
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            var current = _head;
            while (current.Next != null)
            {
                if (predicate(current.Next.Data))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // Linear search: returns the first matching node's data, or default
        public T? Search(Func<T, bool> predicate)
        {
            var current = _head;
            while (current != null)
            {
                if (predicate(current.Data))
                    return current.Data;
                current = current.Next;
            }
            return default;
        }

        // Returns true if any node matches the predicate
        public bool Contains(Func<T, bool> predicate)
        {
            var current = _head;
            while (current != null)
            {
                if (predicate(current.Data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        // Bubble sort using a Comparison<T> delegate
        public void Sort(Comparison<T> comparison)
        {
            if (_head == null || _head.Next == null) return;

            bool swapped;
            do
            {
                swapped = false;
                var current = _head;
                while (current.Next != null)
                {
                    if (comparison(current.Data, current.Next.Data) > 0)
                    {
                        // Swap data values
                        T temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
        }

        // Aggregate across all nodes
        public TResult Aggregate<TResult>(TResult seed, Func<TResult, T, TResult> func)
        {
            var result = seed;
            var current = _head;
            while (current != null)
            {
                result = func(result, current.Data);
                current = current.Next;
            }
            return result;
        }

        // Print all nodes to Console
        public void PrintAll(Func<T, string> formatter)
        {
            var current = _head;
            while (current != null)
            {
                Console.WriteLine(formatter(current.Data));
                current = current.Next;
            }
        }

        // Get item at index (0-based)
        public T GetAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException($"Index {index} is out of range.");

            var current = _head;
            for (int i = 0; i < index; i++)
                current = current!.Next;

            return current!.Data;
        }
    }
}