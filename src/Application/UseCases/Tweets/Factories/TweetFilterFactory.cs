using Domain.Filters;

namespace Application.UseCases.Tweets.Factories;

internal static class TweetFilterFactory
{
    internal static TweetFilter Create(IEnumerable<Guid> followedUsersIds)
    {
        return new TweetFilter
        (
            usersIds: followedUsersIds
        );
    }
}