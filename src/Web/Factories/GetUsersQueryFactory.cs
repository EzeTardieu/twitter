using Application.UseCases.Users.Queries.GetUsers;

namespace Web.Factories;

internal static class GetUsersQueryFactory
{
    internal static GetUsersQuery Create()
    {
        return new();
    }
}