using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
                // ADD ALL YOUR TESTS HERE

        [Fact]
        public void AddLast_AddsFirstElement_SetsHeadCorrectly()
        {
            var list = new CustomSinglyLinkedList<string>();

            list.AddLast("First");

            Assert.Equal(1, list.Count);
            Assert.Equal("First", list.GetAt(0));
        }

        [Fact]
        public void AddLast_AddsMultipleElements_AppendsCorrectly()
        {
            var list = new CustomSinglyLinkedList<string>();

            list.AddLast("First");
            list.AddLast("Second");
            list.AddLast("Third");

            Assert.Equal(3, list.Count);
            Assert.Equal("First", list.GetAt(0));
            Assert.Equal("Second", list.GetAt(1));
            Assert.Equal("Third", list.GetAt(2));
        }

        [Fact]
        public void AddLast_AddsElements_CountIncreases()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(10);
            Assert.Equal(1, list.Count);

            list.AddLast(20);
            Assert.Equal(2, list.Count);

            list.AddLast(30);
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void Remove_RemovesExistingItem_ReturnsTrue()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("Apple");
            list.AddLast("Banana");
            list.AddLast("Cherry");

            bool result = list.Remove("Banana");

            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal("Apple", list.GetAt(0));
            Assert.Equal("Cherry", list.GetAt(1));
        }

        [Fact]
        public void Remove_RemovesHead_UpdatesHead()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(100);
            list.AddLast(200);
            list.AddLast(300);

            bool result = list.Remove(100);

            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(200, list.GetAt(0));
            Assert.Equal(300, list.GetAt(1));
        }

        [Fact]
        public void Remove_ItemNotFound_ReturnsFalse()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("Apple");
            list.AddLast("Banana");

            bool result = list.Remove("Orange");

            Assert.False(result);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void GetAt_ValidIndex_ReturnsCorrectElement()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("First");
            list.AddLast("Second");
            list.AddLast("Third");

            string result = list.GetAt(1);

            Assert.Equal("Second", result);
        }

        [Fact]
        public void GetAt_FirstIndex_ReturnsFirstElement()
        {

            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);


            int result = list.GetAt(0);
            Assert.Equal(10, result);
        }

        [Fact]
        public void GetAt_InvalidIndex_ThrowsException()
        {

            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("Only");


            Assert.Throws<IndexOutOfRangeException>(() => list.GetAt(5));
            Assert.Throws<IndexOutOfRangeException>(() => list.GetAt(-1));
        }

        [Fact]
        public void ShowAll_EmptyList_DoesNotCrash()
        {

            var list = new CustomSinglyLinkedList<string>();

            list.ShowAll();
        }

        [Fact]
        public void ShowAll_WithElements_DisplaysAllElements()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("A");
            list.AddLast("B");
            list.AddLast("C");

            list.ShowAll();

            Assert.Equal(3, list.Count);
            Assert.Equal("A", list.GetAt(0));
            Assert.Equal("B", list.GetAt(1));
            Assert.Equal("C", list.GetAt(2));
        }

        [Fact]
        public void ShowAll_SingleElement_DisplaysCorrectly()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(42);

            list.ShowAll();
            Assert.Equal(1, list.Count);
            Assert.Equal(42, list.GetAt(0));
        }
    }
}