using Domain.Filters.Interfaces;

namespace Domain.Filters;

public class TweetFilter : IFilter
{
    public PaginationFilter PaginationFilters { get; private set; }
    public IEnumerable<Guid>? UsersIds { get; private set; }

    public TweetFilter(PaginationFilter paginationFilters, IEnumerable<Guid> usersIds)
    {
        PaginationFilters = paginationFilters;
        UsersIds = usersIds;
    }
    public TweetFilter(PaginationFilter paginationFilters)
    {
        PaginationFilters = paginationFilters;
    }
}