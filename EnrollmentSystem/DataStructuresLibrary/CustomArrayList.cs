// CustomArrayList.cs
using System;

namespace DataStructuresLibrary
{
    //Connect class to IComparable so search and sort can work
    public class CustomArrayList<T> where T : IComparable<T>
    {
        private T[] _items; //Array to store elements
        private int _count; //Keep track  of current number of elements in array

        //Return current number of elements stored
        public int Count 
        { 
            get { return _count; } 
        }

        //Create arraylist that stores initial capacity of 4
        public CustomArrayList(int capacity = 4)
        {
            _items = new T[capacity];
            _count = 0;
        }

        //Add item to the end of arraylist
        public void Add(T item)
        {
            //Ensure space next to the latest occupied index in case user wants to add more than 4 elements
            if (_count == _items.Length)
            {
                Resize();
            }

            //Store new item(s) and increment the counter
            _items[_count] = item;
            _count++;
        }

        //Return item at specified index
        public T Get(int index)
        {
            //Validate input to ensure it doesn't go outside of boundary
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return _items[index];
        }

        //Remove item at specified index
        public void RemoveAt(int index)
        {
            //Validate input to ensure it doesn't go outside of boundary
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            //Shift all elements to the left after removing item
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            //Clear the duplicated last element and decrement the counter
            _items[_count - 1] = default(T);
            _count--;
        }

        //Double arraylist capacity when it's full
        private void Resize()
        {
            if (_count == _items.Length)
            {
                T[] new_items = new T[_items.Length*2];

                //Copy all elements into new arraylist
                for (int i = 0; i < _count; i++)
                {
                    new_items[i] = _items[i];
                }

                //Update old arraylist to new arraylist
                _items = new_items;
            }
        }

        //Sort the elements in ascending order
        public void BubbleSort()
        {
            for (int i = 0; i < _count; i++) //Go through all elements in the array
            {
                for (int j = 0; j < _count - 1; j++) //Compare elements
                {
                    if (_items[j].CompareTo(_items[j + 1]) > 0) //Swapping process itself
                    {
                        T temp = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temp;
                    }
                }
            }
        }

        public int LinearSearch(T item)
        {
            for (int i = 0; i < _count; i++) //Go through all elements in the array
            {
                //If item is found, return its index
                if (_items[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }

            return -1; //If not found, return -1
        }
    }
}