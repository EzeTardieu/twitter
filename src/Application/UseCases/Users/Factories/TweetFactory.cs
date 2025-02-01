using Application.UseCases.Users.Commands.CreateTweet;
using Domain.Entities;

namespace Application.UseCases.Users.Factories;

internal static class TweetFactory
{
    internal static Tweet Create(CreateTweetCommand command)
    {
        return new Tweet(
            content: command.Content,
            date: DateTime.Now
        );
    }
}