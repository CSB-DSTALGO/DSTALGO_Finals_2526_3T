using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        [Fact]
        public void NewStack_IsEmpty()
        {
            var stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void NewStack_CountIsZero()
        {
            var stack = new CustomStack<int>();

            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Push_AddsItem()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Push_MultipleItems()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.Equal(3, stack.Count);
        }

        [Fact]
        public void Push_ThenNotEmpty()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void Pop_ReturnsLastItem()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);

            Assert.Equal(20, stack.Pop());
        }

        [Fact]
        public void Pop_DecreasesCount()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);

            stack.Pop();

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Pop_AllItems_EmptyStack()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            stack.Pop();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void Peek_ReturnsTopItem()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);
            stack.Push(20);

            Assert.Equal(20, stack.Peek());
        }

        [Fact]
        public void Peek_DoesNotRemoveItem()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            stack.Peek();

            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Peek_KeepsStackNotEmpty()
        {
            var stack = new CustomStack<int>();

            stack.Push(10);

            stack.Peek();

            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void EmptyStack_IsEmpty_ReturnsTrue()
        {
            var stack = new CustomStack<int>();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void AfterPush_IsEmpty_ReturnsFalse()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);

            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void AfterPopAll_IsEmpty_ReturnsTrue()
        {
            var stack = new CustomStack<int>();

            stack.Push(1);
            stack.Pop();

            Assert.True(stack.IsEmpty());
        }
    }
}