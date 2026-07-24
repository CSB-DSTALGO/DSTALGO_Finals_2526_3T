using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void PushTest()
        {
            CustomStack<string> stack = new CustomStack<string>();
            stack.Push("Log 1"); // pushes an item to the stack

            Assert.Equal(1, stack.Count); // checks if the count increased
        }

        [Fact]
        public void PopTest()
        {
            CustomStack<string> stack = new CustomStack<string>();
            stack.Push("Log 1");
            stack.Push("Log 2");
            stack.Pop(); // removes the most recently added item (Log 2)

            Assert.Equal(1, stack.Count); // checks if the count decreased back to 1
        }

        [Fact]
        public void PeekTest()
        {
            CustomStack<string> stack = new CustomStack<string>();
            stack.Push("Log 1");
            stack.Push("Log 2");

            Assert.Equal("Log 2", stack.Peek()); // views the top item without removing it
        }

        [Fact]
        public void EmptyPopTest()
        {
            CustomStack<string> stack = new CustomStack<string>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop()); // ensures popping an empty stack throws an error
        }
    }
}