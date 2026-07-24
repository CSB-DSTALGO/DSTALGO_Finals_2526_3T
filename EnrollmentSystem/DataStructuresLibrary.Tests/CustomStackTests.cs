// 12521269 Joaquin Bryan G. Ross
using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        // =====================================================================
        // Push
        // =====================================================================

        [Fact]
        public void PushAndPop_ShouldMaintainStrictLIFOOrder()
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
        public void Push_ShouldIncrementCount()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);

            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Push_ShouldPreserveOrder_WhenGrowingBeyondInitialCapacity()
        {
            // The backing array starts at 4 slots, so this forces several resizes.
            var stack = new CustomStack<int>();

            for (int i = 0; i < 20; i++)
            {
                stack.Push(i);
            }

            Assert.Equal(20, stack.Count);
            for (int i = 19; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }
        }

        // =====================================================================
        // Pop
        // =====================================================================

        [Fact]
        public void Pop_ShouldDecrementCount()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Pop();

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Pop_ShouldThrow_WhenStackIsEmpty()
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Pop_ShouldThrow_WhenStackIsDrained()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Pop();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        // =====================================================================
        // Peek
        // =====================================================================

        [Fact]
        public void Peek_ShouldReturnTopElementWithoutRemovingIt()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            Assert.Equal(2, stack.Peek());
            Assert.Equal(2, stack.Count);
            Assert.Equal(2, stack.Peek()); // repeatable, so nothing was consumed
        }

        [Fact]
        public void Peek_ShouldFollowTheMostRecentPush()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();

            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void Peek_ShouldThrow_WhenStackIsEmpty()
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        // =====================================================================
        // IsEmpty
        // =====================================================================

        [Fact]
        public void IsEmpty_ShouldReturnTrue_ForANewStack()
        {
            var stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalse_WhenItemsArePushed()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);

            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_AfterTheStackIsCleared()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Pop();

            Assert.True(stack.IsEmpty());
        }

        // =====================================================================
        // Search
        // =====================================================================

        [Fact]
        public void Search_ShouldReturnOneBasedDepthFromTop_WhenItemExists()
        {
            var stack = new CustomStack<int>();
            stack.Push(10); // bottom
            stack.Push(20);
            stack.Push(30); // top

            Assert.Equal(1, stack.Search(30));
            Assert.Equal(2, stack.Search(20));
            Assert.Equal(3, stack.Search(10));
        }

        [Fact]
        public void Search_ShouldReturnMinusOne_WhenItemIsAbsent()
        {
            var stack = new CustomStack<int>();
            stack.Push(10);

            Assert.Equal(-1, stack.Search(999));
        }

        [Fact]
        public void Search_ShouldNotDisturbTheStack()
        {
            var stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);

            stack.Search(10);

            Assert.Equal(2, stack.Count);
            Assert.Equal(20, stack.Peek());
        }

        // =====================================================================
        // Sort
        // =====================================================================

        [Fact]
        public void Sort_ShouldReorderStackWithSmallestItemAtTop()
        {
            var stack = new CustomStack<int>();
            stack.Push(30);
            stack.Push(10);
            stack.Push(20);

            stack.Sort();

            Assert.Equal(10, stack.Peek());
        }

        [Fact]
        public void Sort_ShouldMakePoppingYieldAscendingOrder()
        {
            var stack = new CustomStack<int>();
            stack.Push(30);
            stack.Push(10);
            stack.Push(20);

            stack.Sort();

            Assert.Equal(10, stack.Pop());
            Assert.Equal(20, stack.Pop());
            Assert.Equal(30, stack.Pop());
        }

        [Fact]
        public void Sort_ShouldHandleEmptyAndSingleItemStacks()
        {
            var empty = new CustomStack<int>();
            var single = new CustomStack<int>();
            single.Push(42);

            empty.Sort();
            single.Sort();

            Assert.True(empty.IsEmpty());
            Assert.Equal(42, single.Peek());
        }
    }
}
