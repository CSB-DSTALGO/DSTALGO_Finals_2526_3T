using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        [Fact]
        public void Count_NewStack_ReturnsZero()
        {
            CustomStack<string> stack = new CustomStack<string>();

            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Push_SingleItem_IncrementsCount()
        {
            CustomStack<string> stack = new CustomStack<string>();

            stack.Push("Bob");

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Push_MultipleItems_ResizesAndIncrementsCount()
        {
            CustomStack<string> stack = new CustomStack<string>();

            stack.Push("Bob");
            stack.Push("May");
            stack.Push("Eisen");
            stack.Push("Alexie");
            stack.Push("Jino");

            Assert.Equal(5, stack.Count);
        }

        [Fact]
        public void Pop_ValidStack_ReturnsTopItemAndDecrementsCount()
        {
            CustomStack<string> stack = new CustomStack<string>();
            stack.Push("Bob");
            stack.Push("May");

            string popped = stack.Pop();

            Assert.Equal("May", popped);
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Pop_EmptyStack_ThrowsInvalidOperationException()
        {
            CustomStack<string> stack = new CustomStack<string>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Peek_ReturnsTopItemWithoutRemoving()
        {
            CustomStack<string> stack = new CustomStack<string>();
            stack.Push("Bob");
            stack.Push("May");

            string peeked = stack.Peek();

            Assert.Equal("May", peeked);
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Peek_EmptyStack_ThrowsInvalidOperationException()
        {
            CustomStack<string> stack = new CustomStack<string>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void IsEmpty_ReturnsTrueWhenEmpty_FalseWhenNotEmpty()
        {
            CustomStack<string> stack = new CustomStack<string>();

            Assert.True(stack.IsEmpty());

            stack.Push("Bob");

            Assert.False(stack.IsEmpty());
        }
    }
}