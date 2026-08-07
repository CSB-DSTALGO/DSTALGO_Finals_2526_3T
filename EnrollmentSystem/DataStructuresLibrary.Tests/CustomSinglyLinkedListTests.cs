using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        // ---------- Constructor ----------

        [Fact]
        public void Constructor_ShouldCreateEmptyList()
        {
            var list = new CustomSinglyLinkedList<int>();

            Assert.Equal(0, list.Count);
            Assert.Null(list.Head);
        }

        [Fact]
        public void Constructor_HeadShouldBeNull_ForNewList()
        {
            var list = new CustomSinglyLinkedList<string>();

            Assert.Null(list.Head);
        }

        [Fact]
        public void Constructor_DifferentInstances_ShouldNotShareState()
        {
            var list1 = new CustomSinglyLinkedList<int>();
            var list2 = new CustomSinglyLinkedList<int>();

            list1.AddLast(1);

            Assert.Equal(1, list1.Count);
            Assert.Equal(0, list2.Count);
        }

        // ---------- AddLast ----------

        [Fact]
        public void AddLast_ShouldIncreaseCount()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(10);

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void AddLast_ShouldSetHead_WhenListWasEmpty()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(5);

            Assert.NotNull(list.Head);
            Assert.Equal(5, list.Head!.Data);
        }

        [Fact]
        public void AddLast_ShouldPreserveInsertionOrder()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            var values = list.ToArray();

            Assert.Equal(new[] { 1, 2, 3 }, values);
        }

        // ---------- Remove ----------

        [Fact]
        public void Remove_ShouldReturnTrue_AndDecreaseCount_WhenItemExists()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            bool removed = list.Remove(1);

            Assert.True(removed);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);

            bool removed = list.Remove(99);

            Assert.False(removed);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void Remove_ShouldUpdateHead_WhenRemovingHeadNode()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            list.Remove(1);

            Assert.Equal(2, list.Head!.Data);
        }

        [Fact]
        public void Remove_ShouldHandleTailRemoval_AndAllowFurtherInserts()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            list.Remove(2); // removes the tail
            list.AddLast(3); // should correctly reattach to the new tail

            Assert.Equal(new[] { 1, 3 }, list.ToArray());
        }

        // ---------- Contains ----------

        [Fact]
        public void Contains_ShouldReturnTrue_WhenItemExists()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(42);

            Assert.True(list.Contains(42));
        }

        [Fact]
        public void Contains_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);

            Assert.False(list.Contains(2));
        }

        [Fact]
        public void Contains_ShouldReturnFalse_ForEmptyList()
        {
            var list = new CustomSinglyLinkedList<string>();

            Assert.False(list.Contains("anything"));
        }

        // ---------- Sort ----------

        [Fact]
        public void Sort_ShouldOrderElementsAscending()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(3);
            list.AddLast(1);
            list.AddLast(2);

            list.Sort();

            Assert.Equal(new[] { 1, 2, 3 }, list.ToArray());
        }

        [Fact]
        public void Sort_ShouldDoNothing_ForEmptyList()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.Sort();

            Assert.Equal(0, list.Count);
            Assert.Null(list.Head);
        }

        [Fact]
        public void Sort_ShouldDoNothing_ForSingleElementList()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(7);

            list.Sort();

            Assert.Equal(new[] { 7 }, list.ToArray());
        }

        // ---------- ToArray ----------

        [Fact]
        public void ToArray_ShouldReturnEmptyArray_ForEmptyList()
        {
            var list = new CustomSinglyLinkedList<int>();

            Assert.Empty(list.ToArray());
        }

        [Fact]
        public void ToArray_ShouldMatchCount()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.Equal(list.Count, list.ToArray().Length);
        }

        [Fact]
        public void ToArray_ShouldReflectOrder_AfterRemovalAndSort()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(1);
            list.AddLast(3);

            list.Remove(5);
            list.Sort();

            Assert.Equal(new[] { 1, 3 }, list.ToArray());
        }

        [Fact]
        public void Reverse_ShouldInvertNodeOrder()
        {
            // INSTANTIATE
            var list = new CustomSinglyLinkedList<int>();

            // ARRANGE
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            // ACT
            list.ReverseList();

            // ASSERT
            Assert.Equal(3, list.Head!.Data);
            Assert.Equal(2, list.Head!.Next!.Data);
            Assert.Equal(1, list.Head!.Next!.Next!.Data);
            Assert.Null(list.Head!.Next!.Next!.Next);
        }
    }
}