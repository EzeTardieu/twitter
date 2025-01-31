using Application.UseCases.Users.Queries.GetUsers;
using Domain.Entities;

namespace Application.UseCases.Users.Factories;

internal static class UserDtoFactory
{
    internal static UserDto Create(User user)
    {
        return new UserDto(
            id: user.Id,
            name: user.Name,
            email: user.Email
        );
    }
}