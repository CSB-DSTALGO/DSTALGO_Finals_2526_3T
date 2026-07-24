using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {
        [Fact]
        public void Add_SingleItem_IncreasesCountAndStoresValue()
        {
            var list = new CustomArrayList<int>();

            list.Add(42);

            Assert.Equal(1, list.Count);
            Assert.Equal(42, list.Get(0));
        }

        [Fact]
        public void Add_BeyondInitialCapacity_TriggersResizeWithoutDataLoss()
        {
            var list = new CustomArrayList<string>();

            list.Add("First");
            list.Add("Second");
            list.Add("Third"); // Triggers Resize()

            Assert.Equal(3, list.Count);
            Assert.Equal("Third", list.Get(2));
        }

        [Fact]
        public void Get_IndexOutOfBounds_ThrowsIndexOutOfRangeException()
        {
            var list = new CustomArrayList<double>();
            list.Add(3.14);

            // Adding { } forces C# to treat this as a void Action
            Assert.Throws<IndexOutOfRangeException>(() => { list.Get(1); });
            Assert.Throws<IndexOutOfRangeException>(() => { list.Get(-1); });
        }

        [Fact]
        public void RemoveAt_ValidIndex_RemovesItemAndShiftsRemainingElements()
        {
            var list = new CustomArrayList<char>();
            list.Add('A');
            list.Add('B');
            list.Add('C');

            list.RemoveAt(1); // Removing 'B'

            Assert.Equal(2, list.Count);
            Assert.Equal('A', list.Get(0));
            Assert.Equal('C', list.Get(1)); // 'C' shifts left to index 1
        }

        [Fact]
        public void RemoveAt_IndexOutOfBounds_ThrowsIndexOutOfRangeException()
        {
            var list = new CustomArrayList<int>();

            Assert.Throws<IndexOutOfRangeException>(() => { list.RemoveAt(0); });
        }
    }
}