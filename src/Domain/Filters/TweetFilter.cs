using Domain.Filters.Interfaces;

namespace Domain.Filters;

public class TweetFilter : IFilter
{
    public IEnumerable<Guid> UsersIds { get; private set; }
    
    public TweetFilter(IEnumerable<Guid> usersIds)
    {
        UsersIds = usersIds;        
    }
}