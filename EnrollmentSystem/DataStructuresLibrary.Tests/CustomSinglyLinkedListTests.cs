using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        [Fact]
        public void AddLast_ShouldIncreaseCountAndStoreNodes()
        {
            CustomSinglyLinkedList<int> list = new();

            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            Assert.Equal(3, list.Count);
            Assert.Equal(10, list.Head.Data);
            Assert.Equal(20, list.Head.Next.Data);
            Assert.Equal(30, list.Head.Next.Next.Data);
            Assert.Null(list.Head.Next.Next.Next);
        }

        [Fact]
        public void Remove_ShouldRemoveMiddleNode()
        {
            CustomSinglyLinkedList<int> list = new();

            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            bool removed = list.Remove(20);

            Assert.True(removed);
            Assert.Equal(2, list.Count);
            Assert.Equal(10, list.Head.Data);
            Assert.Equal(30, list.Head.Next.Data);
            Assert.Null(list.Head.Next.Next);
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            CustomSinglyLinkedList<int> list = new();

            list.AddLast(10);
            list.AddLast(20);

            bool removed = list.Remove(50);

            Assert.False(removed);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void Remove_ShouldRemoveHeadNode()
        {
            CustomSinglyLinkedList<int> list = new();

            list.AddLast(10);
            list.AddLast(20);

            bool removed = list.Remove(10);

            Assert.True(removed);
            Assert.Equal(1, list.Count);
            Assert.Equal(20, list.Head.Data);
            Assert.Null(list.Head.Next);
        }

        [Fact]
        public void NewList_ShouldHaveNullHeadAndZeroCount()
        {
            CustomSinglyLinkedList<int> list = new();

            Assert.Null(list.Head);
            Assert.Equal(0, list.Count);
        }
    }
}