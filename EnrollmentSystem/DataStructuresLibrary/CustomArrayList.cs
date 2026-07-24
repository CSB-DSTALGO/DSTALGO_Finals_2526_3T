// CustomArrayList.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomArrayList<T>
    {
        private T[] _items;
        private int _count;

        public int Count 
        { 
            get { return _count; }
        }

        //creates the initial array with a capacity of 4
        public CustomArrayList()
        {
            _items = new T[4];
            _count = 0;
        }


        public void Add(T item)
        {
            //Check if array is full
            if (_count == _items.Length)
            {
                Resize();
            }

            _items[_count] = item;//stores the new item at last index of array

            _count++;//increases the index by 1
            
        }

        public T Get(int index)
        {
            if(index < 0 || index >= _count)//checks if the index is outside the stored element
            {
                throw new IndexOutOfRangeException();
            }


            return _items[index];
            
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)//checsk if the index is valid
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < _count -1; i++)//shifts all elements by one to the left
            {
                _items[i] = _items[i + 1];
            }

            _items[_count - 1] = default!;//clears the last element
            _count--;//decreases the number of stored elemenets 
        }

        private void Resize()
        {
            T[] tItems = new T[_items.Length * 2]; //create new array with double the length

            for (int i = 0; i < Count; i++)//loop that copies elements in old to new array
            {
                tItems[i] = _items[i];
            }
            _items = tItems; // replace old array with the new array
        }

        //LINEAR SEARCH
        public int Search(T item)
        {
            for (int i = 0; i < _count; i++)//checks the elements of the array one by one
            {
                if (_items[i]!.Equals(item))//returns the index if the item is found
                {
                    return i;
                }
                   
            }
            return -1;//returns -1 if the item not found
        }
        
        //BUBBLE SORT - ascending order
        public void Sort()
        {
            for(int i = 0; i < _count - 1; i++)//repeats until the array is sorted
            {
                for(int j = 0; j < _count - i -1; j++)//compares adjacent elements
                {
                    if (Comparer<T>.Default.Compare(_items[j], _items[j + 1]) > 0)//swaps if the elements are in the wrong order
                    {
                        T temp = _items[j];
                        _items[j] = _items[j + 1];  
                        _items[j + 1] = temp;
                    }
                }
            }
        }
    }
}