using Application.UseCases.Tweets.Commands.CreateTweet;
using Application.UseCases.Tweets.Commands.DeleteTweet;

namespace Web.Factories;

internal static class DeleteTweetCommandFactory
{
    internal static DeleteTweetCommand Create(Guid id)
    {
        return new(id);
    }
}