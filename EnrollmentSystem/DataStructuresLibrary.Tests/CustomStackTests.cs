//CustomStackTests.cs
using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        [Fact]
        public void NewStack_ShouldBeEmpty()
        {
            // Arrange
            var stack = new CustomStack<int>();

            // Assert
            Assert.True(stack.IsEmpty());
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Push_ShouldIncreaseCount()
        {
            // Arrange
            var stack = new CustomStack<int>();

            // Act
            stack.Push(10);

            // Assert
            Assert.Equal(1, stack.Count);
            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void Peek_ShouldReturnTopItem()
        {
            // Arrange
            var stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);

            // Act
            int result = stack.Peek();

            // Assert
            Assert.Equal(20, result);
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Pop_ShouldReturnTopItem()
        {
            // Arrange
            var stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);

            // Act
            int result = stack.Pop();

            // Assert
            Assert.Equal(20, result);
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Pop_ShouldFollowLIFOOrder()
        {
            // Arrange
            var stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act & Assert
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void Peek_ShouldNotRemoveItem()
        {
            // Arrange
            var stack = new CustomStack<string>();
            stack.Push("A");

            // Act
            string item = stack.Peek();

            // Assert
            Assert.Equal("A", item);
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenAllItemsRemoved()
        {
            // Arrange
            var stack = new CustomStack<int>();
            stack.Push(100);

            // Act
            stack.Pop();

            // Assert
            Assert.True(stack.IsEmpty());
            Assert.Equal(0, stack.Count);
        }
    }
}