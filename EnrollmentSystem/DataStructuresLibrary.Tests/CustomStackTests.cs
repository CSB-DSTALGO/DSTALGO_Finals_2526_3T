using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        // Push

        // Pushing one item should increase Count to 1.
        [Fact]
        public void Push_SingleItem_IncreasesCountToOne()
        {
            var stack = new CustomStack<int>();
            stack.Push(10);
            Assert.Equal(1, stack.Count);
        }

        // The most recently pushed item should be on top.
        [Fact]
        public void Push_MultipleItems_TopReflectsMostRecentlyPushed()
        {
            var stack = new CustomStack<string>();
            stack.Push("first");
            stack.Push("second");
            stack.Push("third");

            Assert.Equal("third", stack.Peek());
            Assert.Equal(3, stack.Count);
        }

        // Pushing past the initial capacity should trigger Resize() without losing data.
        [Fact]
        public void Push_BeyondInitialCapacity_ResizesWithoutLosingData()
        {
            var stack = new CustomStack<int>();

            for (int i = 0; i < 20; i++)
            {
                stack.Push(i);
            }

            Assert.Equal(20, stack.Count);
            Assert.Equal(19, stack.Peek());
        }

        // Pop

        // Pop should return the most recently pushed item (LIFO).
        [Fact]
        public void Pop_ReturnsMostRecentlyPushedItem()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            int popped = stack.Pop();

            Assert.Equal(2, popped);
        }

        // Pop should decrease Count by one.
        [Fact]
        public void Pop_DecreasesCountByOne()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Pop();

            Assert.Equal(1, stack.Count);
        }

        // Popping an empty stack should throw, not crash silently.
        [Fact]
        public void Pop_OnEmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        // Peek

        // Peek should not remove the item it looks at.
        [Fact]
        public void Peek_DoesNotRemoveItem()
        {
            var stack = new CustomStack<int>();
            stack.Push(5);

            stack.Peek();

            Assert.Equal(1, stack.Count);
        }

        // Peek should return the top item after multiple pushes.
        [Fact]
        public void Peek_ReturnsTopItem_AfterMultiplePushes()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Peek());
        }

        // Peeking an empty stack should throw, not crash silently.
        [Fact]
        public void Peek_OnEmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        // IsEmpty

        // A brand-new stack should report as empty.
        [Fact]
        public void IsEmpty_OnNewStack_ReturnsTrue()
        {
            var stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());
        }

        // A stack with at least one item should not report as empty.
        [Fact]
        public void IsEmpty_AfterPush_ReturnsFalse()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);

            Assert.False(stack.IsEmpty());
        }

        // A stack that's had everything popped back out should report as empty again.
        [Fact]
        public void IsEmpty_AfterPushThenPop_ReturnsTrue()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Pop();

            Assert.True(stack.IsEmpty());
        }

        // ToArray (sort/search helper)

        // ToArray should return items ordered from top to bottom.
        [Fact]
        public void ToArray_ReturnsElementsTopToBottom()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int[] snapshot = stack.ToArray();

            Assert.Equal(new[] { 3, 2, 1 }, snapshot);
        }

        // ToArray should not change the original stack's state.
        [Fact]
        public void ToArray_DoesNotMutateOriginalStack()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.ToArray();

            Assert.Equal(2, stack.Count);
            Assert.Equal(2, stack.Peek());
        }

        // ToArray on an empty stack should return an empty array, not throw.
        [Fact]
        public void ToArray_OnEmptyStack_ReturnsEmptyArray()
        {
            var stack = new CustomStack<int>();

            int[] snapshot = stack.ToArray();

            Assert.Empty(snapshot);
        }
    }
}