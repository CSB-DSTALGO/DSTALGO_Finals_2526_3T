using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        // AddLast tests
        [Fact]
        public void AddLast_ShouldAppendNodeAndIncrementCount()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list.GetAt(0));
            Assert.Equal(2, list.GetAt(1));
        }

        [Fact]
        public void AddLast_SingleItem_ShouldBeHead()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("Hello");
            Assert.Equal(1, list.Count);
            Assert.Equal("Hello", list.Head!.Data);
        }

        [Fact]
        public void AddLast_MultipleItems_ShouldMaintainInsertionOrder()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            Assert.Equal(10, list.GetAt(0));
            Assert.Equal(20, list.GetAt(1));
            Assert.Equal(30, list.GetAt(2));
        }

        // Remove tests
        [Fact]
        public void Remove_ShouldRemoveFirstMatchAndDecrementCount()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            bool result = list.Remove(2);
            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(3, list.GetAt(1));
        }

        [Fact]
        public void Remove_HeadNode_ShouldUpdateHead()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.Remove(1);
            Assert.Equal(1, list.Count);
            Assert.Equal(2, list.Head!.Data);
        }

        [Fact]
        public void Remove_NonExistentItem_ShouldReturnFalse()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            bool result = list.Remove(99);
            Assert.False(result);
            Assert.Equal(1, list.Count);
        }

        // RemoveWhere tests
        [Fact]
        public void RemoveWhere_ShouldRemoveFirstMatchingNode()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            bool result = list.RemoveWhere(x => x > 1);
            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list.GetAt(0));
        }

        [Fact]
        public void RemoveWhere_NoMatch_ShouldReturnFalse()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            bool result = list.RemoveWhere(x => x == 99);
            Assert.False(result);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void RemoveWhere_EmptyList_ShouldReturnFalse()
        {
            var list = new CustomSinglyLinkedList<int>();
            bool result = list.RemoveWhere(x => x == 1);
            Assert.False(result);
        }

        // Search tests
        [Fact]
        public void Search_ShouldReturnFirstMatchingItem()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            var result = list.Search(x => x == 20);
            Assert.Equal(20, result);
        }

        [Fact]
        public void Search_NoMatch_ShouldReturnDefault()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            var result = list.Search(x => x == 99);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Search_EmptyList_ShouldReturnDefault()
        {
            var list = new CustomSinglyLinkedList<string>();
            var result = list.Search(x => x == "test");
            Assert.Null(result);
        }

        // Contains tests
        [Fact]
        public void Contains_ShouldReturnTrue_WhenItemExists()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(5);
            Assert.True(list.Contains(x => x == 5));
        }

        [Fact]
        public void Contains_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(5);
            Assert.False(list.Contains(x => x == 99));
        }

        [Fact]
        public void Contains_EmptyList_ShouldReturnFalse()
        {
            var list = new CustomSinglyLinkedList<int>();
            Assert.False(list.Contains(x => x == 1));
        }

        // Sort tests
        [Fact]
        public void Sort_ShouldOrderElementsAscending()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(30);
            list.AddLast(10);
            list.AddLast(20);
            list.Sort((a, b) => a.CompareTo(b));
            Assert.Equal(10, list.GetAt(0));
            Assert.Equal(20, list.GetAt(1));
            Assert.Equal(30, list.GetAt(2));
        }

        [Fact]
        public void Sort_AlreadySorted_ShouldRemainSorted()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.Sort((a, b) => a.CompareTo(b));
            Assert.Equal(1, list.GetAt(0));
            Assert.Equal(3, list.GetAt(2));
        }

        [Fact]
        public void Sort_EmptyList_ShouldNotThrow()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.Sort((a, b) => a.CompareTo(b));
            Assert.Equal(0, list.Count);
        }

        // GetAt tests
        [Fact]
        public void GetAt_ValidIndex_ShouldReturnCorrectItem()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(100);
            list.AddLast(200);
            Assert.Equal(200, list.GetAt(1));
        }

        [Fact]
        public void GetAt_NegativeIndex_ShouldThrowIndexOutOfRangeException()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            Assert.Throws<IndexOutOfRangeException>(() => list.GetAt(-1));
        }

        [Fact]
        public void GetAt_OutOfBoundsIndex_ShouldThrowIndexOutOfRangeException()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            Assert.Throws<IndexOutOfRangeException>(() => list.GetAt(1));
        }
    }
}