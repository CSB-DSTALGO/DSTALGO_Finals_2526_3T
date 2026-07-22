// CustomQueue.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomQueue<T> where T : IComparable<T>
    {
        private T[] _items;
        private int _front;
        private int _rear;
        private int _count;

        public int Count 
        { 
            
            get { return _count; } 
        }

        public CustomQueue()
        {
            //Constructor
            _items = new T[4]; //size
            _front = 0;
            _rear =  0;
            _count = 0;
        }

        public void Enqueue(T item)
        {
            if(_count == _items.Length)
            {
                // Resize the array if it's full
                T[] temp = new T[_items.Length * 2];
                Array.Copy(_items, _front, temp, 0, _count);//copies array contents
                _items = temp;
                _front = 0;
                _rear = _count;

            }   
            _items[_rear] = item;
            _rear = (_rear + 1) % _items.Length;//Loops the queue back to the start
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T item = _items[_front];
            _front = (_front + 1) % _items.Length;  //Loop
            _count --;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");//empty queue
            }

            return _items[_front]; //returns the item at the front
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }


        //Time Complexity: 0(n) best case (Queue is already sorted so the algorithm only makes one pass)
        //0(n^2) average and worst case
        //Space complexity: 0(1) extra space - sorting is done via swapping elements via space.
        public void Sort()
        {
            int n = _count; //count of all elements in the queue
            bool swapped;

            //bubble sort
            //outer loop: Each loop sorts the 2nd largest unsorted item into place
            for(int i = 0; i < n - 1; i++) 
            {
                swapped = false; //resets swap tracker after each loop

                //Inner loop: Compares adjacent pairs with the unsorted portion
                for(int j = 0; j < n - i - 1; j++)
                {
                    //Converts j and j + 1 into actual array index
                    int index =(_front + j) % _items.Length;
                    int IndexRight = (_front +j  +  1) % _items.Length; 
                    //Compares the 2 elements. Swapping if needed
                    if(_items[index].CompareTo(_items[IndexRight]) > 0)
                    {
                        T temp = _items[index]; //
                        _items[index] = _items[IndexRight];
                        _items[IndexRight] = temp;

                        swapped = true;//confirms swap has happened
                    }
                }
                //Exists early if no swap occurs
                if(!swapped)
                {break;}
            }
            
        }

        //Time complexity: 0(1) best case(match is at the front of the queue) 0(n)average/worst case(match is found near or at the end of the queue or not present at all)
        //space complexity:0(1) no extra data structure is used
        public bool Search(T app) //Returns true if a matching item is found
        {
            int n = _count;

            for(int i = 0; i < n; i++)
            {
                //converts i into the item index
                int index = (_front + i) % _items.Length;

                //Compare the element at the position to the target
                if(_items[index].CompareTo(app)==0)
                    {
                        return true;//returns true if a match is found
                    }

            }

            return false;//no match found. returns false
        }
    }
}