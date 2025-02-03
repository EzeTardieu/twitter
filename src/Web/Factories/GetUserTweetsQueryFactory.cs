using Application.UseCases.Users.Queries.GetUserTweets;

namespace Web.Factories;

internal static class GetUserTweetsQueryFactory
{
    internal static GetUserTweetsQuery Create(Guid userId)
    {
        return new(userId);
    }
}