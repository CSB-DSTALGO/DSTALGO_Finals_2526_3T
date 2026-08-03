using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        [Fact]
        public void AddLast_ShouldIncreaseCount() // Test to check if AddLast method increases the count of the list
        {
            // Arrange
            var list = new CustomSinglyLinkedList<int>();

            // Act
            list.AddLast(10); // 

            // Assert
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void AddLast_ShouldSetHead_WhenListIsEmpty() // Test to check if AddLast method sets the head of the list when the list is empty
        {
            // Arrange
            var list = new CustomSinglyLinkedList<int>();

            // Act
            list.AddLast(5);

            // Assert
            Assert.NotNull(list.Head);
            Assert.Equal(5, list.Head.Data);
        }

        [Fact]
        public void AddLast_ShouldAppendNodeToEnd()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<int>();

            // Act
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            // Assert
            Assert.Equal(3, list.Head.Next.Next.Data);
        }

        [Fact]
        public void Remove_ShouldReturnTrue_WhenItemExists()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            // Act
            bool result = list.Remove(2);

            // Assert
            Assert.True(result);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            // Act
            bool result = list.Remove(5);

            // Assert
            Assert.False(result);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void Remove_ShouldRemoveHead()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);

            // Act
            list.Remove(10);

            // Assert
            Assert.Equal(20, list.Head.Data);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void NewList_ShouldHaveCountZero()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<int>();

            // Assert
            Assert.Equal(0, list.Count);
            Assert.Null(list.Head);
        }
    }
}