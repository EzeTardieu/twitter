

using Application.UseCases.Tweets.Commands.CreateTweet;
using Domain.Entities;

namespace Application.UseCases.Tweets.Factories;

internal static class TweetFactory
{
    internal static Tweet Create(CreateTweetCommand command)
    {
        return new Tweet(
            userId: command.UserId,
            content: command.Content,
            date: command.Date
        );
    }
}