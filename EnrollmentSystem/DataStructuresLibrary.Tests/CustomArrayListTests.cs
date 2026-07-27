using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {
        // Tests that every new arraylist should start empty with a count of zero
        [Fact]
        public void Constructor_ShouldInitializeEmptyList_WithZeroCount()
        {
            var list = new CustomArrayList<int>();
            Assert.Equal(0, list.Count);
        }

        // Tests that adding items increases the count and allows correct retrieval by index
        [Fact]
        public void Add_ShouldIncreaseCountAndAllowRetrieval()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);
            list.Add(20);

            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.Get(0));
            Assert.Equal(20, list.Get(1));
        }

        // Tests that adding more than the initial capacity triggers a resize
        [Fact]
        public void Add_ShouldTriggerResize_WhenCapacityExceeded()
        {
            var list = new CustomArrayList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5); // Exceeds default capacity of 4 here

            Assert.Equal(5, list.Count);
            Assert.Equal(1, list.Get(0));
            Assert.Equal(5, list.Get(4));
        }

        // Tests that adding a single item increments the count to one
        [Fact]
        public void Add_OneItem_IncreasesCount()
        {
            var list = new CustomArrayList<int>();

            list.Add(10);

            Assert.Equal(1, list.Count);
        }

        // Tests that adding multiple sequential items preserves their order and values
        [Fact]
        public void Add_MultipleItems_StoresCorrectValues()
        {
            var list = new CustomArrayList<int>();

            list.Add(10);
            list.Add(20);
            list.Add(30);

            Assert.Equal(3, list.Count);
            Assert.Equal(10, list.Get(0));
            Assert.Equal(20, list.Get(1));
            Assert.Equal(30, list.Get(2));
        }

        // Tests that getting an item from an empty or out-of-bounds index throws an exception
        [Fact]
        public void Get_InvalidIndex_ShouldThrowException()
        {
            var list = new CustomArrayList<int>();

            Assert.Throws<IndexOutOfRangeException>(() => list.Get(0));
        }

        // Tests that removing the first element shifts all subsequent elements to the left
        [Fact]
        public void RemoveAt_FirstItem_ShiftsElementsLeft()
        {
            var list = new CustomArrayList<string>();

            list.Add("A");
            list.Add("B");
            list.Add("C");

            list.RemoveAt(0);

            Assert.Equal(2, list.Count);
            Assert.Equal("B", list.Get(0));
            Assert.Equal("C", list.Get(1));
        }

        // Tests that removing the last item decreases the count properly without shifting
        [Fact]
        public void RemoveAt_LastItem_DecreasesCount()
        {
            var list = new CustomArrayList<int>();

            list.Add(1);
            list.Add(2);

            list.RemoveAt(1);

            Assert.Equal(1, list.Count);
            Assert.Equal(1, list.Get(0));
        }

        // Tests that removing an item shifts the rest, with string datatypes
        [Fact]
        public void RemoveAt_ShouldShiftElementsAndDecreaseCount()
        {
            var list = new CustomArrayList<string>();
            list.Add("Alpha");
            list.Add("Beta");
            list.Add("Gamma");

            list.RemoveAt(1);

            Assert.Equal(2, list.Count);
            Assert.Equal("Alpha", list.Get(0));
            Assert.Equal("Gamma", list.Get(1));
        }

        // Tests that removing from an invalid index throws an exception
        [Fact]
        public void RemoveAt_InvalidIndex_ShouldThrowException()
        {
            var list = new CustomArrayList<int>();

            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(0));
        }

        // Tests that adding at an invalid index throws an exception
        [Fact]
        public void Get_ShouldThrowExceptionForInvalidIndex()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);

            Assert.Throws<IndexOutOfRangeException>(() => list.Get(-1));
            Assert.Throws<IndexOutOfRangeException>(() => list.Get(1));
        }


        // Tests that removing an invalid index correctly throw exceptions.
        [Fact]
        public void RemoveAt_ShouldThrowExceptionForInvalidIndex()
        {
            var list = new CustomArrayList<int>();
            list.Add(100);

            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(-1));
            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(5));
        }
    }
}
