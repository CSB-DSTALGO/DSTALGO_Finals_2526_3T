using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomStackTests
    {
        //ADD ALL YOUR TESTS HERE
        [Fact]
        public void PushandPeekTest()
        {
            var stack = new CustomStack<int>();
            stack.Push(10);
            Assert.Equal(1, stack.Count);
            Assert.Equal(10, stack.Peek());
            stack.Push(20);
            Assert.Equal(2, stack.Count);
            Assert.Equal(20, stack.Peek());
            stack.Push(30);
            Assert.Equal(3, stack.Count);
            Assert.Equal(30, stack.Peek());
        }
        [Fact]
        public void PopTest()
        {
            var stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.Equal(3, stack.Count);
            Assert.Equal(30, stack.Pop());
            Assert.Equal(2, stack.Count);
            Assert.Equal(20, stack.Pop());
            Assert.Equal(1, stack.Count);
            Assert.Equal(10, stack.Pop());
        }
        [Fact]
        public void IsEmptyTest()
        {
            var stack = new CustomStack<int>();
            Assert.True(stack.IsEmpty());
            stack.Push(10);
            Assert.False(stack.IsEmpty());
            stack.Pop();
            Assert.True(stack.IsEmpty());
        }
        [Fact]
        public void SearchTest()
        {
            var stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.Equal(2, stack.Search(20));
            Assert.Equal(3, stack.Search(10));
            Assert.Equal(-1, stack.Search(40));
        }
        [Fact]
        public void SortTest()
        {
            var stack = new CustomStack<int>();
            stack.Push(30);
            stack.Push(10);
            stack.Push(20);

            stack.Sort();

            Assert.Equal(30, stack.Pop());
            Assert.Equal(20, stack.Pop());
            Assert.Equal(10, stack.Pop());

            stack.Push(50);
            stack.Push(60);
            stack.Push(40);

            stack.Sort();

            Assert.Equal(60, stack.Pop());
            Assert.Equal(50, stack.Pop());
            Assert.Equal(40, stack.Pop());

            stack.Push(8);
            stack.Push(9);
            stack.Push(7);

            stack.Sort();

            Assert.Equal(9, stack.Pop());
            Assert.Equal(8, stack.Pop());
            Assert.Equal(7, stack.Pop());
        }
    }   
} 