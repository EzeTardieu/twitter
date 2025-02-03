using Application.UseCases.Tweets.Queries.GetTweet;

namespace Web.Factories;

internal static class GetTweetQueryFactory
{
    internal static GetTweetQuery Create(Guid id)
    {
        return new(id);
    }
}