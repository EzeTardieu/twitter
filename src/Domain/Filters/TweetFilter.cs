using Domain.Filters.Interfaces;

namespace Domain.Filters;

public class TweetFilter : IFilter
{
    public IEnumerable<Guid> UsersIds { get; private set; }
    public PaginationFilter PaginationFilters { get; private set; }

    public TweetFilter(IEnumerable<Guid> usersIds, PaginationFilter paginationFilters)
    {
        UsersIds = usersIds;
        PaginationFilters = paginationFilters;
    }
}