using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        // ---------------- Constructor / Count ----------------

        [Fact]
        public void Constructor_ShouldCreateEmptyStack()
        {
            var stack = new CustomStack<int>();

            Assert.Equal(0, stack.Count);
            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void Count_ShouldIncrease_AsItemsArePushed()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(2);

            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Count_ShouldDecrease_AsItemsArePopped()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Pop();

            Assert.Equal(1, stack.Count);
        }

        // ---------------- Push ----------------

        [Fact]
        public void Push_ShouldIncreaseCountByOne()
        {
            var stack = new CustomStack<string>();

            stack.Push("A");

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Push_ShouldPlaceNewItemOnTop()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);

            stack.Push(2);

            Assert.Equal(2, stack.Peek());
        }

        [Fact]
        public void Push_ShouldTriggerResize_WhenCapacityIsExceeded()
        {
            var stack = new CustomStack<int>();

            for (int i = 0; i < 20; i++)
            {
                stack.Push(i);
            }

            Assert.Equal(20, stack.Count);
            Assert.Equal(19, stack.Peek());
        }

        // ---------------- Pop ----------------

        [Fact]
        public void Pop_ShouldReturnItemsInLIFOOrder()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
        }

        [Fact]
        public void Pop_ShouldDecreaseCount()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Pop();

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Pop_ShouldThrowInvalidOperationException_WhenStackIsEmpty()
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Pop_ShouldWorkCorrectly_AfterResize()
        {
            var stack = new CustomStack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            Assert.Equal(9, stack.Pop());
            Assert.Equal(8, stack.Pop());
            Assert.Equal(8, stack.Count);
        }

        // ---------------- Peek ----------------

        [Fact]
        public void Peek_ShouldReturnTopItem_WithoutRemovingIt()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            int peeked = stack.Peek();

            Assert.Equal(2, peeked);
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Peek_ShouldReturnSameTopItem_OnRepeatedCalls()
        {
            var stack = new CustomStack<string>();
            stack.Push("top");

            Assert.Equal("top", stack.Peek());
            Assert.Equal("top", stack.Peek());
        }

        [Fact]
        public void Peek_ShouldThrowInvalidOperationException_WhenStackIsEmpty()
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        // ---------------- IsEmpty ----------------

        [Fact]
        public void IsEmpty_ShouldReturnTrue_ForNewStack()
        {
            var stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalse_AfterPush()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);

            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_AfterAllItemsPopped()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Pop();
            stack.Pop();

            Assert.True(stack.IsEmpty());
        }
    }
}
