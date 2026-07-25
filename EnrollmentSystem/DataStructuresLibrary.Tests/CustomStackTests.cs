using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        [Fact]
        public void Push_ShouldIncreaseCount()
        {
            CustomStack<int> stack = new();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.Equal(3, stack.Count);
        }

        [Fact]
        public void Pop_ShouldReturnItemsInLIFOOrder()
        {
            CustomStack<int> stack = new();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.Equal(30, stack.Pop());
            Assert.Equal(20, stack.Pop());
            Assert.Equal(10, stack.Pop());

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void Peek_ShouldReturnTopItemWithoutRemovingIt()
        {
            CustomStack<int> stack = new();

            stack.Push(10);
            stack.Push(20);

            Assert.Equal(20, stack.Peek());
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenStackHasNoItems()
        {
            CustomStack<int> stack = new();

            Assert.True(stack.IsEmpty());

            stack.Push(10);

            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void Pop_ShouldThrowException_WhenStackIsEmpty()
        {
            CustomStack<int> stack = new();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Peek_ShouldThrowException_WhenStackIsEmpty()
        {
            CustomStack<int> stack = new();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Search_ShouldReturnTrue_WhenItemExists()
        {
            CustomStack<int> stack = new();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.True(stack.Search(20));
        }

        [Fact]
        public void Search_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            CustomStack<int> stack = new();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.False(stack.Search(40));
        }

        [Fact]
        public void Sort_ShouldArrangeItemsInAscendingOrder()
        {
            CustomStack<int> stack = new();

            stack.Push(30);
            stack.Push(10);
            stack.Push(20);

            stack.Sort();

            Assert.Equal(30, stack.Pop());
            Assert.Equal(20, stack.Pop());
            Assert.Equal(10, stack.Pop());
        }
    }
}