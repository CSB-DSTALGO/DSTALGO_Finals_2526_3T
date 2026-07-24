using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
                //ADD ALL YOUR TESTS HERE
        [Fact]
        public void AddLast_SingleItem_SetNodeHead()
        {
            var list = new CustomSinglyLinkedList<int>();

            list.AddLast(10);

            Assert.NotNull(list.Head);
            Assert.Equal(10, list.Head.Data);
            Assert.Null(list.Head.Next);
        }
        [Fact]
        public void AddLast_MultipleItems_AppendsToTailInOrder()
        {
            var list = new CustomSinglyLinkedList<string>();

            list.AddLast("First");
            list.AddLast("Second");
            list.AddLast("Third");

            Assert.NotNull(list.Head);
            Assert.Equal("First", list.Head.Data);
            Assert.Equal("Second", list.Head.Next?.Data);
            Assert.Equal("Third", list.Head.Next?.Next?.Data);
            Assert.Null(list.Head.Next?.Next?.Next);
        }
        [Fact]
        public void Remove_HeadItem_UpdatesHeadToNextNode()
        {
            var list = new CustomSinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);

            bool result = list.Remove(10);

            Assert.True(result);
            Assert.NotNull(list.Head);
            Assert.Equal(20, list.Head.Data);
        }
        [Fact]
        public void Remove_MiddleItem_UnlinksNodeSuccessfully()
        {
            var list = new CustomSinglyLinkedList<char>();
            list.AddLast('A');
            list.AddLast('B');
        }
    }
}