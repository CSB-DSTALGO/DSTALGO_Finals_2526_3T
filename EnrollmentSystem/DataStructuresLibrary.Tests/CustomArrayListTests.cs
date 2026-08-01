namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        //Test Add and Get indexing
        CustomArrayList<int> list = new CustomArrayList<int>();
        list.Add(23);
        list.Add(42);
        list.Add(66);

        Assert.Equal(3, list.Count);
        Assert.Equal(23, list.Get(0));
        Assert.Equal(42, list.Get(1));
        Assert.Equal(66, list.Get(2));
        
    }

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        //Verify element removal and index shifting
        CustomArrayList<int> list = new CustomArrayList<int>();

        list.Add(15);
        list.Add(25);
        list.Add(30);
        list.Add(35);

        list.RemoveAt(2);

        Assert.Equal(3, list.Count);
        Assert.Equal(15, list.Get(0));
        Assert.Equal(25, list.Get(1));
        Assert.Equal(35, list.Get(2));
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        //Search returns zero-based index for existing element
        CustomArrayList<int> list = new CustomArrayList<int>();

        list.Add(14);
        list.Add(19);
        list.Add(24);

        int index = list.LinearSearch(19);

        Assert.Equal(1, index);
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        //Search returns -1 when element is absent
        CustomArrayList<int> list = new CustomArrayList<int>();

        list.Add(3);
        list.Add(16);
        list.Add(9);

        int index = list.LinearSearch(11);

        Assert.Equal(-1, index);
    }

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        // TODO: Test Sort ordering an unsorted CustomArrayList<int>
        CustomArrayList<int> list = new CustomArrayList<int>();

        list.Add(54);
        list.Add(22);
        list.Add(123);
        list.Add(31);
        list.Add(10);

        list.BubbleSort();

        Assert.Equal(10, list.Get(0));
        Assert.Equal(22, list.Get(1));
        Assert.Equal(31, list.Get(2));
        Assert.Equal(54, list.Get(3));
        Assert.Equal(123, list.Get(4));

    }
}
