using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomArrayListTests
    {
        [Fact]
        public void Add_ShouldIncreaseCount()
        {
            CustomArrayList<int> test = new CustomArrayList<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);

            Assert.Equal(3, test.Count);

        }

        [Fact]
        public void Add_ShouldReturnCorrectElement()
        {
            CustomArrayList<int> test = new CustomArrayList<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);

            Assert.Equal(1,test.Get(0));
            Assert.Equal(2,test.Get(1));
            Assert.Equal(3, test.Get(2));
        }
        [Fact]  
        public void RemoveAt_ShouldRemoveElement()
        {
            CustomArrayList<int> test = new CustomArrayList<int>();
            test.Add(10);
            test.Add(20);
            test.Add(30);

            test.RemoveAt(2);
            Assert.Equal(2, test.Count);
            Assert.Equal(10, test.Get(0));
            Assert.Equal(20, test.Get(1));
        }

        [Fact]
        public void RemoveAt_ThrowsAnError()
        {
            CustomArrayList<int> test = new CustomArrayList<int>();

            test.Add(30);

            Assert.Throws<IndexOutOfRangeException>(() => test.Get(5));
        }

        [Fact]
        public void RemoveAt_IsValid()
        {
            CustomArrayList<int> test = new CustomArrayList<int>();
            Assert.Throws<IndexOutOfRangeException>(() => test.Get(0));
        }
 
    }
}