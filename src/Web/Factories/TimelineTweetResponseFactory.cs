using Application.UseCases.Tweets.Queries.GetTimeline;
using Web.Dto;

namespace Web.Factories;

internal static class TimelineTweetResponseFactory
{
    internal static TimelineTweetResponse Create(TweetDto tweetDto)
    {
        return new TimelineTweetResponse(
            userName:tweetDto.UserName,
            content: tweetDto.Content,
            date: tweetDto.Date
        );
    }
}