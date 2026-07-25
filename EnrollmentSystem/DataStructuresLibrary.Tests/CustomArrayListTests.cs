using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {
        public void Constructor_ShouldInitializeEmptyList_WithZeroCount()
        {
            var list = new CustomArrayList<int>();
            Assert.Equal(0, list.Count);
        }

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

        [Fact]
        public void Add_ShouldTriggerResize_WhenCapacityExceeded()
        {
            var list = new CustomArrayList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.Equal(5, list.Count);
            Assert.Equal(1, list.Get(0));
            Assert.Equal(5, list.Get(4));
        }

        [Fact]
        public void Get_ShouldThrowExceptionForInvalidIndex()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(1));
        }

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

        [Fact]
        public void RemoveAt_ShouldThrowExceptionForInvalidIndex()
        {
            var list = new CustomArrayList<int>();
            list.Add(100);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(5));
        }
    }
}