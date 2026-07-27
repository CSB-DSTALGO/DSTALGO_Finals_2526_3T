// CustomQueue.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomQueue<T>
    {
        private T[] _items;    // store elements in array
        private int _front;   //  index of next item to dequeue (remove)
        private int _rear;   //   where next enqueued (added) item will go
        private int _count; //    number of elements in queue 

        public int Count 
        { 
            get { return _count; } // returns the count of elements
        }

        public CustomQueue()  
        {
            _items = new T[4]; // initializes the array with a default size of 4 (this can be changed to any desired size)
            _front = 0;       //  starts the front index at 0 
            _rear = 0;       //   starts the rear index at 0 (where the next element will be added) 
            _count = 0;     //    queue starts empty (0 item) & tracks the number of elements in the queue
        }

        public void Enqueue(T item)
        {
            if (_count == _items.Length) // resize if full (expands the array to add more elements) 
            {
                Resize();
            }

            _items[_rear] = item;                  // place item at rear
            _rear = (_rear + 1) % _items.Length;  //  move rear index to next position (wrap around if needed - balik sa start if umabot sa dulo)
            _count++;                            //   increments count of elements in queue
        }

        public T Dequeue()
        {
            if (IsEmpty()) // error handling for empty queue 
            {
                throw new InvalidOperationException("Queue is empty.");  
            }

            T item = _items[_front];                   // saves the item at the front of the queue to return later
            _items[_front] = default(T);              //  clears slot
            _front = (_front + 1) % _items.Length;   //   move front (moves to next position in the array)
                                                    //    wraps if needed (meaning babalik sya sa start ng array kapag naabot na ang dulo)

            _count--;                             //     decrement count of elements in queue

            return item;                        // return removed item
        }

        public T Peek()      // checks item in front of queue without removing it
        {
            if (IsEmpty())  //  error if queue is empty (no item to peek at)
            {
                throw new InvalidOperationException("Queue is empty."); 
            }

            return _items[_front]; // return front item
        }

        public bool IsEmpty()    // checks if queue is empty (no elements in queue) 
        {
            return _count == 0; //  returns true if count is 0 (queue is empty), otherwise false
        }

        private void Resize() // resizes the array to accommodate more elements when the queue is full
        {
            T[] newItems = new T[_items.Length * 2];                   // creates a new array with double the size of the current array
            for (int i = 0; i < _count; i++)                          //  copies elements from the old array to the new array, starting from the front of the queue
            {
                newItems[i] = _items[(_front + i) % _items.Length]; // wraps around if needed (meaning babalik sya sa start ng array kapag naabot na ang dulo)
            }

            _items = newItems;         // replaces the old array with the new array
            _front = 0;               //  resets front index to 0 (start of the new array)
            _rear = _count;          //   sets rear index to the count of elements (next position to add new element)
        }

        public bool Contains(T item) // checks if the queue contains a specific item
        {
            for (int i = 0; i < _count; i++) 
            {
                T current = _items[(_front + i) % _items.Length];  // gets the current item, wrapping around if needed

                if (current.Equals(item))                        //  checks if the current item equals the specified item
                {
                    return true;                               //    returns true if item is FOUND in the queue
                }                                             //     returns false if item is NOT FOUND 
            }
            return false; 
        }

        public void Sort() // sorts the elements in the queue in ascending order
        {
            if (_count <= 1) return; // returns when nothing to sort

            T[] temp = new T[_count];                               // temporary array to hold items in order                  
            for (int i = 0; i < _count; i++)                       //  copies elements from the queue to the temporary array
            {
                temp[i] = _items[(_front + i) % _items.Length];  //    wraps around if needed (babalik sa start ng array pag nakaabot sa dulo)
            }

            Array.Sort(temp); // sort the items

            for (int i = 0; i < temp.Length; i++) // copies the sorted items back to the original array
            {
                _items[i] = temp[i];
            }

            _front = 0; // resets front index to 0 (start of the array)
            _rear = _count % _items.Length; // sets rear index to the count of elements (next position to add new element)

        }

    }
}
