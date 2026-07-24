using System;
using Xunit;
using DataStructuresLibrary;
using System.Reflection.Metadata.Ecma335;
using DataStructuresLibrary.Tests;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void Add_Item()
        {
            CustomArrayList<int> list = new CustomArrayList<int>();
            list.Add(10);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void GetExistingIndex()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();
            list.Add("Zeke");
            string result = list.Get(0);
            Assert.Equal("Zeke", result);
        }

        [Fact]
        public void RemoveAt()
        {
            CustomArrayList<int> list = new CustomArrayList<int>();
            list.Add(1);
            list.Add(2);
            list.RemoveAt(0);

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void Shift()
        {
            CustomArrayList<string> list = new CustomArrayList<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.RemoveAt(0);
            Assert.Equal("B", list.Get(0));
        }
        
    }
}