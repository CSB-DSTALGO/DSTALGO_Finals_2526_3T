using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {

        [Fact]
        public void Add_1()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            list.Add("Bob");

            Assert.Equal(1, list.Count);
        }


        [Fact]
        public void Add_5()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            list.Add("Bob");
            list.Add("May");
            list.Add("Eisen");
            list.Add("Alexie");
            list.Add("Jino");

            Assert.Equal(5, list.Count);
        }


        [Fact]
        public void Get_1st()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            list.Add("Bob");

            string result = list.Get(0);

            Assert.Equal("Bob", result);
        }


        [Fact]
        public void Get_Last()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            list.Add("Bob");
            list.Add("May");

            string result = list.Get(1);

            Assert.Equal("May", result);
        }


        [Fact]
        public void Get_InvalidIndex()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(0));
        }


        [Fact]
        public void RemoveAt_ValidIndex()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            list.Add("Bob");
            list.Add("May");

            list.RemoveAt(0);

            Assert.Equal(1, list.Count);
        }


        [Fact]
        public void RemoveAt()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            list.Add("Bob");
            list.Add("May");

            list.RemoveAt(0);

            Assert.Equal("May", list.Get(0));
        }


        [Fact]
        public void RemoveAt_InvalidIndex()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(0));
        }


        [Fact]
        public void Count_NewList()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            Assert.Equal(0, list.Count);
        }


        [Fact]
        public void Count_AfterAddingItems()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            list.Add("Bob");
            list.Add("May");

            Assert.Equal(2, list.Count);
        }


        [Fact]
        public void Count_AfterRemovingItem()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            list.Add("Bob");
            list.Add("May");

            list.RemoveAt(0);

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void Search_ItemExists()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            list.Add("Bob");
            list.Add("May");
            list.Add("Alexie");

            int index = list.Search("May", (a, b) => a == b);

            Assert.Equal(1, index);
        }

        [Fact]
        public void Search_ItemNotFound()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            list.Add("Bob");
            list.Add("May");

            int index = list.Search("Kim", (a, b) => a == b);

            Assert.Equal(-1, index);
        }

        [Fact]
        public void Search_EmptyList()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();

            int index = list.Search("Bob", (a, b) => a == b);

            Assert.Equal(-1, index);
        }

        [Fact]
        public void Sort_UnsortedList()
        {
            CustomArrayList<int> list = new CustomArrayList<int>();

            list.Add(3);
            list.Add(1);
            list.Add(2);

            list.Sort((a, b) => a > b);

            Assert.Equal(1, list.Get(0));
            Assert.Equal(2, list.Get(1));
            Assert.Equal(3, list.Get(2));
        }

        [Fact]
        public void Sort_AlreadySorted()
        {
            CustomArrayList<int> list = new CustomArrayList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Sort((a, b) => a > b);

            Assert.Equal(1, list.Get(0));
            Assert.Equal(2, list.Get(1));
            Assert.Equal(3, list.Get(2));
        }

        [Fact]
        public void Sort_SingleItem()
        {
            CustomArrayList<int> list = new CustomArrayList<int>();

            list.Add(5);

            list.Sort((a, b) => a > b);

            Assert.Equal(5, list.Get(0));
        }
    }
}