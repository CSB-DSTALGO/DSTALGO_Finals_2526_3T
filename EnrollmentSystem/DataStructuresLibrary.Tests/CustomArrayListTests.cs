using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {
        // Test 1: Add items and check stored correctly
        [Fact]
        public void Add_MultipleItems_StoresCorrectly()
        {
            var list = new CustomArrayList<string>();
            list.Add("Alice");
            list.Add("Bob");
            list.Add("Charlie");

            Assert.Equal(3, list.Count);
            Assert.Equal("Alice", list.Get(0));
            Assert.Equal("Bob", list.Get(1));
            Assert.Equal("Charlie", list.Get(2));
        }

        // Test 2: Bad index should throw error
        [Fact]
        public void Get_InvalidIndex_ThrowsException()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);

            Assert.Throws<IndexOutOfRangeException>(() => list.Get(5));
        }

        // Test 3: Remove middle, others shift left
        [Fact]
        public void RemoveAt_ValidIndex_RemovesAndShifts()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            list.RemoveAt(1);

            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.Get(0));
            Assert.Equal(30, list.Get(1));
        }

        // Test 4: Quick Sort numbers smallest to biggest
        [Fact]
        public void QuickSort_SortsIntegersAscending()
        {
            var list = new CustomArrayList<int>();
            list.Add(64);
            list.Add(25);
            list.Add(12);
            list.Add(22);
            list.Add(11);

            list.QuickSort((a, b) => a.CompareTo(b));

            Assert.Equal(11, list.Get(0));
            Assert.Equal(12, list.Get(1));
            Assert.Equal(22, list.Get(2));
            Assert.Equal(25, list.Get(3));
            Assert.Equal(64, list.Get(4));
        }

        // Test 5: Quick Sort strings A to Z
        [Fact]
        public void QuickSort_SortsStringsAlphabetically()
        {
            var list = new CustomArrayList<string>();
            list.Add("Charlie");
            list.Add("Alice");
            list.Add("Bob");

            list.QuickSort((a, b) => string.Compare(a, b, StringComparison.Ordinal));

            Assert.Equal("Alice", list.Get(0));
            Assert.Equal("Bob", list.Get(1));
            Assert.Equal("Charlie", list.Get(2));
        }

        // Test 6: Binary Search finds item
        [Fact]
        public void BinarySearch_FindsExistingItem()
        {
            var list = new CustomArrayList<int>();
            list.Add(11);
            list.Add(12);
            list.Add(22);
            list.Add(25);
            list.Add(64);

            int index = list.BinarySearch(22, (a, b) => a.CompareTo(b));

            Assert.Equal(2, index);
        }

        // Test 7: Binary Search not found returns -1
        [Fact]
        public void BinarySearch_ItemNotFound_ReturnsNegativeOne()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            int index = list.BinarySearch(99, (a, b) => a.CompareTo(b));

            Assert.Equal(-1, index);
        }

        // Test 8: Sort then search full workflow
        [Fact]
        public void BinarySearch_AfterQuickSort_FindsItemCorrectly()
        {
            var list = new CustomArrayList<int>();
            list.Add(64);
            list.Add(25);
            list.Add(12);
            list.Add(22);
            list.Add(11);

            list.QuickSort((a, b) => a.CompareTo(b));
            int index = list.BinarySearch(25, (a, b) => a.CompareTo(b));

            Assert.Equal(3, index);
        }
    }
}