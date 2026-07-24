namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomSinglyLinkedListTests
{
    // Add 

    [Fact]
    public void Add_ShouldAppendNodeAndIncrementCount()
    {
<<<<<<< Updated upstream
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);

        Assert.Equal(1, list.Count);
        Assert.True(list.Search(10));
=======
        // Arrange
        var list = new CustomSinglyLinkedList<int>();

        // Act
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // Assert
        Assert.Equal(3, list.Count);
        Assert.Equal(10, list.GetAt(0));
        Assert.Equal(20, list.GetAt(1));
        Assert.Equal(30, list.GetAt(2));
>>>>>>> Stashed changes
    }

    [Fact]
    public void Add_MultipleItems_ShouldIncrementCountEachTime()
    {
<<<<<<< Updated upstream
        var list = new CustomSinglyLinkedList<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);

        Assert.Equal(3, list.Count);
=======
        // Arrange
        var list = new CustomSinglyLinkedList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(40);

        // Act & Assert - Remove head
        Assert.True(list.Remove(10));
        Assert.Equal(3, list.Count);
        Assert.Equal(20, list.GetAt(0));

        // Act & Assert - Remove middle
        Assert.True(list.Remove(30));
        Assert.Equal(2, list.Count);
        Assert.Equal(20, list.GetAt(0));
        Assert.Equal(40, list.GetAt(1));

        // Act & Assert - Remove tail
        Assert.True(list.Remove(40));
        Assert.Equal(1, list.Count);
        Assert.Equal(20, list.GetAt(0));
>>>>>>> Stashed changes
    }

    [Fact]
    public void Add_ShouldPreserveInsertionOrder()
    {
        var list = new CustomSinglyLinkedList<int>();
        var visited = new List<int>();

        list.Add(5);
        list.Add(1);
        list.Add(9);
        list.ForEach(item => visited.Add(item));

        Assert.Equal(new List<int> { 5, 1, 9 }, visited);
    }

    // Remove 

    [Fact]
    public void Remove_HeadNode_ShouldUpdateHeadAndDecrementCount()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        bool removed = list.Remove(1);

        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.False(list.Search(1));
    }

    [Fact]
    public void Remove_MiddleNode_ShouldRelinkSurroundingNodes()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        bool removed = list.Remove(2);

        var visited = new List<int>();
        list.ForEach(item => visited.Add(item));

        Assert.True(removed);
        Assert.Equal(new List<int> { 1, 3 }, visited);
    }

    [Fact]
    public void Remove_ItemNotInList_ShouldReturnFalseAndNotChangeCount()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);

        bool removed = list.Remove(99);

        Assert.False(removed);
        Assert.Equal(2, list.Count);
    }

    // Search 

    [Fact]
    public void Search_ShouldReturnTrue_WhenItemExistsInNodes()
    {
<<<<<<< Updated upstream
        var list = new CustomSinglyLinkedList<int>();
        list.Add(4);
        list.Add(8);
        list.Add(15);

        Assert.True(list.Search(8));
=======
        // Arrange
        var list = new CustomSinglyLinkedList<int>();

        list.Add(5);
        list.Add(10);
        list.Add(15);

        // Act
        bool result = list.Search(10);

        // Assert
        Assert.True(result);
>>>>>>> Stashed changes
    }

    [Fact]
    public void Search_ShouldReturnFalse_WhenItemIsAbsent()
    {
<<<<<<< Updated upstream
        var list = new CustomSinglyLinkedList<int>();
        list.Add(4);
        list.Add(8);

        Assert.False(list.Search(100));
=======
        // Arrange
        var list = new CustomSinglyLinkedList<int>();

        list.Add(5);
        list.Add(10);
        list.Add(15);

        // Act
        bool result = list.Search(100);

        // Assert
        Assert.False(result);
>>>>>>> Stashed changes
    }

    [Fact]
    public void Search_OnEmptyList_ShouldReturnFalse()
    {
        var list = new CustomSinglyLinkedList<int>();

        Assert.False(list.Search(1));
    }

    // Sort 

    [Fact]
    public void Sort_ShouldRearrangeNodePointersInAscendingOrder()
    {
<<<<<<< Updated upstream
        var list = new CustomSinglyLinkedList<int>();
        list.Add(30);
        list.Add(10);
        list.Add(20);

        list.Sort();

        var visited = new List<int>();
        list.ForEach(item => visited.Add(item));

        Assert.Equal(new List<int> { 10, 20, 30 }, visited);
    }

    [Fact]
    public void Sort_AlreadySortedList_ShouldRemainUnchanged()
    {
        var list = new CustomSinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        list.Sort();

        var visited = new List<int>();
        list.ForEach(item => visited.Add(item));

        Assert.Equal(new List<int> { 1, 2, 3 }, visited);
    }

    [Fact]
    public void Sort_SingleOrEmptyList_ShouldNotThrow()
    {
        var emptyList = new CustomSinglyLinkedList<int>();
        var singleList = new CustomSinglyLinkedList<int>();
        singleList.Add(42);

        emptyList.Sort();
        singleList.Sort();

        Assert.Equal(0, emptyList.Count);
        Assert.Equal(1, singleList.Count);
=======
        // Arrange
        var list = new CustomSinglyLinkedList<int>();

        list.Add(30);
        list.Add(10);
        list.Add(20);
        list.Add(40);

        // Act
        list.Sort();

        // Assert
        Assert.Equal(10, list.GetAt(0));
        Assert.Equal(20, list.GetAt(1));
        Assert.Equal(30, list.GetAt(2));
        Assert.Equal(40, list.GetAt(3));
>>>>>>> Stashed changes
    }
}

