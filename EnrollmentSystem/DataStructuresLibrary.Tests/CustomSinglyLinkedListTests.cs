using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        [Fact]
        public void AddLast_ShouldAddFirstItemAndIncreaseCount()
        {
            // Arrange
            CustomSinglyLinkedList<string> list =
                new CustomSinglyLinkedList<string>();

            // Act
            list.AddLast("IT101");

            // Assert
            Assert.Equal(1, list.Count);
            Assert.NotNull(list.Head);
            Assert.Equal("IT101", list.Head!.Data);
            Assert.Null(list.Head.Next);
        }

        [Fact]
        public void AddLast_ShouldAppendItemsInCorrectOrder()
        {
            // Arrange
            CustomSinglyLinkedList<string> list =
                new CustomSinglyLinkedList<string>();

            // Act
            list.AddLast("IT101");
            list.AddLast("IT102");
            list.AddLast("IT103");

            // Assert
            Assert.Equal(3, list.Count);
            Assert.Equal("IT101", list.Head!.Data);
            Assert.Equal("IT102", list.Head.Next!.Data);
            Assert.Equal("IT103", list.Head.Next.Next!.Data);
            Assert.Null(list.Head.Next.Next.Next);
        }

        [Fact]
        public void Remove_ShouldRemoveHeadNode()
        {
            // Arrange
            CustomSinglyLinkedList<string> list =
                new CustomSinglyLinkedList<string>();

            list.AddLast("IT101");
            list.AddLast("IT102");

            // Act
            bool result = list.Remove("IT101");

            // Assert
            Assert.True(result);
            Assert.Equal(1, list.Count);
            Assert.Equal("IT102", list.Head!.Data);
        }

        [Fact]
        public void Remove_ShouldRemoveMiddleNode()
        {
            // Arrange
            CustomSinglyLinkedList<string> list =
                new CustomSinglyLinkedList<string>();

            list.AddLast("IT101");
            list.AddLast("IT102");
            list.AddLast("IT103");

            // Act
            bool result = list.Remove("IT102");

            // Assert
            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal("IT101", list.Head!.Data);
            Assert.Equal("IT103", list.Head.Next!.Data);
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            // Arrange
            CustomSinglyLinkedList<string> list =
                new CustomSinglyLinkedList<string>();

            list.AddLast("IT101");

            // Act
            bool result = list.Remove("IT999");

            // Assert
            Assert.False(result);
            Assert.Equal(1, list.Count);
            Assert.Equal("IT101", list.Head!.Data);
        }
    }
}