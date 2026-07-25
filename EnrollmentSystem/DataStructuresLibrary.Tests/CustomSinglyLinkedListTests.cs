using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    // Unit tests for the CustomSinglyLinkedList class.
    public class CustomSinglyLinkedListTests
    {
        // Verifies that adding the first node correctly sets the head
        // and updates the node count.
        [Fact]
        public void AddLast_ShouldAddFirstNode()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(10);

            Assert.NotNull(list.Head);
            Assert.Equal(10, list.Head!.Data);
            Assert.Equal(1, list.Count);
        }

        // Verifies that additional nodes are appended to the end
        // of the linked list in the correct order.
        [Fact]
        public void AddLast_ShouldAppendToEnd()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(10);
            list.AddLast(20);

            Assert.Equal(10, list.Head!.Data);
            Assert.NotNull(list.Head.Next);
            Assert.Equal(20, list.Head.Next!.Data);
            Assert.Equal(2, list.Count);
        }

        // Verifies that an existing item is successfully removed
        // and the linked list is updated correctly.
        [Fact]
        public void Remove_ShouldRemoveExistingItem()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(10);
            list.AddLast(20);

            bool removed = list.Remove(10);

            Assert.True(removed);
            Assert.Equal(1, list.Count);
            Assert.Equal(20, list.Head!.Data);
        }

        // Verifies that attempting to remove a non-existent item
        // returns false and leaves the linked list unchanged.
        [Fact]
        public void Remove_ShouldReturnFalse_WhenItemNotFound()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(10);

            bool removed = list.Remove(30);

            Assert.False(removed);
            Assert.Equal(1, list.Count);
        }
    }
}