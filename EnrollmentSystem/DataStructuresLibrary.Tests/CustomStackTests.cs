using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
       
        //count tests
        [Fact]
        public void TestNewCustomStack() //new stack should be zero
        {
            var stack = new CustomStack<int>();

            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void TestPushOneItem() //count now should be 1
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void TestCountAfterPushAndPop() //count should return to 0
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Pop();

            Assert.Equal(0, stack.Count);
        }


        //push tests

        [Fact]
        public void TestPushItem() //count for new stack should be 1 when pushed 1
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void TestPushMultipleItems() //count should become 3
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.Equal(3, stack.Count);
        }

        [Fact]
        public void TestPushLastItemOnTop() //peek should return last pushed item
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.Equal(30, stack.Peek());
        }

        
        //pop Tests       
        [Fact]
        public void TestPopReturnsLastItem() //pop should return last pushed item
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);

            Assert.Equal(20, stack.Pop());
        }

        [Fact]
        public void TestPopDecreasesCount() //count should decrease after pop
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);

            stack.Pop();

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void TestPopEmptyStack() // Should throw exception
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        
        // Peek Tests       

        [Fact]
        public void TestPeekReturnsTopItem() //peek should return top item
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);

            Assert.Equal(20, stack.Peek());
        }

        [Fact]
        public void TestPeekDoesNotRemoveItem() //count should remain the same
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            stack.Peek();

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void TestPeekEmptyStack() // Should throw exception
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        
        //IsEmpty Tests        
        [Fact]
        public void TestNewStackIsEmpty() //new stack should be empty
        {
            var stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void TestStackNotEmptyAfterPush() //stack should not be empty
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void TestStackEmptyAfterPop() //stack should be empty again
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Pop();

            Assert.True(stack.IsEmpty());
        }
    }
}