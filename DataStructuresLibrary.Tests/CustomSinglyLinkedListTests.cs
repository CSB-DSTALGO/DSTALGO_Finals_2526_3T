using System;
using Xunit;
using DataStructuresLibrary;

namespace DataStructuresLibrary.Tests
{
    public class CustomSinglyLinkedListTests
    {
                //ADD ALL YOUR TESTS HERE
        [Fact]
        public void InsertLinkedList()
        {
            var list= new CustomSinglyLinkedList<string>();
            list.AddLast("BSIT");
            Assert.NotNull(list.head);
            Assert.Equal("BSIT", list.Head.Data);
        }
        [Fact]
        public void RemoveLinkedList()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("CS101");
            list.AddLast("CS102");
            bool result = list.Remove("CS101");
            Assert.True(result);
            Assert.Equal("CS102", list.Head?.Data);
        }
        [Fact]
        public void SearchLinkedList()
        {
            var list = new CustomSinglyLinkedList<string>();
            list.AddLast("BSIT");
            list.AddLast("CS101");
            Node<string>? current = list.Head;
            string? foundData = null;
            while (current != null)
            {
                if (current.Data == "BSIT")
                {
                    foundData = current.Data;
                    break;
                }
                current = current.Next;
            }
            Assert.NotNull(foundData);
            Assert.Equal ("BSIT",foundData);
        }

    }
}