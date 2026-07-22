using DataStructuresLibrary;

namespace ECommerceSystem.Core
{
    public class ReturnHistoryStack
    {
        private readonly CustomStack<ReturnRequest> _returns = new();

        public int Count => _returns.Count;

<<<<<<< HEAD
        public void PushReturn(ReturnRequest request) => throw new NotImplementedException();
        public ReturnRequest PopReturn() => throw new NotImplementedException();
        public ReturnRequest PeekLatestReturn() => throw new NotImplementedException();


        public int SearchReturn(ReturnRequest request) => throw new NotImplementedException();
        public void SortReturns() => throw new NotImplementedException();
=======
    public void PushReturn(ReturnRequest request)
    {
        _returns.Push(request);
    }

    public ReturnRequest PopReturn()
    {
        return _returns.Pop();
    }

    public ReturnRequest PeekLatestReturn()
    {
        return _returns.Peek();
    }

    public int SearchReturn(ReturnRequest request)
    {
        return _returns.Search(request);
    }

    public void SortReturns()
    {
        _returns.Sort();
>>>>>>> 86cedef (Custom Stack)
    }
}