using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        // Make sure that AddLast correctly inserts into an empty list.
        [Fact]
        public void AddLast_ShouldAddToEmptyList()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);

            Assert.Equal(1, list.Count);
            Assert.Equal(10, list.Head!.Data);
        }

        // Verifies that AddLast appends multiple items in the correct order.
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

        // Verifies that Remove correctly removes the head node.
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

        // Verifies that Remove correctly removes a middle node.
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

        // Verifies that Remove returns false when the item is not found.
        [Fact]
        public void Remove_ShouldReturnFalse_WhenNotFound()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);

            bool removed = list.Remove(99);

            Assert.False(removed);
        }

        // Verifies that Remove returns false when the list is empty.
        [Fact]
        public void Remove_ShouldReturnFalse_WhenEmpty()
        {
            var list = new CustomSinglyLinkedList<int>();
            bool removed = list.Remove(10);
            Assert.False(removed);
        }

        // Verifies that RemoveByPredicate removes an item matching a condition.
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

        // Verifies that Find returns the correct item when it exists.
        [Fact]
        public void Find_ShouldReturnMatchingItem()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);

            var result = list.Find(x => x == 20);

            Assert.Equal(20, result);
        }

        // Verifies that Find returns the default value when the item is not found.
        [Fact]
        public void Find_ShouldReturnDefault_WhenNotFound()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);

            var result = list.Find(x => x == 99);

            Assert.Equal(0, result);
        }

        // Verifies that Traverse visits every item in the list.
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

        // Verifies that Sort arranges items in ascending order.
        [Fact]
        public void Sort_ShouldArrangeItemsInOrder()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(3);
            list.AddLast(1);
            list.AddLast(2);

            list.Sort((a, b) => a.CompareTo(b));

            Assert.Equal(1, list.Head!.Data);
            Assert.Equal(2, list.Head.Next!.Data);
            Assert.Equal(3, list.Head.Next.Next!.Data);
        }

        // Verifies that Count is zero for a newly created list.
        [Fact]
        public void Count_ShouldBeZero_OnNewList()
        {
            var list = new CustomSinglyLinkedList<string>();
            Assert.Equal(0, list.Count);
        }

        // Verifies that Count updates correctly after insertions and deletions.
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
