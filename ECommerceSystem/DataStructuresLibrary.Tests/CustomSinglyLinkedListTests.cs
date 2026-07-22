using DataStructuresLibrary;
using Xunit;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        [Fact]
        public void AddLast_ShouldAppendNodeAndIncrementCount()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);

            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.GetProductDetails(0));
            Assert.Equal(20, list.GetProductDetails(1));
        }

        [Fact]
        public void Remove_ShouldUpdateNodePointersCorrectly()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            // Remove head
            Assert.True(list.Remove(1));
            Assert.False(list.Find(1) != null);
            Assert.Equal(2, list.Count);

            // Remove middle
            Assert.True(list.Remove(2));
            Assert.False(list.Find(2) != null);
            Assert.Equal(1, list.Count);

            // Remove tail
            Assert.True(list.Remove(3));
            Assert.False(list.Find(3) != null);
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Find_ShouldReturnItem_WhenItemExists()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("apple");
            list.AddLast("banana");

            Assert.Equal("apple", list.Find("apple"));
            Assert.Equal("banana", list.Find("banana"));
        }

        [Fact]
        public void Find_ShouldReturnNull_WhenItemIsAbsent()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("apple");

            Assert.Null(list.Find("orange"));
        }

        [Fact]
        public void Sort_ShouldRearrangeNodesInAscendingOrder()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(30);
            list.AddLast(10);
            list.AddLast(20);

            list.Sort();

            Assert.Equal(10, list.GetProductDetails(0));
            Assert.Equal(20, list.GetProductDetails(1));
            Assert.Equal(30, list.GetProductDetails(2));
        }

        [Fact]
        public void ShowAllProfiles_ShouldTraverseAllNodesWithoutError()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            list.AddLast(15);

            // Just ensure traversal works — no exception thrown
            var exception = Record.Exception(() => list.ShowAllProfiles());
            Assert.Null(exception);
        }
    }
}
