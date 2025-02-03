using Application.UseCases.Users.Queries.GetUserById;

namespace Web.Factories;

internal static class GetUserByIdQueryFactory
{
    internal static GetUserByIdQuery Create(Guid id)
    {
        return new(id);
    }
}