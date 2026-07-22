using System;
using Xunit;
using DataStructuresLibrary;
using System.Security.Cryptography.X509Certificates;

namespace DataStructuresLibrary.Tests
{
    public class CustomQueueTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void QueueTest()
        {
            CustomQueue<string> queue = new CustomQueue<string>();
            queue.Enqueue("Student 1");
            queue.Enqueue("Student 2");
            queue.Enqueue("Student 3");          
            Assert.Equal(3, queue.Count);

        }
        [Fact]
        public void DequeueTest()
        {
            CustomQueue<string> queue = new CustomQueue<string>();
            queue.Enqueue("Student 1");
            queue.Enqueue("Student 2");
            queue.Dequeue();
            Assert.Equal(1, queue.Count);

        }
        [Fact]
        public void PeekTest()
        {
            CustomQueue<string> queue = new CustomQueue<string>();
            queue.Enqueue("Student 1");
            queue.Enqueue("Student 2");
            queue.Dequeue();

            Assert.Equal("Student 2", queue.Peek());

        }
       
    }
}