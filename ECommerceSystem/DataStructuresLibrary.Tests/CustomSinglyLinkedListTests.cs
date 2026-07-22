using DataStructuresLibrary;
using Xunit;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        [Fact]
        public void Add_ShouldAppendNodeAndIncrementCount()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.Add(10);
            list.Add(20);

            Assert.Equal(2, list.Count);
            Assert.True(list.Search(10));
            Assert.True(list.Search(20));
        }

        [Fact]
        public void Remove_ShouldUpdateNodePointersCorrectly()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // Remove head
            Assert.True(list.Remove(1));
            Assert.False(list.Search(1));
            Assert.Equal(2, list.Count);

            // Remove middle
            Assert.True(list.Remove(2));
            Assert.False(list.Search(2));
            Assert.Equal(1, list.Count);

            // Remove tail
            Assert.True(list.Remove(3));
            Assert.False(list.Search(3));
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.Add("apple");
            list.Add("banana");

            Assert.True(list.Search("apple"));
            Assert.True(list.Search("banana"));
        }

        [Fact]
        public void Search_ShouldReturnFalse_WhenItemIsAbsent()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.Add("apple");

            Assert.False(list.Search("orange"));
        }

        [Fact]
        public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.Add(30);
            list.Add(10);
            list.Add(20);

            list.Sort();

            Assert.Equal(10, list.GetProductDetails(0));
            Assert.Equal(20, list.GetProductDetails(1));
            Assert.Equal(30, list.GetProductDetails(2));
        }
    }
}
