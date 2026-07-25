using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        [Fact]
        public void Push_ShouldIncreaseCount()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            Assert.Equal(1, stack.Count);
        }

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

        [Fact]
        public void Peek_ShouldReturnTopWithoutRemoving()
        {
            var stack = new CustomStack<int>();

            stack.Push(5);

            Assert.Equal(5, stack.Peek());
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenStackIsEmpty()
        {
            var stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());
        }
    }
}