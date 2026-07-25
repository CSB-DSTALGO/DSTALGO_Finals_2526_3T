using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void NewList_ShouldBeEmpty()
        {

            var list = new CustomSinglyLinkedList<string>();
            Assert.Null(list.Head);
        }

        [Fact]
        public void SetHead()
        {
          
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("DATA STRUCTURES");
            Assert.NotNull(list.Head);
            Assert.Equal("DATA STRUCTURES", list.Head.Data);
        }

        [Fact]
        public void AddLast()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("DATA STRUCTURES");
            list.AddLast("CS101");
            list.AddLast("MATH101");
            Assert.Equal("DATA STRUCTURES", list.Head.Data);
            Assert.Equal("CS101", list.Head.Next.Data);
            Assert.Equal("MATH101", list.Head.Next.Next.Data);
        }

        [Fact]
        public void Remove()
        {
            var list = new CustomSinglyLinkedList<int>();
            bool result = list.Remove(10);
            Assert.False(result);
        }

        [Fact]
        public void UpdateHead()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            bool result = list.Remove(10);
            Assert.True(result);
            Assert.Equal(20, list.Head.Data);
        }

        [Fact]
        public void NextNode()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("DATA STRUCTURES");
            list.AddLast("CS101");
            list.AddLast("MATH101");
            bool result = list.Remove("CS101");
            Assert.True(result);
            Assert.Equal("DATA STRUCTURES", list.Head.Data);
            Assert.Equal("MATH101", list.Head.Next.Data);
        }

        [Fact]
        public void NonExistentItem()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("DATA STRUCTURES");
            list.AddLast("CS101");
            bool result = list.Remove("MATH101");
            Assert.False(result);
        }
    }
}