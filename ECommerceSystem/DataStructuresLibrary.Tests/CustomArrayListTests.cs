namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        // TODO: Implement test for Add and Get indexing
        CustomArrayList<int> test = new CustomArrayList<int>();

        test.Add(10);
        test.Add(20);
        test.Add(30);

        Assert.Equal(3, test.Count);
        Assert.Equal(10, test.Get(0));
        Assert.Equal(20, test.Get(1));
        Assert.Equal(30, test.Get(2));

        //throw new NotImplementedException();
    }

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        // TODO: Implement test verifying element removal and index shifting
        CustomArrayList<int> test = new CustomArrayList<int>();

        test.Add(10);
        test.Add(20);
        test.Add(30);

        bool removed = test.Remove(20);

        Assert.True(removed);
        Assert.Equal(2, test.Count);
        Assert.Equal(10, test.Get(0));
        Assert.Equal(30, test.Get(1));


        //throw new NotImplementedException();
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        // TODO: Test Search returning zero-based index for existing element
        CustomArrayList<int> test = new CustomArrayList<int>();

        test.Add(10);
        test.Add(20);
        test.Add(30);

        int index = test.Search(20);
        Assert.Equal(1, index);


        //throw new NotImplementedException();
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        // TODO: Test Search returning -1 when element is absent
        CustomArrayList<int> test = new CustomArrayList<int>();

        test.Add(10);
        test.Add(20);
        test.Add(30);

        int index = test.Search(50);

        Assert.Equal(-1, index);


        //throw new NotImplementedException();
    }

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        // TODO: Test Sort ordering an unsorted CustomArrayList<int>
        CustomArrayList<int> test = new CustomArrayList<int>();

        test.Add(8);
        test.Add(7);
        test.Add(3);

        test.Sort();
        Assert.Equal(3, test.Get(0));
        Assert.Equal(7, test.Get(1));
        Assert.Equal(8, test.Get(2));

        //throw new NotImplementedException();
    }
}