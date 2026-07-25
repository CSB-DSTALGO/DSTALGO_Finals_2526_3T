using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void ThisIsYourTest()
        {
            var list = new CustomArrayList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            Assert.Equal(3, list.Count);
            Assert.Equal(10, list.Get(0));
            Assert.Equal(20, list.Get(1));
            Assert.Equal(30, list.Get(2));

            list.RemoveAt(1); // Remove the item at index 1 (value 20)

            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.Get(0));
            Assert.Equal(30, list.Get(1));
        }
    }
}








