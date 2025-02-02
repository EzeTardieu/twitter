using Application.UseCases.Tweets.Commands.CreateTweet;
using Web.Dto;

namespace Web.Factories;

internal static class CreateTweetCommandFactory
{
    internal static CreateTweetCommand Create(CreateTweetRequest request)
    {
        return new CreateTweetCommand(
            UserId: request.UserId,
            Content: request.Content
        );
    }
}