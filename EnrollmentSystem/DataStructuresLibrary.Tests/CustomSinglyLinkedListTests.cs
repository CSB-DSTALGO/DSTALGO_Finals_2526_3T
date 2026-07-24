// 12521269 Joaquin Bryan G. Ross
using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        // =====================================================================
        // AddLast
        // =====================================================================

        [Fact]
        public void AddLast_ShouldAppendNodeAndIncrementCount()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(10);
            list.AddLast(20);

            Assert.Equal(2, list.Count);
            Assert.True(list.Search(10));
            Assert.True(list.Search(20));
        }

        [Fact]
        public void AddLast_ShouldAppendToTheTailNotTheHead()
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
        public void AddLast_ShouldAcceptDuplicateValues()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(5);
            list.AddLast(5);

            Assert.Equal(2, list.Count);
        }

        // =====================================================================
        // Remove
        // =====================================================================

        [Fact]
        public void Remove_ShouldUpdateNodePointersCorrectly()
        {
            // Exercises all three positions: middle, head, and tail.
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.True(list.Remove(2)); // middle
            Assert.False(list.Search(2));
            Assert.Equal(2, list.Count);

            Assert.True(list.Remove(1)); // head
            Assert.True(list.Remove(3)); // tail, by now also the head
            Assert.Equal(0, list.Count);
            Assert.Null(list.Head);
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenItemIsAbsent()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);

            Assert.False(list.Remove(99));
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenListIsEmpty()
        {
            var list = new CustomSinglyLinkedList<int>();

            Assert.False(list.Remove(1));
            Assert.Equal(0, list.Count);
        }

        // =====================================================================
        // Search
        // =====================================================================

        [Fact]
        public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            Assert.True(list.Search(30)); // the tail requires a full traversal
        }

        [Fact]
        public void Search_ShouldReturnFalse_WhenItemIsAbsent()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);

            Assert.False(list.Search(999));
        }

        [Fact]
        public void Search_ShouldReturnFalse_WhenListIsEmpty()
        {
            var list = new CustomSinglyLinkedList<int>();

            Assert.False(list.Search(1));
        }

        // =====================================================================
        // Sort
        // =====================================================================

        [Fact]
        public void Sort_ShouldRelinkNodesIntoAscendingOrder()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(30);
            list.AddLast(10);
            list.AddLast(20);

            list.Sort();

            Assert.Equal(10, list.Head!.Data);
            Assert.Equal(20, list.Head!.Next!.Data);
            Assert.Equal(30, list.Head!.Next!.Next!.Data);
            Assert.Null(list.Head!.Next!.Next!.Next); // the chain still terminates
        }

        [Fact]
        public void Sort_ShouldPreserveCountAndMembership()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(3);
            list.AddLast(1);
            list.AddLast(2);

            list.Sort();

            Assert.Equal(3, list.Count);
            Assert.True(list.Search(1));
            Assert.True(list.Search(2));
            Assert.True(list.Search(3));
        }

        [Fact]
        public void Sort_ShouldHandleEmptyAndSingleNodeLists()
        {
            var empty = new CustomSinglyLinkedList<int>();
            var single = new CustomSinglyLinkedList<int>();
            single.AddLast(42);

            empty.Sort();
            single.Sort();

            Assert.Null(empty.Head);
            Assert.Equal(42, single.Head!.Data);
        }
    }
}
