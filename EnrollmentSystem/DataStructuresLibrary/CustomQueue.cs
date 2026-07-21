// CustomQueue.cs
using System;

namespace DataStructuresLibrary
{
    public class CustomQueue<T>
    {
        private T[] _items;
        private int _front;
        private int _rear;
        private int _count;

        public int Count 
        { 
            get { throw new NotImplementedException(); } 
        }

        public CustomQueue()
        {
            //throw new NotImplementedException();
        }

        public void Enqueue(T item)
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }
    }
}