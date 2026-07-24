using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void Push_SingleItem_IncreasesCountAndStoresValue()
        {
            var stack = new CustomStack<string>();

            stack.Push("First");

            Assert.Equal(1, stack.Count);
            Assert.False(stack.IsEmpty());
            Assert.Equal("First", stack.Peek());
        }
        [Fact]
        public void Pop_RemovesAndReturnsTopItemInLIFO()
        {
            var stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            int topItem = stack.Pop();

            Assert.Equal(30, topItem);
            Assert.Equal(2, stack.Count);
            Assert.Equal(20, stack.Peek());
        }
        [Fact]
        public void Push_BeyondCapacity_TriggersResizeAndPreservesLIFO()
        {
            var stack = new CustomStack<int>(); //Initial capacity = 2
            stack.Push(1);
            stack.Push(2);
            stack.Push(3); //Triggers inline array resize

            Assert.Equal(3, stack.Count);
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.True(stack.IsEmpty());
        }
        [Fact]
        public void Peek_ReturnsTopItemWithoutRemovingIt()
        {
            var stack = new CustomStack<char>();
            stack.Push('A');
            stack.Push('B');

            char peeked = stack.Peek();

            Assert.Equal('B', peeked);
            Assert.Equal(2, stack.Count); //Count should remain unchanged
        }
        [Fact]
        public void Pop_EmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new CustomStack<double>();

            Assert.Throws<InvalidOperationException>(() => { stack.Pop(); });
        }
        [Fact]
        public void Peek_EmptyStack_THrowsInvalidOperationException()
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => { stack.Peek(); });
        }
    }   
} 