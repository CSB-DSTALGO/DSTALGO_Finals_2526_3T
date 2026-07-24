using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        //ADD ALL YOUR TESTS HERE

        // Tests for the head

        [Fact]
        public void Head_ShouldBeNull_WhenListIsEmpty()
        {
            var list = new CustomSinglyLinkedList<int>();

            Assert.Null(list.Head);
        }

        [Fact]
        public void Head_ShouldHoldTheFirstItem()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);

            Assert.Equal(10, list.Head!.Data);
        }

        [Fact]
        public void Head_ShouldPointToTheSecondNode()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);

            Assert.Equal(20, list.Head!.Next!.Data);
        }

        // Tests for the count

        [Fact]
        public void Count_ShouldBeZero_WhenListIsNew()
        {
            var list = new CustomSinglyLinkedList<int>();

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Count_ShouldIncrease_WhenItemsAreAdded()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void Count_ShouldDecrease_WhenItemIsRemoved()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            list.Remove(1);

            Assert.Equal(1, list.Count);
        }

        // Tests for the addlast

        [Fact]
        public void AddLast_ShouldSetTheHead_WhenListIsEmpty()
        {
            var list = new CustomSinglyLinkedList<string>();

            list.AddLast("CS101");

            Assert.Equal("CS101", list.Head!.Data);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void AddLast_ShouldPutTheNewItemAtTheEnd()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("CS101");
            list.AddLast("CS102");
            list.AddLast("CS103");

            Assert.Equal("CS103", list.Head!.Next!.Next!.Data);
        }

        [Fact]
        public void AddLast_ShouldKeepTheOrderOfTheItems()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.Equal(1, list.Head!.Data);
            Assert.Equal(2, list.Head.Next!.Data);
            Assert.Equal(3, list.Head.Next.Next!.Data);
        }

        // Tests for the remove

        [Fact]
        public void Remove_ShouldReturnFalse_WhenListIsEmpty()
        {
            var list = new CustomSinglyLinkedList<int>();

            bool removed = list.Remove(99);

            Assert.False(removed);
        }

        [Fact]
        public void Remove_ShouldMoveTheHead_WhenFirstItemIsRemoved()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            bool removed = list.Remove(1);

            Assert.True(removed);
            Assert.Equal(2, list.Head!.Data);
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenItemIsNotInTheList()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            bool removed = list.Remove(99);

            Assert.False(removed);
            Assert.Equal(2, list.Count);
        }

        // Tests for the linear search

        [Fact]
        public void LinearSearch_ShouldReturnZero_WhenItemIsFirst()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);

            Assert.Equal(0, list.LinearSearch(10));
        }

        [Fact]
        public void LinearSearch_ShouldReturnTheCorrectIndex()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            Assert.Equal(1, list.LinearSearch(20));
        }

        [Fact]
        public void LinearSearch_ShouldReturnMinusOne_WhenItemIsNotFound()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);

            Assert.Equal(-1, list.LinearSearch(99));
        }

        // Tests for the sort

        [Fact]
        public void Sort_ShouldDoNothing_WhenListIsEmpty()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.Sort();

            Assert.Null(list.Head);
        }

        [Fact]
        public void Sort_ShouldArrangeTheItemsFromSmallestToLargest()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(30);
            list.AddLast(10);
            list.AddLast(20);

            list.Sort();

            Assert.Equal(10, list.Head!.Data);
            Assert.Equal(20, list.Head.Next!.Data);
            Assert.Equal(30, list.Head.Next.Next!.Data);
        }

        [Fact]
        public void Sort_ShouldStillWork_WhenListIsAlreadySorted()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            list.Sort();

            Assert.Equal(1, list.Head!.Data);
            Assert.Equal(3, list.Count);
        }
    }
}