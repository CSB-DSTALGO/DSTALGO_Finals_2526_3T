namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        var list = new CustomArrayList<int>();
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(3, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
<<<<<<< Updated upstream
    }

    [Fact]
    public void Add_ShouldExpandCapacity_WhenArrayIsFull()
    {
        var list = new CustomArrayList<int>(2);

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(3, list.Count);
        Assert.Equal(30, list.Get(2));
    }

    [Fact]
    public void Add_ShouldStoreItemsInCorrectOrder()
    {
        var list = new CustomArrayList<int>();

        list.Add(5);
        list.Add(15);

        Assert.Equal(5, list.Get(0));
        Assert.Equal(15, list.Get(1));
=======
>>>>>>> Stashed changes
    }

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        var list = new CustomArrayList<int>();
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        list.Add(10);
        list.Add(20);
        list.Add(30);

<<<<<<< Updated upstream
        bool result = list.Remove(20);

        Assert.True(result);
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        bool result = list.Remove(99);

        Assert.False(result);
        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void Remove_ShouldRemoveFirstMatchingItem()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        bool result = list.Remove(10);

        Assert.True(result);
        Assert.Equal(2, list.Count);
        Assert.Equal(20, list.Get(0));
    }

    [Fact]
    public void Get_ShouldReturnItemAtCorrectIndex()
    {
        var list = new CustomArrayList<int>();

        list.Add(100);
        list.Add(200);

        Assert.Equal(100, list.Get(0));
        Assert.Equal(200, list.Get(1));
    }

    [Fact]
    public void Get_ShouldThrowException_WhenIndexIsInvalid()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);

        Assert.Throws<IndexOutOfRangeException>(() => list.Get(5));
    }

    [Fact]
    public void Get_ShouldThrowException_WhenIndexIsNegative()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);

        Assert.Throws<IndexOutOfRangeException>(() => list.Get(-1));
=======
        bool removed = list.Remove(20);

        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.Get(0));
        Assert.Equal(30, list.Get(1));
>>>>>>> Stashed changes
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        var list = new CustomArrayList<int>();
<<<<<<< Updated upstream

        list.Add(10);
        list.Add(20);
        list.Add(30);

        int index = list.Search(20);
=======
        list.Add(5);
        list.Add(15);
        list.Add(25);

        int index = list.Search(15);
>>>>>>> Stashed changes

        Assert.Equal(1, index);
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        var list = new CustomArrayList<int>();
<<<<<<< Updated upstream

        list.Add(10);
        list.Add(20);

        int index = list.Search(99);

        Assert.Equal(-1, index);
    }

    [Fact]
    public void Search_ShouldReturnZero_WhenItemIsFirst()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);

        int index = list.Search(10);

        Assert.Equal(0, index);
=======
        list.Add(5);
        list.Add(15);
        list.Add(25);

        int index = list.Search(100);

        Assert.Equal(-1, index);
>>>>>>> Stashed changes
    }

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        var list = new CustomArrayList<int>();
<<<<<<< Updated upstream

        list.Add(30);
        list.Add(10);
=======
        list.Add(40);
        list.Add(10);
        list.Add(30);
>>>>>>> Stashed changes
        list.Add(20);

        list.Sort();

        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
<<<<<<< Updated upstream
    }

    [Fact]
    public void Sort_ShouldWorkWithAlreadySortedItems()
    {
        var list = new CustomArrayList<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.Sort();

        Assert.Equal(10, list.Get(0));
        Assert.Equal(20, list.Get(1));
        Assert.Equal(30, list.Get(2));
    }

    [Fact]
    public void Sort_ShouldPlaceLargestItemAtTheEnd()
    {
        var list = new CustomArrayList<int>();

        list.Add(5);
        list.Add(50);
        list.Add(1);

        list.Sort();

        Assert.Equal(50, list.Get(2));
=======
        Assert.Equal(40, list.Get(3));
>>>>>>> Stashed changes
    }
}
