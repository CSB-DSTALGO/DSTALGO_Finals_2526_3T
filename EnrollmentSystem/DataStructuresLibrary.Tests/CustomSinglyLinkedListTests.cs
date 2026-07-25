using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        // =====================================
        // Count / AddLast
        // =====================================

        [Fact]
        public void Count_WhenNewListCreated_ReturnsZero()
        {
            var list = new CustomSinglyLinkedList<int>();
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void AddLast_SingleItem_SetsHeadAndIncreasesCount()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("CS101");

            Assert.Equal(1, list.Count);
            Assert.NotNull(list.Head);
            Assert.Equal("CS101", list.Head!.Data);
        }

        [Fact]
        public void AddLast_MultipleItems_ChainsThemInInsertionOrder()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("CS101");
            list.AddLast("CS102");
            list.AddLast("CS103");

            Assert.Equal(3, list.Count);
            Assert.Equal(new[] { "CS101", "CS102", "CS103" }, list.ToArray());
        }

        // =====================================
        // Remove
        // =====================================

        [Fact]
        public void Remove_ExistingItem_RemovesItAndReturnsTrue()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            bool removed = list.Remove(2);

            Assert.True(removed);
            Assert.Equal(2, list.Count);
            Assert.Equal(new[] { 1, 3 }, list.ToArray());
        }

        [Fact]
        public void Remove_NonExistingItem_ReturnsFalseAndLeavesListUnchanged()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            bool removed = list.Remove(99);

            Assert.False(removed);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void Remove_HeadItem_UpdatesHeadCorrectly()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            list.Remove(1);

            Assert.Equal(2, list.Head!.Data);
        }

        [Fact]
        public void Remove_TailItem_AllowsSubsequentAddLastToStillWork()
        {
            // Regression check: removing the tail must correctly re-point the internal
            // tail reference, or a following AddLast would silently corrupt the chain.
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            list.Remove(2); // 2 was the tail

            list.AddLast(3);

            Assert.Equal(new[] { 1, 3 }, list.ToArray());
        }

        [Fact]
        public void Remove_OnEmptyList_ReturnsFalse()
        {
            var list = new CustomSinglyLinkedList<string>();

            Assert.False(list.Remove("anything"));
        }

        // =====================================
        // RemoveWhere
        // =====================================

        [Fact]
        public void RemoveWhere_MatchingPredicate_RemovesFirstMatch()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("CS101");
            list.AddLast("CS102");

            bool removed = list.RemoveWhere(code => code == "CS102");

            Assert.True(removed);
            Assert.Equal(new[] { "CS101" }, list.ToArray());
        }

        // =====================================
        // ToArray
        // =====================================

        [Fact]
        public void ToArray_OnEmptyList_ReturnsEmptyArray()
        {
            var list = new CustomSinglyLinkedList<int>();
            Assert.Empty(list.ToArray());
        }

        // =====================================
        // MergeSort
        // =====================================

        [Fact]
        public void MergeSort_UnsortedList_SortsInAscendingOrder()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(42);
            list.AddLast(12);
            list.AddLast(89);
            list.AddLast(5);

            list.MergeSort((a, b) => a.CompareTo(b));

            Assert.Equal(new[] { 5, 12, 42, 89 }, list.ToArray());
        }

        [Fact]
        public void MergeSort_EmptyOrSingleElementList_HandlesGracefullyWithoutError()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.MergeSort((a, b) => a.CompareTo(b));
            Assert.Empty(list.ToArray());

            list.AddLast(7);
            list.MergeSort((a, b) => a.CompareTo(b));
            Assert.Equal(new[] { 7 }, list.ToArray());
        }

        [Fact]
        public void MergeSort_ThenAddLast_TailStillWorksCorrectly()
        {
            // Regression check: MergeSort relinks nodes internally, so the tail
            // pointer must be correctly re-derived afterwards.
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(3);
            list.AddLast(1);
            list.AddLast(2);

            list.MergeSort((a, b) => a.CompareTo(b));
            list.AddLast(4);

            Assert.Equal(new[] { 1, 2, 3, 4 }, list.ToArray());
        }

        // =====================================
        // LinearSearch
        // =====================================

        [Fact]
        public void LinearSearch_ExistingItem_ReturnsMatchingNode()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("CS101");
            list.AddLast("CS102");

            Node<string>? result = list.LinearSearch(code => code == "CS102");

            Assert.NotNull(result);
            Assert.Equal("CS102", result!.Data);
        }

        [Fact]
        public void LinearSearch_NonExistingItem_ReturnsNull()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("CS101");

            Node<string>? result = list.LinearSearch(code => code == "CS999");

            Assert.Null(result);
        }
    }
}