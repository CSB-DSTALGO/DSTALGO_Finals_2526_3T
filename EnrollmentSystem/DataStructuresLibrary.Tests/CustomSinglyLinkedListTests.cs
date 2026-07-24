using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {

        [Fact]
        public void AddLast_ShouldAddToEmptyList()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);

            Assert.Equal(1, list.Count);
            Assert.Equal(10, list.Head!.Data);
        }

        [Fact]
        public void AddLast_ShouldAppendMultipleItems()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("CS101");
            list.AddLast("CS102");
            list.AddLast("CS103");

            Assert.Equal(3, list.Count);
            Assert.Equal("CS101", list.Head!.Data);
            Assert.Equal("CS102", list.Head.Next!.Data);
            Assert.Equal("CS103", list.Head.Next.Next!.Data);
        }


        [Fact]
        public void Remove_ShouldRemoveHead()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);

            bool removed = list.Remove(10);

            Assert.True(removed);
            Assert.Equal(1, list.Count);
            Assert.Equal(20, list.Head!.Data);
        }

        [Fact]
        public void Remove_ShouldRemoveMiddleNode()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            bool removed = list.Remove(20);

            Assert.True(removed);
            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.Head!.Data);
            Assert.Equal(30, list.Head.Next!.Data);
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenNotFound()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);

            bool removed = list.Remove(99);

            Assert.False(removed);
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenEmpty()
        {
            var list = new CustomSinglyLinkedList<int>();
            bool removed = list.Remove(10);
            Assert.False(removed);
        }


        [Fact]
        public void RemoveByPredicate_ShouldRemoveMatchingItem()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("CS101");
            list.AddLast("CS102");

            bool removed = list.RemoveByPredicate(s => s == "CS102");

            Assert.True(removed);
            Assert.Equal(1, list.Count);
        }


        [Fact]
        public void Find_ShouldReturnMatchingItem()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);

            var result = list.Find(x => x == 20);

            Assert.Equal(20, result);
        }

        [Fact]
        public void Find_ShouldReturnDefault_WhenNotFound()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);

            var result = list.Find(x => x == 99);

            Assert.Equal(0, result);
        }


        [Fact]
        public void Traverse_ShouldVisitAllItems()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            int sum = 0;

            list.Traverse(x => sum += x);

            Assert.Equal(6, sum);
        }


        [Fact]
        public void Count_ShouldBeZero_OnNewList()
        {
            var list = new CustomSinglyLinkedList<string>();
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Count_ShouldTrackCorrectly()
        {
            var list = new CustomSinglyLinkedList<int>();
            Assert.Equal(0, list.Count);

            list.AddLast(1);
            Assert.Equal(1, list.Count);

            list.AddLast(2);
            Assert.Equal(2, list.Count);

            list.Remove(1);
            Assert.Equal(1, list.Count);
        }
    }

}