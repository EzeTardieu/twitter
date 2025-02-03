using Application.UseCases.Tweets.Queries.GetTimeline;
using Web.Dto;

namespace Web.Factories;

internal static class GetTimelineQueryFactory
{
    internal static GetTimelineQuery Create(GetTimelineRequest getTimelineRequest)
    {
        return new GetTimelineQuery(
            UserId: getTimelineRequest.UserId,
            Offset: (getTimelineRequest.Page - 1) * getTimelineRequest.PageSize,
            Limit: getTimelineRequest.PageSize
        );
    }
}