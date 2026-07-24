using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
        [Fact]
        public void AddLast_OnEmptyList_BecomesHead()
        {
            CustomSinglyLinkedList<int> singlyLinkedList = new CustomSinglyLinkedList<int>();

            singlyLinkedList.AddLast(1);

            Assert.NotNull(singlyLinkedList.Head);
            Assert.Equal(1, singlyLinkedList.Head.Data);
        }

        [Fact]
        public void AddLast_MultipleItems_StaysInCorrectOrder()
        {
            CustomSinglyLinkedList<int> singlyLinkedList = new CustomSinglyLinkedList<int>();

            singlyLinkedList.AddLast(1);
            singlyLinkedList.AddLast(2);
            singlyLinkedList.AddLast(3);

            Assert.Equal(1, singlyLinkedList.Head.Data);
            Assert.Equal(2, singlyLinkedList.Head.Next.Data);
            Assert.Equal(3, singlyLinkedList.Head.Next.Next.Data);
        }

        [Fact]
        public void AddLast_IncreaseCountCorrectly()
        {
            CustomSinglyLinkedList<int> singlyLinkedList = new CustomSinglyLinkedList<int>();

            singlyLinkedList.AddLast(1);
            singlyLinkedList.AddLast(2);
            singlyLinkedList.AddLast(3);

            Assert.Equal(3, singlyLinkedList.Count);
        }

        [Fact]
        public void Remove_HeadNode_NextNodeBecomesNewHead()
        {
            CustomSinglyLinkedList<int> singlyLinkedList = new CustomSinglyLinkedList<int>();

            singlyLinkedList.AddLast(1);
            singlyLinkedList.AddLast(2);
            singlyLinkedList.AddLast(3);

            bool result = singlyLinkedList.Remove(1);

            Assert.True(result);
            Assert.Equal(2, singlyLinkedList.Head.Data);
        }

        [Fact]
        public void Remove_MiddleNode_ListStaysLinked()
        {
            CustomSinglyLinkedList<int> singlyLinkedList = new CustomSinglyLinkedList<int>();

            singlyLinkedList.AddLast(1);
            singlyLinkedList.AddLast(2);
            singlyLinkedList.AddLast(3);

            bool result = singlyLinkedList.Remove(2);

            Assert.True(result);
            Assert.Equal(1, singlyLinkedList.Head.Data);
            Assert.Equal(3, singlyLinkedList.Head.Next.Data);
            Assert.Null(singlyLinkedList.Head.Next.Next);
        }

        [Fact]
        public void Remove_ItemDoesNotExist_ReturnFalse_NoChanges()
        {
            CustomSinglyLinkedList<int> singlyLinkedList = new CustomSinglyLinkedList<int>();

            singlyLinkedList.AddLast(1);
            singlyLinkedList.AddLast(2);

            bool result = singlyLinkedList.Remove(3);

            Assert.False(result);
            Assert.Equal(2, singlyLinkedList.Count);
        }

        [Fact]
        public void Remove_FromEmptyList_ReturnsFalse()
        {
            CustomSinglyLinkedList<int> singlyLinkedList = new CustomSinglyLinkedList<int>();

            bool result = singlyLinkedList.Remove(1);

            Assert.False(result);
        }

        [Fact]
        public void Remove_DecreaseCountCorrectly()
        {
            CustomSinglyLinkedList<int> singlyLinkedList = new CustomSinglyLinkedList<int>();

            singlyLinkedList.AddLast(1);
            singlyLinkedList.AddLast(2);
            singlyLinkedList.Remove(1);

            Assert.Equal(1, singlyLinkedList.Count);
        }

        [Fact]
        public void Count_OnNewList_IsZero()
        {
            CustomSinglyLinkedList<int> singlyLinkedList = new CustomSinglyLinkedList<int>();

            Assert.Equal(0, singlyLinkedList.Count);
        }

        [Fact]
        public void Count_AfterRemoveFromEmptyList_CannotBeNegative()
        {
            CustomSinglyLinkedList<int> singlyLinkedList = new CustomSinglyLinkedList<int>();

            singlyLinkedList.Remove(1);

            Assert.True(singlyLinkedList.Count >= 0);
            Assert.Equal(0, singlyLinkedList.Count);
        }
    }
}