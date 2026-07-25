using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void Enqueue_Add_Item()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            Assert.False(queue.IsEmpty());
            Assert.Equal(1, queue.Count);
            Assert.Equal(10, queue.Peek());
        }
        [Fact]
        public void Dequeue_Remove_First_Item()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            int removedItem = queue.Dequeue();
            Assert.Equal(10, removedItem);
            Assert.Equal(1, queue.Count);
            Assert.Equal(20, queue.Peek());
        }
        [Fact]
        public void Peek_Returns_First_Item_Without_Removing()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(50);
            int result = queue.Peek();
            Assert.Equal(50, result);
            Assert.Equal(1, queue.Count);
        }
        [Fact]
        public void IsEmpty_Returns_True_For_Empty_Queue()
        {
            var queue = new CustomQueue<int>();
            Assert.True(queue.IsEmpty());
        }
        [Fact]
        public void Search_Returns_True_If_Item_Exists()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            Assert.True(queue.Search(20));
        }
        [Fact]
        public void Sort_Ascending_Order()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(30);
            queue.Enqueue(20);
            queue.Enqueue(10);
            queue.Sort();
            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(30, queue.Dequeue());
        }
        [Fact]
        public void Dequeue_Throws_Exception_If_Queue_Is_Empty()
        {
            var queue = new CustomQueue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }
    }
}