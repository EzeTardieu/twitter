using Application.UseCases.Tweets.Queries.GetTimeline;
using Web.Dto;

namespace Web.Factories;

internal static class GetTimelineResponseFactory
{
    internal static GetTimelineResponse Create(GetTimelineDto getTimelineDto)
    {
        return new(getTimelineDto.Tweets.Select(TimelineTweetResponseFactory.Create), getTimelineDto.TotalCount);
    }
}