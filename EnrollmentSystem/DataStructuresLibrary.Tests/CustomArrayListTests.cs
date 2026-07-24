namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
    
        //Test: Can we add multiple items and get them back correctly?
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

        //Test: Does it throw error when we ask for invalid index?
        [Fact]
        public void Get_InvalidIndex_ThrowsException()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);

            Assert.Throws<IndexOutOfRangeException>(() => list.Get(5));
        }

        //Test: Remove middle item, make sure others shift left properly
        [Fact]
        public void RemoveAt_ValidIndex_RemovesAndShifts()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            list.RemoveAt(1);  // Remove 20

            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.Get(0));
            Assert.Equal(30, list.Get(1));  // 30 should have shifted to index 1
        }

        //Test: Quick Sort on numbers - should go from random to ascending
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

            //After sort: 11, 12, 22, 25, 64
            Assert.Equal(11, list.Get(0));
            Assert.Equal(12, list.Get(1));
            Assert.Equal(22, list.Get(2));
            Assert.Equal(25, list.Get(3));
            Assert.Equal(64, list.Get(4));
        }

        //Test: Quick Sort on strings - alphabetical order
        [Fact]
        public void QuickSort_SortsStringsAlphabetically()
        {
            var list = new CustomArrayList<string>();
            list.Add("Charlie");
            list.Add("Alice");
            list.Add("Bob");

            list.QuickSort((a, b) => string.Compare(a, b, StringComparison.Ordinal));

            //After sort: Alice, Bob, Charlie
            Assert.Equal("Alice", list.Get(0));
            Assert.Equal("Bob", list.Get(1));
            Assert.Equal("Charlie", list.Get(2));
        }

        //Test: Binary Search finds existing item in sorted list
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

            Assert.Equal(2, index);  // 22 is at index 2
        }

        //Test: Binary Search returns -1 when item doesn't exist
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

        //Test: Sort first, then search - the full workflow
        [Fact]
        public void BinarySearch_AfterQuickSort_FindsItemCorrectly()
        {
            var list = new CustomArrayList<int>();
            //Add in random order
            list.Add(64);
            list.Add(25);
            list.Add(12);
            list.Add(22);
            list.Add(11);

            list.QuickSort((a, b) => a.CompareTo(b));  //Sort first!
            int index = list.BinarySearch(25, (a, b) => a.CompareTo(b));

            //After sort: 11, 12, 22, 25, 64 -> 25 is at index 3
            Assert.Equal(3, index);
        }

        // TODO: Implement test for Add and Get indexing
        CustomArrayList<int> list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        Assert.Equal(2, list.Count);
        list.Add(21);
        Assert.Equal(3, list.Count);
        list.Add(22);
        list.Add(23);
        Assert.Equal(5, list.Count);
        

    }

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        // TODO: Implement test verifying element removal and index shifting
        throw new NotImplementedException();
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        // TODO: Test Search returning zero-based index for existing element
        throw new NotImplementedException();
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        // TODO: Test Search returning -1 when element is absent
        throw new NotImplementedException();
    }

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        // TODO: Test Sort ordering an unsorted CustomArrayList<int>
        throw new NotImplementedException();
    }
}
