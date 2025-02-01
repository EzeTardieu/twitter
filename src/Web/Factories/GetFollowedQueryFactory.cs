using Application.UseCases.Users.Queries.GetFollowing;

namespace Web.Factories;

internal static class GetFollowedQueryFactory
{
    internal static GetFollowedQuery Create(Guid userId)
    {
        return new(userId);
    }
}