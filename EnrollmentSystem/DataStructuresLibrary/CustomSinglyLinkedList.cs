// CustomSinglyLinkedList.cs
using System;

namespace DataStructuresLibrary
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; } // Mark as nullable with '?'

        public Node(T data)
        {
            Data = data;
            Next = null; 
        }
    }

    public class CustomSinglyLinkedList<T>
    {
        private Node<T>? _head; // Mark as nullable with '?'

        public Node<T>? Head // Mark as nullable to match the field
        {
            // UNSURE !! Not clear on if this needs something !! UNSURE
            get { throw new NotImplementedException(); }
        }

        public int Count { get; set; }

        public CustomSinglyLinkedList()
        {
            // PROBLEMATIC !! This Code might not work as intended !! PROBLEMATIC
            // Intended to when called does search & merge sorting, put here as per the hint
            if (_head == null || _head.next == null)
                return _head;

            Node _altitem = Split(_head);

            _head = CustomSinglyLinkedList(_head);
            _altitem = CustomSinglyLinkedList(_altitem);
            return Merge(_head, _altitem);
        }

        public void AddLast(T item)
        {
            // Intended to append specified Node to bottom of Linked List
            Node _newNode = new Node(item);
            if (_head == null)
            {
                _head = _newNode;
                return
            }

            Node current = _head;
            while (current != null)
            {
                current = current.next;
            }
            current.Next = _newNode;
        }

        public bool Remove(T item)
        {
            // Intended to remove specified Node from Linked List
            if (_head == null)
            {
                return null;
            }
            _head.Remove(item);
        }

        static Node Split()
        {
            // Intended to create two Linked Lists from singular LL
            Node A = _head;
            Node B = _head;
            while (A != null && A.next != null)
            {
                A = A.next.next;
                if (A != null)
                {
                    B = B.next;
                }
            }
        }

        static Node Merge(Node A, Node B)
        {
            // Intended to merge both, must be used after Split to prevent exception error
            if (A == null)
                return B;
            if (B == null)
                return A;
            if (A.Data < B.Data)
            {
                A.next = Merge(A.next, B);
                return A;
            }
            else
            {
                B.next = Merge(A, B.next);
                return B;
            }
        }
    }
}