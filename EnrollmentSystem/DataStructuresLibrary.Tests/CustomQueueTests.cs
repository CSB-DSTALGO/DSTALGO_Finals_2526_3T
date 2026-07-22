using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        //ADD ALL YOUR TESTS HERE
        
        [Fact]
        public void Enqueue_Resize_Count()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            
            Assert.Equal(5, queue.Count);
        }

        [Fact]
        public void DequeueTest()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            int result = queue.Dequeue();
            Assert.Equal(1, result);
        }

        [Fact]
        public void EmptyQueue()
        {
            var queue = new CustomQueue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Peek()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            int result = queue.Peek();
            Assert.Equal(10,result);
            Assert.Equal(2,queue.Count);
        }

        [Fact]
        public void Empty()
        {
            var queue = new CustomQueue<int>();
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void Search()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(67);
            queue.Enqueue(12);
            queue.Enqueue(10);
            
            bool result = queue.Search(12);
            Assert.True(result);
        }

        [Fact]
        public void Sort()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(21);
            queue.Enqueue(19);
            queue.Enqueue(2);
            queue.Dequeue();
            queue.Sort();

            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(19, queue.Dequeue());
        }
    }
}