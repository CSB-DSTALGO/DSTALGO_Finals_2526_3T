using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void NewStack_ShouldBeEmpty()
        {
            var stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Push_ShouldIncreaseCount()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Push_And_Peek_ShouldReturnLastItem()
        {
            var stack = new CustomStack<string>();

            stack.Push("A");
            stack.Push("B");

            Assert.Equal("B", stack.Peek());
        }

        [Fact]
        public void Pop_ShouldReturnLastItem()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(2);

            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Pop_OnEmptyStack_ShouldThrow()
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Peek_OnEmptyStack_ShouldThrow()
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalseAfterPush()
        {
            var stack = new CustomStack<int>();

            stack.Push(100);

            Assert.False(stack.IsEmpty());
        }
    }
}