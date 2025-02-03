namespace Domain.Filters;

public class PaginationFilter
{
    public int Offset { get; private set; }
    public int Limit { get; private set; }

    public PaginationFilter(int offset = 0, int limit = 20)
    {
        Offset = offset;
        Limit = limit;
    }
}