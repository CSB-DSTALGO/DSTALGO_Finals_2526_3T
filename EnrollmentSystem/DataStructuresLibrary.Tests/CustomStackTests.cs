using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        [Fact]
        public void NewStack_ShouldBeEmpty()
        {
            CustomStack<int> stack = new CustomStack<int>();


            Assert.True(stack.IsEmpty());
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Push_ShouldIncreaseCount()
        {
            CustomStack<int> stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);


            Assert.Equal(2, stack.Count);
            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void Peek_ShouldReturnTopItem_WithoutRemovingIt()
        {
            CustomStack<int> stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);


            Assert.Equal(20, stack.Peek());
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Pop_ShouldReturnTopItem_AndDecreaseCount()
        {
            CustomStack<int> stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);

            int item = stack.Pop();


            Assert.Equal(20, item);
            Assert.Equal(1, stack.Count);
            Assert.Equal(10, stack.Peek());
        }

        [Fact]
        public void Pop_OnEmptyStack_ShouldThrowException()
        {
            CustomStack<int> stack = new CustomStack<int>();


            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Peek_OnEmptyStack_ShouldThrowException()
        {
            CustomStack<int> stack = new CustomStack<int>();


            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Search_ShouldReturnCorrectIndex()
        {
            CustomStack<string> stack = new CustomStack<string>();

            stack.Push("A");
            stack.Push("B");
            stack.Push("C");


            Assert.Equal(1, stack.Search("B"));
            Assert.Equal(2, stack.Search("C"));
            Assert.Equal(-1, stack.Search("X"));
        }

        [Fact]
        public void Push_ShouldResize_WhenCapacityExceeded()
        {
            CustomStack<int> stack = new CustomStack<int>();

            for (int i = 1; i <= 10; i++)
                stack.Push(i);


            Assert.Equal(10, stack.Count);
            Assert.Equal(10, stack.Peek());
        }

        [Fact]
        public void Pop_ShouldFollowLifoOrder()
        {
            CustomStack<int> stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);


            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.True(stack.IsEmpty());
        }
    }   
}