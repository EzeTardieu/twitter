using Application.UseCases.Tweets.Queries.GetTimeline;
using Domain.Filters;

namespace Application.UseCases.Tweets.Factories;

internal static class TweetFilterFactory
{
    internal static TweetFilter Create(IEnumerable<Guid> followedUsersIds, GetTimelineQuery getTimelineQuery)
    {
        return new TweetFilter
        (
            paginationFilters: PaginationFilterFactory.Create(getTimelineQuery),
            usersIds: followedUsersIds
        );
    }
}