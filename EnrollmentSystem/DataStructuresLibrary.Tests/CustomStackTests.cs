using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        [Fact]
        public void Push_IncreasesCount()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(2);

            Assert.Equal(2, stack.Count);
        }

        //ADD ALL YOUR TESTS HERE
         [Fact]
        public void Push_BeyondInitialCapacity_ResizesAndKeepsAllItems()
        {
            var stack = new CustomStack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            Assert.Equal(10, stack.Count);
            Assert.Equal(9, stack.Peek());
        }

        [Fact]
        public void Push_OnEmptyStack_MakesItNotEmpty()
        {
            var stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());

            stack.Push(42);

            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void Pop_FollowsLifoOrder()
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

        [Fact]
        public void Peek_ReturnsTopItem_WithoutRemovingIt()
        {
            var stack = new CustomStack<string>();

            stack.Push("first");
            stack.Push("second");

            var peeked = stack.Peek();

            Assert.Equal("second", peeked);
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Peek_OnEmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new CustomStack<string>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Peek_AfterPop_ReturnsNewTop()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);

            stack.Pop();

            Assert.Equal(10, stack.Peek());
        }

        [Fact]
        public void IsEmpty_OnNewStack_ReturnsTrue()
        {
            var stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_AfterPushThenPopAll_ReturnsTrue()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);
            stack.Pop();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void IsEmpty_WithItemsOnStack_ReturnsFalse()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);

            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void Count_OnNewStack_ReturnsZero()
        {
            var stack = new CustomStack<int>();

            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Count_ReflectsNumberOfItems()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();

            Assert.Equal(2, stack.Count);
        }

        

        [Fact]
        public void ToArray_ReturnsElementsTopToBottom()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var array = stack.ToArray();

            Assert.Equal(new[] { 3, 2, 1 }, array);
        }

        [Fact]
        public void ToArray_DoesNotMutateTheStack()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(2);

            stack.ToArray();

            Assert.Equal(2, stack.Count);
            Assert.Equal(2, stack.Peek());
        }

        [Fact]
        public void ToArray_OnEmptyStack_ReturnsEmptyArray()
        {
            var stack = new CustomStack<int>();

            var array = stack.ToArray();

            Assert.Empty(array);
        }

        

        [Fact]
        public void Sort_OrdersStackAscending_SmallestOnTop()
        {
            var stack = new CustomStack<int>();

            stack.Push(5);
            stack.Push(1);
            stack.Push(4);
            stack.Push(2);
            stack.Push(3);

            stack.Sort((a, b) => a.CompareTo(b));

            Assert.Equal(1, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(3, stack.Pop());
            Assert.Equal(4, stack.Pop());
            Assert.Equal(5, stack.Pop());
        }

        [Fact]
        public void Sort_DoesNotChangeCount()
        {
            var stack = new CustomStack<int>();

            stack.Push(3);
            stack.Push(1);
            stack.Push(2);

            stack.Sort((a, b) => a.CompareTo(b));

            Assert.Equal(3, stack.Count);
        }

        [Fact]
        public void Sort_OnEmptyOrSingleElementStack_DoesNotThrow()
        {
            var empty = new CustomStack<int>();
            var single = new CustomStack<int>();
            single.Push(42);

            empty.Sort((a, b) => a.CompareTo(b));
            single.Sort((a, b) => a.CompareTo(b));

            Assert.True(empty.IsEmpty());
            Assert.Equal(42, single.Peek());
        }

        [Fact]
        public void Sort_NullComparison_ThrowsArgumentNullException()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);

            Assert.Throws<ArgumentNullException>(() => stack.Sort(null!));
        }

        

        [Fact]
        public void IndexOf_TopItem_ReturnsZero()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var index = stack.IndexOf(x => x == 3);

            Assert.Equal(0, index);
        }

        [Fact]
        public void IndexOf_ItemBelowTop_ReturnsDistanceFromTop()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var index = stack.IndexOf(x => x == 1);

            Assert.Equal(2, index);
        }

        [Fact]
        public void IndexOf_MissingItem_ReturnsNegativeOne()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(2);

            var index = stack.IndexOf(x => x == 99);

            Assert.Equal(-1, index);
        }

        [Fact]
        public void IndexOf_DoesNotChangeStackOrderOrCount()
        {
            var stack = new CustomStack<int>();

            stack.Push(3);
            stack.Push(1);
            stack.Push(2);

            stack.IndexOf(x => x == 3);

            Assert.Equal(3, stack.Count);
            Assert.Equal(2, stack.Peek());
        }

        [Fact]
        public void IndexOf_NullPredicate_ThrowsArgumentNullException()
        {
            var stack = new CustomStack<int>();
            stack.Push(1);

            Assert.Throws<ArgumentNullException>(() => stack.IndexOf(null!));
        }
    }
}
