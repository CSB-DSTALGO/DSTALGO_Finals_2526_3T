using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    // Unit tests for the CustomStack class.
    public class CustomStackTests
    {
        // Verifies that pushing an item onto the stack
        // increases the total number of elements.
        [Fact]
        public void Push_ShouldIncreaseCount()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            Assert.Equal(1, stack.Count);
        }

        // Verifies that Pop removes and returns
        // the most recently pushed item (LIFO order).
        [Fact]
        public void Pop_ShouldReturnLastPushedItem()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);

            int value = stack.Pop();

            Assert.Equal(20, value);
            Assert.Equal(1, stack.Count);
        }

        // Verifies that Peek returns the top item
        // without removing it from the stack.
        [Fact]
        public void Peek_ShouldReturnTopWithoutRemoving()
        {
            var stack = new CustomStack<int>();

            stack.Push(5);

            Assert.Equal(5, stack.Peek());
            Assert.Equal(1, stack.Count);
        }

        // Verifies that IsEmpty returns true
        // when the stack contains no elements.
        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenStackIsEmpty()
        {
            var stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());
        }
    }
}