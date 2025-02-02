using Application.UseCases.Tweets.Queries.GetTimeline;
using Web.Dto;

namespace Web.Factories;

internal static class TweetResponseFactory
{
    internal static TweetResponse Create(TweetDto tweetDto)
    {
        return new TweetResponse(
            userName:tweetDto.UserName,
            content: tweetDto.Content,
            date: tweetDto.Date
        );
    }
}