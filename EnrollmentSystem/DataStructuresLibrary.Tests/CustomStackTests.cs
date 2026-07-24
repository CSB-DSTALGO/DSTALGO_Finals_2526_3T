using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        // ---------------- Push / Count ----------------

        [Fact]
        public void Push_ShouldIncreaseCount()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.Equal(3, stack.Count);
        }

        [Fact]
        public void Push_ShouldPlaceNewestItemOnTop()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Peek());
        }

        [Fact]
        public void Push_ShouldResizeWhenCapacityExceeded()
        {
            CustomStack<int> stack = new CustomStack<int>();
            // default capacity is 4, so pushing 5 items forces an internal resize
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Assert.Equal(5, stack.Count);
            Assert.Equal(5, stack.Peek());
        }

        // ---------------- Pop ----------------

        [Fact]
        public void Pop_ShouldReturnLastPushedItem()
        {
            CustomStack<string> stack = new CustomStack<string>();
            stack.Push("first");
            stack.Push("second");

            string popped = stack.Pop();

            Assert.Equal("second", popped);
        }

        [Fact]
        public void Pop_ShouldDecreaseCount()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Pop();

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Pop_ShouldThrowException_WhenStackIsEmpty()
        {
            CustomStack<int> stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        // ---------------- Peek ----------------

        [Fact]
        public void Peek_ShouldReturnTopItem_WithoutRemovingIt()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(100);
            stack.Push(200);

            int peeked = stack.Peek();

            Assert.Equal(200, peeked);
            Assert.Equal(2, stack.Count); // count must stay the same
        }

        [Fact]
        public void Peek_ShouldReflectMostRecentPush()
        {
            CustomStack<string> stack = new CustomStack<string>();
            stack.Push("A");
            Assert.Equal("A", stack.Peek());

            stack.Push("B");
            Assert.Equal("B", stack.Peek());
        }

        [Fact]
        public void Peek_ShouldThrowException_WhenStackIsEmpty()
        {
            CustomStack<int> stack = new CustomStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        // ---------------- IsEmpty ----------------

        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenNoItemsPushed()
        {
            CustomStack<int> stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalse_AfterPush()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(1);

            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_AfterAllItemsPopped()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(1);
            stack.Pop();

            Assert.True(stack.IsEmpty());
        }

        // ---------------- Search ----------------

        [Fact]
        public void Search_ShouldReturnOne_WhenItemIsOnTop()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);

            Assert.Equal(1, stack.Search(20));
        }

        [Fact]
        public void Search_ShouldReturnCorrectDistanceFromTop()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // 10 was pushed first, so it sits 3 positions from the top
            Assert.Equal(3, stack.Search(10));
        }

        [Fact]
        public void Search_ShouldReturnNegativeOne_WhenItemNotFound()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);

            Assert.Equal(-1, stack.Search(999));
        }

        // ---------------- Sort ----------------

        [Fact]
        public void Sort_ShouldOrderElementsAscending()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(30);
            stack.Push(10);
            stack.Push(20);

            stack.Sort((a, b) => a.CompareTo(b));

            // after an ascending sort, the largest value should now be on top
            Assert.Equal(30, stack.Peek());
        }

        [Fact]
        public void Sort_ShouldNotChangeCount()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(5);
            stack.Push(1);
            stack.Push(3);

            stack.Sort((a, b) => a.CompareTo(b));

            Assert.Equal(3, stack.Count);
        }

        [Fact]
        public void Sort_ShouldHandleAlreadySortedStack()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack.Sort((a, b) => a.CompareTo(b));

            Assert.Equal(3, stack.Peek());
        }
    }
}