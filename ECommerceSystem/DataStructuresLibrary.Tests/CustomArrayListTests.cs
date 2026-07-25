namespace DataStructuresLibrary.Tests;

using Xunit;
using DataStructuresLibrary;

public class CustomArrayListTests
{
    [Fact]
    public void Add_ShouldIncreaseCountAndStoreItems()
    {
        //creating an empty array list to implement add and get
        CustomArrayList<int> list = new CustomArrayList<int>();

        //add three arrays using list.add
        list.Add(10);
        list.Add(20);
        list.Add(30);

        //implementing this should now indicate that the list has 3 arrays
        Assert.Equal(3, list.Count);

        //adding assert lets it check if each item is placed in the correct position
        Assert.Equal(10, list[0]);
        Assert.Equal(20, list[1]);
        Assert.Equal(30, list[2]);
    }

    [Fact]
    public void Remove_ShouldShiftElementsCorrectly()
    {
        //creating an arraylist to determine the number of arrays added
        CustomArrayList<int> list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        //with this we will remove the middle or index 1
        list.Remove(20);

        //since we removed one we should now put that the count is now 2
        Assert.Equal(2, list.Count);

        //now that 20 is removed it should look like this
        Assert.Equal(10, list[0]);
        Assert.Equal(30, list[1]);
    }

    [Fact]
    public void Search_ShouldReturnCorrectIndex_WhenItemExists()
    {
        CustomArrayList<int> list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        //since 20 is at index 1 the search will check if it has found it on index 2
        int index = list.Search(20);
        Assert.Equal(1, index);
    }

    [Fact]
    public void Search_ShouldReturnMinusOne_WhenItemDoesNotExist()
    {
        //setting values that does not contain a value that we will search
        CustomArrayList<int> list = new CustomArrayList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        //since 40 does not exist in the index it will return -1
        int index = list.Search(40);
        Assert.Equal(-1, index);
    }

    [Fact]
    public void Sort_ShouldOrderElementsInAscendingSequence()
    {
        //since we need to order the values in ascending sequence
        CustomArrayList<int> list = new CustomArrayList<int>();
        list.Add(30);
        list.Add(10);
        list.Add(20);

        //using sort to declare that the values are now in order
        list.Sort();

        Assert.Equal(10, list[0]);
        Assert.Equal(20, list[1]);
        Assert.Equal(30, list[2]);
    }
}