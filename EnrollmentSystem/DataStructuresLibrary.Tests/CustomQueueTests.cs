using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
       public void Enqueue_OneItem_CountBecomesOne()
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            queue.Enqueue(10);

            Assert.Equal(1, queue.Count);
        }


        [Fact]
        public void Dequeue_ReturnsFirstItemAdded() 
        {
            CustomQueue<string> queue = new CustomQueue<string>();

            queue.Enqueue("student A");
            queue.Enqueue("student B");

            string result = queue.Dequeue();

            Assert.Equal("student A", result);
        }

        [Fact]
        public void Peek_ReturnsFirstItemWithoutRemovingIt() 
        {
            CustomQueue<string> queue = new CustomQueue<string> ();

            queue.Enqueue("student A");
            queue.Enqueue("student B");

            string result = queue.Peek();

            Assert.Equal("student A", result);
            Assert.Equal(2, queue.Count);
        }

        [Fact]
        public void IsEmpty_NewQueue_ReturnsTrue() 
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            bool result = queue.IsEmpty();

            Assert.True(result);
        }

        [Fact]
        public void Dequeue_WhenQueueIsEmpty_ShouldThrowException() 
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Peek_WhenQueueIsEmpty_ShouldThrowException() 
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
        
        [Fact]
        public void Enqueue_MoreThanFourItems_ShouldResizeAndKeepFifoOrder() 
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            //the original queue size is 4
            // adding 10 items forces it to resize

            for (int i = 1; i <= 10; i++)
            {
                queue.Enqueue(i);
            }

            Assert.Equal(10, queue.Count);
            Assert.Equal(1, queue.Peek());

            // the values must still come out in FIFO order
            for (int expected = 1; expected<=10; expected++)
            {
        
                Assert.Equal(expected, queue.Dequeue());
            }

            Assert.Equal(0, queue.Count);
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void Queue_ShouldWrapAroundAndMaintainFifoOrder()
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            //Fill the original fourt size array
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);

            //Remove two values from front
            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(20, queue.Dequeue());


            // these values should be placed in empty positions
            queue.Enqueue(50);
            queue.Enqueue(60);

            Assert.Equal(4, queue.Count);
            Assert.Equal(30, queue.Peek());
       
            // the logical Fifo order must be maintained
            Assert.Equal(30, queue.Dequeue());
            Assert.Equal(40, queue.Dequeue());      
            Assert.Equal(50, queue.Dequeue());
            Assert.Equal(60, queue.Dequeue());

            Assert.True(queue.IsEmpty());
            Assert.Equal(0, queue.Count);

        }






    }
}