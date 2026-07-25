using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {
        [Fact]
        public void NewArrayList_ShouldHaveCountZero()
        {
            var list = new CustomArrayList<int>();

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Add_OneItem_IncreasesCount()
        {
            var list = new CustomArrayList<int>();

            list.Add(10);

            Assert.Equal(1, list.Count);
        }

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

        [Fact]
        public void Get_InvalidIndex_ShouldThrowException()
        {
            var list = new CustomArrayList<int>();

            Assert.Throws<IndexOutOfRangeException>(() => list.Get(0));
        }

        [Fact]
        public void RemoveAt_RemovesCorrectItem()
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

        [Fact]
        public void RemoveAt_InvalidIndex_ShouldThrowException()
        {
            var list = new CustomArrayList<int>();

            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(0));
        }

        [Fact]
        public void Add_MoreThanInitialCapacity_ShouldResize()
        {
            var list = new CustomArrayList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.Equal(5, list.Count);
            Assert.Equal(1, list.Get(0));
            Assert.Equal(2, list.Get(1));
            Assert.Equal(3, list.Get(2));
            Assert.Equal(4, list.Get(3));
            Assert.Equal(5, list.Get(4));
        }
    }
}
