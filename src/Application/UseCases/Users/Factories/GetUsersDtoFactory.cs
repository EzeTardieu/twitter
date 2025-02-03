using Application.UseCases.Users.Queries.GetUsers;
using Domain.Entities;

namespace Application.UseCases.Users.Factories;

internal static class GetUsersDtoFactory
{
    internal static GetUsersDto Create(IEnumerable<User> users)
    {
        return new GetUsersDto(
            users: users.Select(CreateUserDto)
        );
    }
    private static UserDto CreateUserDto(User user)
    {
        return new UserDto(
            id: user.Id,
            name: user.Name,
            email: user.Email
        );
    }
}