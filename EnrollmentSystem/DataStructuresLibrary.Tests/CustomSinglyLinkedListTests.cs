using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        // ---------------- Constructor / Head / Count ----------------

        [Fact]
        public void Constructor_ShouldCreateEmptyList_WithNullHead()
        {
            var list = new CustomSinglyLinkedList<int>();

            Assert.Null(list.Head);
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Head_ShouldPointToFirstAddedNode()
        {
            var list = new CustomSinglyLinkedList<string>();

            list.AddLast("First");
            list.AddLast("Second");

            Assert.Equal("First", list.Head!.Data);
        }

        [Fact]
        public void Head_ShouldUpdate_WhenHeadNodeIsRemoved()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("First");
            list.AddLast("Second");

            list.Remove("First");

            Assert.Equal("Second", list.Head!.Data);
        }

        // ---------------- AddLast ----------------

        [Fact]
        public void AddLast_ShouldSetHead_WhenListIsEmpty()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(10);

            Assert.NotNull(list.Head);
            Assert.Equal(10, list.Head!.Data);
        }

        [Fact]
        public void AddLast_ShouldAppendToEndOfChain_PreservingOrder()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.Equal(1, list.Head!.Data);
            Assert.Equal(2, list.Head!.Next!.Data);
            Assert.Equal(3, list.Head!.Next!.Next!.Data);
        }

        [Fact]
        public void AddLast_ShouldIncreaseCount_ForEachItemAdded()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.Equal(3, list.Count);
        }

        // ---------------- Remove ----------------

        [Fact]
        public void Remove_ShouldReturnTrue_WhenItemExists()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("Target");

            bool result = list.Remove("Target");

            Assert.True(result);
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("Something");

            bool result = list.Remove("NotThere");

            Assert.False(result);
        }

        [Fact]
        public void Remove_ShouldRelinkNeighbors_WhenRemovingMiddleNode()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            list.Remove(2);

            Assert.Equal(1, list.Head!.Data);
            Assert.Equal(3, list.Head!.Next!.Data);
            Assert.Null(list.Head!.Next!.Next);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void Remove_ShouldUpdateTail_WhenRemovingLastNode()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            list.Remove(2);
            // If tail bookkeeping is broken, this AddLast would corrupt the chain.
            list.AddLast(3);

            Assert.Equal(1, list.Head!.Data);
            Assert.Equal(3, list.Head!.Next!.Data);
        }
    }
}
