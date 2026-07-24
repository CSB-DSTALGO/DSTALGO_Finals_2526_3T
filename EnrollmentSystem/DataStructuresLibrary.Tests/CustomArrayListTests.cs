using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {
        [Fact]
        public void Add_IncreasesCount()
        {
            var list = new CustomArrayList<string>();
            list.Add("A");
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void Add_BeyondInitialCapacity_TriggersResize()
        {
            var list = new CustomArrayList<int>();
            for (int i = 0; i < 10; i++)
                list.Add(i);

            Assert.Equal(10, list.Count);
            Assert.Equal(0, list.Get(0));
            Assert.Equal(9, list.Get(9));
        }

        [Fact]
        public void Get_ValidIndex_ReturnsCorrectItem()
        {
            var list = new CustomArrayList<string>();
            list.Add("Hello");
            Assert.Equal("Hello", list.Get(0));
        }

        [Fact]
        public void Get_InvalidIndex_ThrowsException()
        {
            var list = new CustomArrayList<string>();
            Assert.Throws<IndexOutOfRangeException>(() => { list.Get(0); });
        }

        [Fact]
        public void RemoveAt_ShiftsElementsLeft()
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
        public void RemoveAt_InvalidIndex_ThrowsException()
        {
            var list = new CustomArrayList<string>();
            Assert.Throws<IndexOutOfRangeException>(() => { list.Get(0); });
        }

        [Fact]
        public void Set_UpdatesItemAtIndex()
        {
            var list = new CustomArrayList<string>();
            list.Add("Old");
            list.Set(0, "New");
            Assert.Equal("New", list.Get(0));
        }
    }
}