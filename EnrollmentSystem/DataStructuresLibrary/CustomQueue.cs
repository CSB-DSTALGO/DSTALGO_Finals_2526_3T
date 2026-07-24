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
            _items = new T[4];
        }

        public void Enqueue(T item)
        {
            if (_count == _items.Length) //if our count is equals to the length of our _items
            {
                T[] resize = new T[_items.Length * 2]; //resize by doubling the items.Length
                for (int i = 0; i < _count; i++) //for loop to move items into the newly made resized array
                {
                    resize[i] = _items[(_front + i) % _items.Length]; //copies the queue in order   
                                                                      //starts from the front, then when you reach the end it wraps around
                                                                      //previous implementation copied the empty indexes
                                                                      
                }
                _items = resize;
                _front = 0;
                _rear = _count;
            }
            _items[_rear] = item;
            _rear = (_rear + 1) % _items.Length;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No items in queue");
                return default(T);
            }
            T removedItem = _items[_front]; //removed item is stored here, set to the front because queue is FIFO
            _front = (_front + 1) % _items.Length; //front is set to the position behind front 
            _count--;
            return removedItem;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No items in queue");
                return default(T);
            }
            else
            {
                return _items[_front];
            }

        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
        public void BubbleSortQueue()
        {
            int n = _count;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - 1 - i; j++)
                {
                    int current = (_front + j) % _items.Length; //current has the index of the current item being compared
                    int next = (_front + j + 1) % _items.Length; //next has the index of the next item being compared
                                                                //these two variables us used for easy access of the items we need to compare

                    if (_items[current].CompareTo(_items[next]) > 0)
                    {
                        //actual bubble sort logic
                        T temp = _items[current];
                        _items[current] = _items[next];
                        _items[next] = temp;

                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
        }
        public bool LinearSearch(T target)
        {
            for (int i = 0; i < _count; i++)
            {
                int index = (_front + i) % _items.Length; //start at _front then move i positions, think of this as i positions from _front (front 0 + i[2] is the third index
                if (_items[index].Equals(target))
                {
                    Console.WriteLine("Student found at queue: " + i);
                    return true;
                }
              
            }
            return false;
        }


    }
}