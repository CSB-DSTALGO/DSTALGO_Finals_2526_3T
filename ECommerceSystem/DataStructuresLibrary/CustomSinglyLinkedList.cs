namespace DataStructuresLibrary;

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class CustomSinglyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
{
    //Represents a single node in the linked list
    private class Node      
    {
        //Value held by this node
        public T Data;
        //Reference to the next node in the list
        public Node? Next;
        //Constructor to initialize the node with data
        public Node(T data) => Data = data;     
    }

    //Reference to the first and last node in the list
    private Node? _head;
    private Node? _tail;

    //Number of nodes or items in the list
    public int Count { get; private set; }      

    // Add function to add an item to the end of the list
    public void Add(T item)
    {
        var newNode = new Node(item);       //Create a new node with the provided item

        //condition to check if the list is empty or not
        if (_head == null)      //Check if the list is empty, set both head and tail to the new node
        {
            _head = newNode;        
            _tail = newNode;
        }
        else        //if not empty, add the new node to the end and update the tail
        {
            _tail!.Next = newNode;
            _tail = newNode;
        }

        Count++;
    }

    // Remove function to remove an item from the list
    public bool Remove(T item)
    {
        //If the list is empty, return false     
        if (_head == null) return false;    

        //If the item to remove is the head, update head and possibly tail
        if (_head.Data.CompareTo(item) == 0)        
        {
            _head = _head.Next;
            if (_head == null) _tail = null;
            Count--;
            return true;
        }
        //Starts scanning from the head
        Node? current = _head;
        //Continues while there's a next node to check
        while (current.Next != null)        
        {
            //Checks if the following node matches item
            if (current.Next.Data.CompareTo(item) == 0)
            {
                if (current.Next == _tail) _tail = current;     //If the next node is the tail, update the tail to current
                current.Next = current.Next.Next;       //Skips over the matching node to unlink it
                Count--;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    // Search function to check if an item exists in the list
    public bool Search(T item)
    {
        //Starts scanning from the head
        Node? current = _head;
        //Continues while there are nodes to check
        while (current != null)
        {
            //Checks if the current node's data matches the item
            if (current.Data.CompareTo(item) == 0) return true;
            current = current.Next;
        }
        return false;
    }

    // Sort function to sort the list in ascending order
    public void Sort()
    {
        // If the list is empty or has only one node, it's already sorted
        if (_head == null || _head.Next == null) return;

        
        Node? sortedHead = null;        //Head of the new list being built in sorted order
        Node? current = _head;      //The original node currently being inserted

        //Processes every node from the original list
        while (current != null)
        {
            //Remembers the next original node before pointers change
            Node? next = current.Next;

            //Checks if the current item belongs at the front
            if (sortedHead == null || sortedHead.Data.CompareTo(current.Data) >= 0)
            {
                current.Next = sortedHead; //Points the current item at the current sorted head
                sortedHead = current;       //Makes current item the new sorted head
            }

            // Runs when current item belongs later in the sorted list
            else
            {
                Node search = sortedHead;       // Starts searching for the insertion point from the sorted head
                // Finds the node just before where the current item belongs
                while (search.Next != null && search.Next.Data.CompareTo(current.Data) < 0)
                {
                    search = search.Next;   // Moves to the next node in the sorted list
                }
                current.Next = search.Next;     // Points the current item at the node that will follow it
                search.Next = current;      // Links the previous node to the current item, inserting it into the sorted list
            }

            current = next;
        }
        //Replaces the original head with the new sorted head
        _head = sortedHead;

        //starts at the head and traverses to the end to find the new tail
        Node tail = _head!;

        //Walks forward until the last node is reached
        while (tail.Next != null) tail = tail.Next;

        //Updates the tail reference to the last node found
        _tail = tail;
    }

    //Lets the list be iterated with foreach
    public IEnumerator<T> GetEnumerator()
    {
        //Starts iteration at the head node
        Node? current = _head;
        //Continues until all nodes have been yielded
        while (current != null)
        {
            yield return current.Data;      //Returns the current node's data to the caller
            current = current.Next;         //Moves on to the next node
        }
    }

    //Non-generic interface method that reuses the generic enumerator
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}