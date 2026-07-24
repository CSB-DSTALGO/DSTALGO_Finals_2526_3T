namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
     [Fact]
        public void Add_IncreasesCount()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void GetAt_ReturnsCorrectItem()
        {
            var list = new CustomArrayList<string>();
            list.Add("Alice");
            list.Add("Bob");

            Assert.Equal("Alice", list.GetAt(0));
            Assert.Equal("Bob", list.GetAt(1));
        }

        [Fact]
        public void RemoveAt_ShiftsRemainingItemsLeft()
        {
            var list = new CustomArrayList<string>();
            list.Add("Alice");
            list.Add("Bob");
            list.Add("Carol");

            list.RemoveAt(0); // remove "Alice"

            Assert.Equal(2, list.Count);
            Assert.Equal("Bob", list.GetAt(0));
            Assert.Equal("Carol", list.GetAt(1));
        }

        [Fact]
        public void GetAt_InvalidIndex_ThrowsIndexOutOfRangeException()
        {
            var list = new CustomArrayList<int>();
            list.Add(1);

            Assert.Throws<IndexOutOfRangeException>(() => list.GetAt(5));
        }

        [Fact]
        public void RemoveAt_InvalidIndex_ThrowsIndexOutOfRangeException()
        {
            var list = new CustomArrayList<int>();
            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(0));
        }

        [Fact]
        public void Add_BeyondInitialCapacity_ResizesWithoutLosingData()
        {
            var list = new CustomArrayList<int>(initialCapacity: 2);
            list.Add(1);
            list.Add(2);
            list.Add(3); // forces a resize internally

            Assert.Equal(3, list.Count);
            Assert.Equal(1, list.GetAt(0));
            Assert.Equal(2, list.GetAt(1));
            Assert.Equal(3, list.GetAt(2));
        }

        [Fact]
        public void ToArray_ReturnsExactCountLength_NoTrailingEmptySlots()
        {
            var list = new CustomArrayList<int>(initialCapacity: 10);
            list.Add(1);
            list.Add(2);

            int[] result = list.ToArray();

            Assert.Equal(2, result.Length);
        
    }
}
