using System;

namespace DataStructuresLibrary
{
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    public class CustomSinglyLinkedList
    {
        private Node head;

        public int Count { get; private set; }

        public void Add(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

            Count++;
        }

        public bool Remove(int data)
        {
            if (head == null)
                return false;

            if (head.Data == data)
            {
                head = head.Next;
                Count--;
                return true;
            }

            Node current = head;

            while (current.Next != null)
            {
                if (current.Next.Data == data)
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public bool Search(int data)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data == data)
                    return true;

                current = current.Next;
            }

            return false;
        }

        public void Sort()
        {
            if (head == null || head.Next == null)
                return;

            bool swapped;

            do
            {
                swapped = false;
                Node current = head;

                while (current.Next != null)
                {
                    if (current.Data > current.Next.Data)
                    {
                        int temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;

                        swapped = true;
                    }

                    current = current.Next;
                }

            } while (swapped);
        }

        public Node Head => head;
    }
}