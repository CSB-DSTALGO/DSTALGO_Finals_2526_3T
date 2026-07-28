using System;
using Xunit;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        [Fact]
        public void Add_ShouldIncreaseCountAndContainElement()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<int>();

            // Act
            list.Add(10);
            list.Add(20);

            // Assert
            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.GetAt(0));
            Assert.Equal(20, list.GetAt(1));
        }

        [Fact]
        public void InsertAt_ShouldInsertElementAtSpecifiedIndex()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<string>();
            list.Add("A");
            list.Add("C");

            // Act
            list.InsertAt(1, "B");

            // Assert
            Assert.Equal(3, list.Count);
            Assert.Equal("A", list.GetAt(0));
            Assert.Equal("B", list.GetAt(1));
            Assert.Equal("C", list.GetAt(2));
        }

        [Fact]
        public void InsertAt_InvalidIndex_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<int>();
            list.Add(1);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list.InsertAt(-1, 99));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.InsertAt(5, 99));
        }

        [Fact]
        public void Remove_ShouldRemoveSpecifiedElement()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            // Act
            bool removed = list.Remove(20);

            // Assert
            Assert.True(removed);
            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.GetAt(0));
            Assert.Equal(30, list.GetAt(1));
        }

        [Fact]
        public void Remove_ElementNotFound_ShouldReturnFalse()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<int>();
            list.Add(10);

            // Act
            bool removed = list.Remove(99);

            // Assert
            Assert.False(removed);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void RemoveAt_ShouldRemoveElementAtIndex()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<string>();
            list.Add("X");
            list.Add("Y");
            list.Add("Z");

            // Act
            list.RemoveAt(1);

            // Assert
            Assert.Equal(2, list.Count);
            Assert.Equal("X", list.GetAt(0));
            Assert.Equal("Z", list.GetAt(1));
        }

        [Fact]
        public void GetAt_ShouldReturnCorrectElement()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<int>();
            list.Add(100);
            list.Add(200);
            list.Add(300);

            // Act & Assert
            Assert.Equal(100, list.GetAt(0));
            Assert.Equal(200, list.GetAt(1));
            Assert.Equal(300, list.GetAt(2));
        }

        [Fact]
        public void IndexOf_ShouldReturnCorrectIndex()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<string>();
            list.Add("Apple");
            list.Add("Banana");
            list.Add("Cherry");

            // Act & Assert
            Assert.Equal(0, list.IndexOf("Apple"));
            Assert.Equal(1, list.IndexOf("Banana"));
            Assert.Equal(-1, list.IndexOf("Grape"));
        }

        [Fact]
        public void Clear_ShouldRemoveAllElements()
        {
            // Arrange
            var list = new CustomSinglyLinkedList<double>();
            list.Add(1.1);
            list.Add(2.2);

            // Act
            list.Clear();

            // Assert
            Assert.Equal(0, list.Count);
            Assert.True(list.IsEmpty);
        }
    }
}