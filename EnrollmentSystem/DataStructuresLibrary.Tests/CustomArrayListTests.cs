using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {
        // ---------------- Constructor / Count ----------------

        [Fact]
        public void Constructor_ShouldCreateEmptyList()
        {
            var list = new CustomArrayList<int>();

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Count_ShouldStartAtZero_ForNewList()
        {
            var list = new CustomArrayList<string>();

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Count_ShouldIncrease_AsItemsAreAdded()
        {
            var list = new CustomArrayList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.Equal(3, list.Count);
        }

        // ---------------- Add ----------------

        [Fact]
        public void Add_ShouldIncreaseCountByOne()
        {
            var list = new CustomArrayList<int>();

            list.Add(42);

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void Add_ShouldPreserveInsertionOrder()
        {
            var list = new CustomArrayList<string>();

            list.Add("A");
            list.Add("B");
            list.Add("C");

            Assert.Equal("A", list.Get(0));
            Assert.Equal("B", list.Get(1));
            Assert.Equal("C", list.Get(2));
        }

        [Fact]
        public void Add_ShouldTriggerResize_WhenCapacityIsExceeded()
        {
            var list = new CustomArrayList<int>();
            int startingCapacity = list.Capacity;

            // Add more items than the default starting capacity to force a resize.
            for (int i = 0; i < startingCapacity + 5; i++)
            {
                list.Add(i);
            }

            Assert.True(list.Capacity > startingCapacity);
            Assert.Equal(startingCapacity + 5, list.Count);
        }

        // ---------------- Get ----------------

        [Fact]
        public void Get_ShouldReturnCorrectItem_AtGivenIndex()
        {
            var list = new CustomArrayList<int>();
            list.Add(100);
            list.Add(200);

            Assert.Equal(200, list.Get(1));
        }

        [Fact]
        public void Get_ShouldThrowArgumentOutOfRangeException_ForNegativeIndex()
        {
            var list = new CustomArrayList<int>();
            list.Add(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
        }

        [Fact]
        public void Get_ShouldThrowArgumentOutOfRangeException_WhenIndexEqualsCount()
        {
            var list = new CustomArrayList<int>();
            list.Add(1);
            list.Add(2);

            // Valid indices are 0 and 1; index 2 is one past the last element.
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(2));
        }

        // ---------------- RemoveAt ----------------

        [Fact]
        public void RemoveAt_ShouldDecreaseCountByOne()
        {
            var list = new CustomArrayList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveAt(1);

            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void RemoveAt_ShouldShiftSubsequentElementsLeft()
        {
            var list = new CustomArrayList<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");

            list.RemoveAt(0);

            Assert.Equal("B", list.Get(0));
            Assert.Equal("C", list.Get(1));
        }

        [Fact]
        public void RemoveAt_ShouldThrowArgumentOutOfRangeException_ForInvalidIndex()
        {
            var list = new CustomArrayList<int>();
            list.Add(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(5));
        }
    }
}
