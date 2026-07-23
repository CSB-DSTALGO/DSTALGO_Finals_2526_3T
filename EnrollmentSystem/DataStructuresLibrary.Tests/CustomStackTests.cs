using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        // ---------- Push ----------

        [Fact]
        public void Push_SingleItem_IncreasesCountToOne()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Push_MultipleItems_PlacesLastPushedOnTop()
        {
            var stack = new CustomStack<string>();

            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            Assert.Equal("c", stack.Peek());
            Assert.Equal(3, stack.Count);
        }

        [Fact]
        public void Push_BeyondInitialCapacity_ResizesAndKeepsAllItems()
        {
            var stack = new CustomStack<int>();

            for (int i = 0; i < 20; i++)
            {
                stack.Push(i);
            }

            Assert.Equal(20, stack.Count);
            Assert.Equal(19, stack.Peek());
        }

        // ---------- Pop ----------

        [Fact]
        public void Pop_ReturnsLastPushedItem()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            int result = stack.Pop();

            Assert.Equal(2, result);
        }

        [Fact]
        public void Pop_DecreasesCount()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Pop();

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Pop_OnEmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        // ---------- Peek ----------

        [Fact]
        public void Peek_ReturnsTopItem_WithoutRemovingIt()
        {
            var stack = new CustomStack<int>();
            stack.Push(5);
            stack.Push(9);

            int result = stack.Peek();

            Assert.Equal(9, result);
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Peek_OnEmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        // ---------- IsEmpty ----------

        [Fact]
        public void IsEmpty_OnNewStack_ReturnsTrue()
        {
            var stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_AfterPush_ReturnsFalse()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);

            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_AfterPushAndPopAllItems_ReturnsTrue()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            stack.Pop();

            Assert.True(stack.IsEmpty());
        }

        // ---------- Count ----------

        [Fact]
        public void Count_OnNewStack_IsZero()
        {
            var stack = new CustomStack<int>();

            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Count_ReflectsNumberOfPushesMinusPops()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();

            Assert.Equal(2, stack.Count);
        }

        // ---------- Search ----------

        [Fact]
        public void Search_ItemExists_ReturnsCorrectIndex()
        {
            var stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            int index = stack.Search(20);

            Assert.Equal(1, index);
        }

        [Fact]
        public void Search_ItemDoesNotExist_ReturnsNegativeOne()
        {
            var stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);

            int index = stack.Search(99);

            Assert.Equal(-1, index);
        }

        [Fact]
        public void Search_WithPredicate_FindsMatchingItem()
        {
            var stack = new CustomStack<string>();
            stack.Push("apple");
            stack.Push("banana");
            stack.Push("cherry");

            int index = stack.Search(s => s.StartsWith("ban"));

            Assert.Equal(1, index);
        }

        // ---------- Sort ----------

        [Fact]
        public void Sort_UnsortedIntegers_SortsInAscendingOrder()
        {
            var stack = new CustomStack<int>();
            stack.Push(30);
            stack.Push(10);
            stack.Push(20);

            stack.Sort();

            Assert.Equal(0, stack.Search(10));
            Assert.Equal(1, stack.Search(20));
            Assert.Equal(2, stack.Search(30));
        }

        [Fact]
        public void Sort_WithCustomComparison_SortsCorrectly()
        {
            var stack = new CustomStack<string>();
            stack.Push("banana");
            stack.Push("apple");
            stack.Push("cherry");

            stack.Sort((a, b) => string.Compare(a, b));

            Assert.Equal(0, stack.Search("apple"));
            Assert.Equal(1, stack.Search("banana"));
            Assert.Equal(2, stack.Search("cherry"));
        }

        [Fact]
        public void Sort_DoesNotChangeCount()
        {
            var stack = new CustomStack<int>();
            stack.Push(3);
            stack.Push(1);
            stack.Push(2);

            stack.Sort();

            Assert.Equal(3, stack.Count);
        }
    }
}