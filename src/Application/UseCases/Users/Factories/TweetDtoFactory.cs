
using Application.UseCases.Users.Queries.GetUserTweets;
using Domain.Entities;

namespace Application.UseCases.Users.Factories;

internal static class TweetDtoFactory
{
    internal static TweetDto Create(Tweet tweet)
    {
        return new TweetDto(
            content: tweet.Content,
            date: tweet.Date
        );
    }
}