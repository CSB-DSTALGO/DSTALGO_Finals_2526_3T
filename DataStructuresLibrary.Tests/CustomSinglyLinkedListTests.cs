using System;
using Xunit;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        [Fact]
        public void Add_ShouldIncreaseCountAndContainElement()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.Add(10);
            list.Add(20);

            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.GetAt(0));
            Assert.Equal(20, list.GetAt(1));
        }

        [Fact]
        public void InsertAt_ShouldInsertElementAtSpecifiedIndex()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.Add("A");
            list.Add("C");

            list.InsertAt(1, "B");

            Assert.Equal(3, list.Count);
            Assert.Equal("A", list.GetAt(0));
            Assert.Equal("B", list.GetAt(1));
            Assert.Equal("C", list.GetAt(2));
        }

        [Fact]
        public void InsertAt_InvalidIndex_ShouldThrowArgumentOutOfRangeException()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.Add(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.InsertAt(-1, 99));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.InsertAt(5, 99));
        }

        [Fact]
        public void Remove_ShouldRemoveSpecifiedElement()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            bool removed = list.Remove(20);

            Assert.True(removed);
            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.GetAt(0));
            Assert.Equal(30, list.GetAt(1));
        }

        [Fact]
        public void Remove_ElementNotFound_ShouldReturnFalse()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.Add(10);

            bool removed = list.Remove(99);

            Assert.False(removed);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void RemoveAt_ShouldRemoveElementAtIndex()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.Add("X");
            list.Add("Y");
            list.Add("Z");

            list.RemoveAt(1);

            Assert.Equal(2, list.Count);
            Assert.Equal("X", list.GetAt(0));
            Assert.Equal("Z", list.GetAt(1));
        }

        [Fact]
        public void GetAt_ShouldReturnCorrectElement()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.Add(100);
            list.Add(200);
            list.Add(300);

            Assert.Equal(100, list.GetAt(0));
            Assert.Equal(200, list.GetAt(1));
            Assert.Equal(300, list.GetAt(2));
        }

        [Fact]
        public void IndexOf_ShouldReturnCorrectIndex()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.Add("Apple");
            list.Add("Banana");
            list.Add("Cherry");

            Assert.Equal(0, list.IndexOf("Apple"));
            Assert.Equal(1, list.IndexOf("Banana"));
            Assert.Equal(-1, list.IndexOf("Grape"));
        }

        [Fact]
        public void Clear_ShouldRemoveAllElements()
        {
            var list = new CustomSinglyLinkedList<double>();
            list.Add(1.1);
            list.Add(2.2);

            list.Clear();

            Assert.Equal(0, list.Count);
            Assert.True(list.IsEmpty);
        }
    }
}