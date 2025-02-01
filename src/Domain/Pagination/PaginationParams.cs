public class PaginationParams
{
    public int Offset { get; private set; }
    public int Limit { get; private set; }
    public PaginationParams(int offset, int limit)
    {
        Offset = offset;
        Limit = limit;
    }
}