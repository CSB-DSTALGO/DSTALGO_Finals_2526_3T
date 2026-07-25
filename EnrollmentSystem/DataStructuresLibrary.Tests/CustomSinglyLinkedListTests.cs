using System;
using System.Linq;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        

        [Fact]
        public void NewList_IsEmpty()
        {
            var list = new CustomSinglyLinkedList<int>();

            Assert.Equal(0, list.Count);
            Assert.Null(list.Head);
            Assert.Empty(list);
        }

        

        [Fact]
        public void AddLast_SingleItem_SetsHeadAndCount()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(42);

            Assert.Equal(1, list.Count);
            Assert.NotNull(list.Head);
            Assert.Equal(42, list.Head!.Data);
            Assert.Null(list.Head.Next);
        }

        [Fact]
        public void AddLast_MultipleItems_PreservesInsertionOrder()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.Equal(3, list.Count);
            Assert.Equal(new[] { 1, 2, 3 }, list.ToArray());
        }

        [Fact]
        public void AddLast_AllowsDuplicateValues()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(5);
            list.AddLast(5);
            list.AddLast(5);

            Assert.Equal(3, list.Count);
            Assert.Equal(new[] { 5, 5, 5 }, list.ToArray());
        }

        

        [Fact]
        public void Remove_FromEmptyList_ReturnsFalse()
        {
            var list = new CustomSinglyLinkedList<int>();

            bool result = list.Remove(1);

            Assert.False(result);
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Remove_HeadItem_UpdatesHeadAndCount()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            bool result = list.Remove(1);

            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(2, list.Head!.Data);
            Assert.Equal(new[] { 2, 3 }, list.ToArray());
        }

        [Fact]
        public void Remove_MiddleItem_RelinksCorrectly()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            bool result = list.Remove(2);

            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(new[] { 1, 3 }, list.ToArray());
        }

        [Fact]
        public void Remove_LastItem_TerminatesListCorrectly()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            bool result = list.Remove(3);

            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(new[] { 1, 2 }, list.ToArray());
        }

        [Fact]
        public void Remove_OnlyItem_LeavesListEmpty()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);

            bool result = list.Remove(1);

            Assert.True(result);
            Assert.Equal(0, list.Count);
            Assert.Null(list.Head);
        }

        [Fact]
        public void Remove_NonExistentItem_ReturnsFalseAndLeavesListUnchanged()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            bool result = list.Remove(99);

            Assert.False(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(new[] { 1, 2 }, list.ToArray());
        }

        [Fact]
        public void Remove_OnlyRemovesFirstMatchingDuplicate()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(2);
            list.AddLast(3);

            bool result = list.Remove(2);

            Assert.True(result);
            Assert.Equal(3, list.Count);
            Assert.Equal(new[] { 1, 2, 3 }, list.ToArray());
        }

        // ---------- Sort ----------

        [Fact]
        public void Sort_EmptyList_DoesNotThrow()
        {
            var list = new CustomSinglyLinkedList<int>();

            var exception = Record.Exception(() => list.Sort());

            Assert.Null(exception);
            Assert.Equal(0, list.Count);
            Assert.Null(list.Head);
        }

        [Fact]
        public void Sort_SingleElement_RemainsUnchanged()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);

            list.Sort();

            Assert.Equal(new[] { 1 }, list.ToArray());
        }

        [Fact]
        public void Sort_AlreadySortedList_RemainsSorted()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);

            list.Sort();

            Assert.Equal(new[] { 1, 2, 3, 4 }, list.ToArray());
        }

        [Fact]
        public void Sort_ReverseSortedList_SortsAscending()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(4);
            list.AddLast(3);
            list.AddLast(2);
            list.AddLast(1);

            list.Sort();

            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, list.ToArray());
        }

        [Fact]
        public void Sort_UnorderedList_SortsAscending()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(9);
            list.AddLast(1);
            list.AddLast(7);
            list.AddLast(3);
            list.AddLast(5);
            list.AddLast(2);

            list.Sort();

            Assert.Equal(new[] { 1, 2, 3, 5, 7, 9 }, list.ToArray());
        }

        [Fact]
        public void Sort_ListWithDuplicates_SortsAndPreservesCount()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(3);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(1);
            list.AddLast(3);

            list.Sort();

            Assert.Equal(5, list.Count);
            Assert.Equal(new[] { 1, 1, 2, 2, 3 }.OrderBy(x => x), list.ToArray().OrderBy(x => x));
            Assert.Equal(new[] { 1, 1, 2, 3, 3 }, list.ToArray());
        }

        [Fact]
        public void Sort_UpdatesHeadToNewMinimum()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(3);
            list.AddLast(1);
            list.AddLast(2);

            list.Sort();

            Assert.Equal(1, list.Head!.Data);
        }

        [Fact]
        public void Sort_DoesNotChangeCount()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(4);
            list.AddLast(2);
            list.AddLast(8);

            int countBefore = list.Count;
            list.Sort();

            Assert.Equal(countBefore, list.Count);
        }

        [Fact]
        public void Sort_WithStrings_SortsLexicographically()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("banana");
            list.AddLast("apple");
            list.AddLast("cherry");

            list.Sort();

            Assert.Equal(new[] { "apple", "banana", "cherry" }, list.ToArray());
        }

        

        [Fact]
        public void Enumeration_ViaForeach_YieldsItemsInOrder()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            var results = new System.Collections.Generic.List<int>();
            foreach (var item in list)
            {
                results.Add(item);
            }

            Assert.Equal(new[] { 10, 20, 30 }, results);
        }

        [Fact]
        public void Enumeration_NonGeneric_MatchesGeneric()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            System.Collections.IEnumerable nonGeneric = list;
            var results = new System.Collections.Generic.List<int>();
            foreach (int item in nonGeneric)
            {
                results.Add(item);
            }

            Assert.Equal(new[] { 1, 2 }, results);
        }

       

        [Fact]
        public void AddThenRemoveThenSort_WorksTogetherCorrectly()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(1);

            list.Remove(8);
            list.AddLast(0);
            list.Sort();

            Assert.Equal(new[] { 0, 1, 3, 5 }, list.ToArray());
            Assert.Equal(4, list.Count);
        }
    }
}