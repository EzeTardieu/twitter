using Application.UseCases.Tweets.Queries.GetTimeline;
using Domain.Filters;

namespace Application.UseCases.Tweets.Factories;

internal static class PaginationFilterFactory
{
    internal static PaginationFilter Create(GetTimelineQuery getTimelineQuery)
    {
        return new PaginationFilter(
            offset: getTimelineQuery.Offset,
            limit: getTimelineQuery.Limit
        );
    }
}