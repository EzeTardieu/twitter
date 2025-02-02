using Application.UseCases.Tweets.Queries.GetTweet;
using Domain.Entities;

namespace Application.UseCases.Tweets.Factories;

internal static class GetTweetDtoFactory
{
    internal static GetTweetDto Create(Tweet tweet)
    {
        return new GetTweetDto(tweet.Id, tweet.UserId, tweet.Content, tweet.Date);
    }
}