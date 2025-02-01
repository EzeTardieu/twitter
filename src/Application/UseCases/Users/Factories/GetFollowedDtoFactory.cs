using Application.UseCases.Users.Queries.GetFollowed;
using Domain.Entities;

namespace Application.UseCases.Users.Factories;

internal static class GetFollowedDtoFactory
{
    internal static GetFollowedDto Create(IEnumerable<User> users)
    {
        return new GetFollowedDto(
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