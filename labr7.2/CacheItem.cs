private class CacheItem
{
    public TResult Result { get; }
    public DateTime TimeStamp { get; }

    public CacheItem(TResult result, DateTime timeStamp)
    {
        Result = result;
        TimeStamp = timeStamp;
    }
}
}