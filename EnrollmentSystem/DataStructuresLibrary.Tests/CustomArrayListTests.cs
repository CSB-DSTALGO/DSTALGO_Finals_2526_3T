// 12521269 Joaquin Bryan G. Ross
using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {
        // =====================================================================
        // Add
        // =====================================================================

        [Fact]
        public void Add_ShouldIncreaseCountAndStoreItems()
        {
            var list = new CustomArrayList<int>();

            list.Add(10);
            list.Add(20);

            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.Get(0));
            Assert.Equal(20, list.Get(1));
        }

        [Fact]
        public void Add_ShouldPreserveItems_WhenGrowingBeyondInitialCapacity()
        {
            // The backing array starts at 4 slots, so this forces several resizes.
            var list = new CustomArrayList<int>();

            for (int i = 0; i < 20; i++)
            {
                list.Add(i);
            }

            Assert.Equal(20, list.Count);
            for (int i = 0; i < 20; i++)
            {
                Assert.Equal(i, list.Get(i));
            }
        }

        [Fact]
        public void Add_ShouldKeepDuplicatesAsSeparateEntries()
        {
            var list = new CustomArrayList<int>();

            list.Add(7);
            list.Add(7);

            Assert.Equal(2, list.Count);
        }

        // =====================================================================
        // Get
        // =====================================================================

        [Fact]
        public void Get_ShouldReturnItemAtRequestedIndex()
        {
            var list = new CustomArrayList<int>();
            list.Add(5);
            list.Add(15);
            list.Add(25);

            Assert.Equal(25, list.Get(2));
        }

        [Fact]
        public void Get_ShouldThrow_WhenIndexIsNegative()
        {
            var list = new CustomArrayList<int>();
            list.Add(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
        }

        [Fact]
        public void Get_ShouldThrow_WhenIndexIsBeyondCount()
        {
            var list = new CustomArrayList<int>();
            list.Add(1);

            // Index 1 sits inside the backing array but outside the used region.
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(1));
        }

        // =====================================================================
        // RemoveAt
        // =====================================================================

        [Fact]
        public void RemoveAt_ShouldShiftLaterElementsDown()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            list.RemoveAt(1);

            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.Get(0));
            Assert.Equal(30, list.Get(1)); // slid down from index 2
        }

        [Fact]
        public void RemoveAt_ShouldThrow_WhenIndexIsNegative()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
        }

        [Fact]
        public void RemoveAt_ShouldThrow_WhenIndexEqualsCount()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(1));
        }

        // =====================================================================
        // Search
        // =====================================================================

        [Fact]
        public void Search_ShouldReturnZeroBasedIndex_WhenItemExists()
        {
            var list = new CustomArrayList<int>();
            list.Add(100);
            list.Add(200);
            list.Add(300);

            Assert.Equal(1, list.Search(200));
        }

        [Fact]
        public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
        {
            var list = new CustomArrayList<int>();
            list.Add(100);

            Assert.Equal(-1, list.Search(999));
        }

        [Fact]
        public void Search_ShouldReturnMinusOne_WhenListIsEmpty()
        {
            var list = new CustomArrayList<int>();

            Assert.Equal(-1, list.Search(1));
        }

        // =====================================================================
        // Sort
        // =====================================================================

        [Fact]
        public void Sort_ShouldOrderElementsAscending()
        {
            var list = new CustomArrayList<int>();
            list.Add(30);
            list.Add(10);
            list.Add(20);

            list.Sort();

            Assert.Equal(10, list.Get(0));
            Assert.Equal(20, list.Get(1));
            Assert.Equal(30, list.Get(2));
        }

        [Fact]
        public void Sort_ShouldLeaveAnAlreadySortedListUnchanged()
        {
            var list = new CustomArrayList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Sort();

            Assert.Equal(1, list.Get(0));
            Assert.Equal(2, list.Get(1));
            Assert.Equal(3, list.Get(2));
        }

        [Fact]
        public void Sort_ShouldHandleEmptyAndSingleItemLists()
        {
            var empty = new CustomArrayList<int>();
            var single = new CustomArrayList<int>();
            single.Add(42);

            empty.Sort();
            single.Sort();

            Assert.Equal(0, empty.Count);
            Assert.Equal(42, single.Get(0));
        }
    }
}
