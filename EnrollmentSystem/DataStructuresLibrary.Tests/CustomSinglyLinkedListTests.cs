using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        
        //Tests for AddLast
        

        [Fact]
        public void AddLast_ToEmptyList_SetsHeadAndCountToOne()
        {
            var list = new CustomSinglyLinkedList<string>();

            list.AddLast("DSTALGO");

            Assert.Equal(1, list.Count);
            Assert.NotNull(list.Head);
            Assert.Equal("DSTALGO", list.Head.Data);
        }

        [Fact]
        public void AddLast_MultipleItems_AppendsInCorrectOrder()
        {
            var list = new CustomSinglyLinkedList<string>();

            list.AddLast("DSTALGO");
            list.AddLast("ISINFOM");
            list.AddLast("ISPROJ2");

            Assert.Equal(3, list.Count);
            Assert.Equal("DSTALGO", list.Head!.Data);
            Assert.Equal("ISINFOM", list.Head.Next!.Data);
            Assert.Equal("ISPROJ2", list.Head.Next.Next!.Data);
        }

        [Fact]
        public void AddLast_DuplicateItems_IncreasesCountAndPreservesOrder()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(5);
            list.AddLast(5);

            Assert.Equal(2, list.Count);
            Assert.Equal(5, list.Head!.Data);
            Assert.Equal(5, list.Head.Next!.Data);
        }

        
        //Tests for Remove (3 Tests)
        

        [Fact]
        public void Remove_HeadItem_UpdatesHeadAndDecrementsCount()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);

            bool removed = list.Remove(x => x == 10);

            Assert.True(removed);
            Assert.Equal(1, list.Count);
            Assert.Equal(20, list.Head!.Data);
        }

        [Fact]
        public void Remove_MiddleOrLastItem_RemovesCorrectNode()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            bool removed = list.Remove(x => x == 20);

            Assert.True(removed);
            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.Head!.Data);
            Assert.Equal(30, list.Head.Next!.Data);
        }

        [Fact]
        public void Remove_NonExistentItem_ReturnsFalseAndKeepCount()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);

            bool removed = list.Remove(x => x == 99);

            Assert.False(removed);
            Assert.Equal(1, list.Count);
            Assert.Equal(10, list.Head!.Data);
        }

        
        //Tests for Find
        

        [Fact]
        public void Find_ExistingItem_ReturnsMatchingNode()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("ENTPROG");
            list.AddLast("APPDAET");

            var node = list.Find(x => x == "APPDAET");

            Assert.NotNull(node);
            Assert.Equal("APPDAET", node!.Data);
        }

        [Fact]
        public void Find_NonExistentItem_ReturnsNull()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("ISPROJ1");

            var node = list.Find(x => x == "CSBGRAD");

            Assert.Null(node);
        }

        [Fact]
        public void Find_EmptyList_ReturnsNull()
        {
            var list = new CustomSinglyLinkedList<string>();

            var node = list.Find(x => x == "ANY");

            Assert.Null(node);
        }
       
        //Tests for Sort     

        [Fact]
        public void Sort_UnsortedIntegers_SortsInAscendingOrder()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(30);
            list.AddLast(10);
            list.AddLast(20);

            list.Sort((a, b) => a.CompareTo(b));

            Assert.Equal(10, list.Head!.Data);
            Assert.Equal(20, list.Head.Next!.Data);
            Assert.Equal(30, list.Head.Next.Next!.Data);
        }

        [Fact]
        public void Sort_UnsortedStrings_SortsAlphabetically()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("MARFRET");
            list.AddLast("APPDAET");
            list.AddLast("CSBGRAD");

            list.Sort((a, b) => string.Compare(a, b, StringComparison.Ordinal));

            Assert.Equal("APPDAET", list.Head!.Data);
            Assert.Equal("CSBGRAD", list.Head.Next!.Data);
            Assert.Equal("MARFRET", list.Head.Next.Next!.Data);
        }

        [Fact]
        public void Sort_EmptyOrSingleElementList_DoesNotThrowOrChange()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(42);

            list.Sort((a, b) => a.CompareTo(b));

            Assert.Equal(1, list.Count);
            Assert.Equal(42, list.Head!.Data);
        }

        
    }
}