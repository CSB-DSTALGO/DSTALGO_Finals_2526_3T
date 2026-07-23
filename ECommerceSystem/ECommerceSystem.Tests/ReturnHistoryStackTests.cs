namespace ECommerceSystem.Tests;

using ECommerceSystem.Core;
using Xunit;

public class ReturnHistoryStackTests
{
    // =====================================================
    // PUSH RETURN TESTS
    // =====================================================

    [Fact]
    public void PushReturn_ShouldIncreaseCount()
    {
        var history = new ReturnHistoryStack();

        history.PushReturn(CreateRequest(1));

        Assert.Equal(1, history.Count);
    }

    [Fact]
    public void PushReturn_ShouldPlaceRequestOnTop()
    {
        var history = new ReturnHistoryStack();
        ReturnRequest request = CreateRequest(1);

        history.PushReturn(request);

        Assert.Same(request, history.PeekLatestReturn());
    }

    [Fact]
    public void PushReturn_ShouldFollowLifoOrder()
    {
        var history = BuildHistory(1, 2, 3);

        Assert.Equal(3, history.PopReturn().ReturnId);
        Assert.Equal(2, history.PopReturn().ReturnId);
        Assert.Equal(1, history.PopReturn().ReturnId);
    }

    // =====================================================
    // POP RETURN TESTS
    // =====================================================

    [Fact]
    public void PopReturn_ShouldRemoveLatestRequest()
    {
        var history = BuildHistory(1, 2);

        ReturnRequest result = history.PopReturn();

        Assert.Equal(2, result.ReturnId);
    }

    [Fact]
    public void PopReturn_ShouldDecreaseCount()
    {
        var history = BuildHistory(1, 2);

        history.PopReturn();

        Assert.Equal(1, history.Count);
    }

    [Fact]
    public void PopReturn_ShouldThrowWhenEmpty()
    {
        var history = new ReturnHistoryStack();

        Assert.Throws<InvalidOperationException>(
            () => history.PopReturn());
    }

    // =====================================================
    // PEEK LAST RETURN TESTS
    // =====================================================

    [Fact]
    public void PeekLastReturn_ShouldReturnLatestRequest()
    {
        var history = BuildHistory(1, 2);

        Assert.Equal(2, history.PeekLastReturn().ReturnId);
    }

    [Fact]
    public void PeekLastReturn_ShouldNotRemoveRequest()
    {
        var history = BuildHistory(1, 2);

        history.PeekLastReturn();

        Assert.Equal(2, history.Count);
    }

    [Fact]
    public void PeekLastReturn_ShouldThrowWhenEmpty()
    {
        var history = new ReturnHistoryStack();

        Assert.Throws<InvalidOperationException>(
            () => history.PeekLastReturn());
    }

    // =====================================================
    // CHECK EMPTY TESTS
    // =====================================================

    [Fact]
    public void CheckHistoryEmpty_ShouldReturnTrueForNewHistory()
    {
        var history = new ReturnHistoryStack();

        Assert.True(history.CheckHistoryEmpty());
    }

    [Fact]
    public void CheckHistoryEmpty_ShouldReturnFalseAfterPush()
    {
        var history = BuildHistory(1);

        Assert.False(history.CheckHistoryEmpty());
    }

    [Fact]
    public void CheckHistoryEmpty_ShouldReturnTrueAfterLastPop()
    {
        var history = BuildHistory(1);

        history.PopReturn();

        Assert.True(history.CheckHistoryEmpty());
    }

    // =====================================================
    // SEARCH TESTS
    // =====================================================

    [Fact]
    public void SearchReturn_ShouldReturnOneForTopRequest()
    {
        var history = BuildHistory(1, 2, 3);

        Assert.Equal(
            1,
            history.SearchReturn(CreateRequest(3)));
    }

    [Fact]
    public void SearchReturn_ShouldReturnCorrectDepth()
    {
        var history = BuildHistory(1, 2, 3);

        Assert.Equal(
            3,
            history.SearchReturn(CreateRequest(1)));
    }

    [Fact]
    public void SearchReturn_ShouldReturnMinusOneWhenMissing()
    {
        var history = BuildHistory(1, 2, 3);

        Assert.Equal(
            -1,
            history.SearchReturn(CreateRequest(99)));
    }

    // =====================================================
    // SORT TESTS
    // =====================================================

    [Fact]
    public void SortReturns_ShouldPlaceSmallestIdOnTop()
    {
        var history = BuildHistory(3, 1, 2);

        history.SortReturns();

        Assert.Equal(1, history.PeekLastReturn().ReturnId);
    }

    [Fact]
    public void SortReturns_ShouldPopInAscendingOrder()
    {
        var history = BuildHistory(3, 1, 2);

        history.SortReturns();

        Assert.Equal(1, history.PopReturn().ReturnId);
        Assert.Equal(2, history.PopReturn().ReturnId);
        Assert.Equal(3, history.PopReturn().ReturnId);
    }

    [Fact]
    public void SortReturns_ShouldHandleDuplicateIds()
    {
        var history = BuildHistory(2, 1, 2);

        history.SortReturns();

        Assert.Equal(1, history.PopReturn().ReturnId);
        Assert.Equal(2, history.PopReturn().ReturnId);
        Assert.Equal(2, history.PopReturn().ReturnId);
    }

    /// <summary>
    /// Creates a return-history stack using several IDs.
    /// </summary>
    private static ReturnHistoryStack BuildHistory(
        params int[] returnIds)
    {
        var history = new ReturnHistoryStack();

        foreach (int id in returnIds)
        {
            history.PushReturn(CreateRequest(id));
        }

        return history;
    }

    /// <summary>
    /// Creates a sample return request for testing.
    /// </summary>
    private static ReturnRequest CreateRequest(int returnId)
    {
        return new ReturnRequest(
            returnId,
            1000 + returnId,
            $"Reason {returnId}");
    }
}