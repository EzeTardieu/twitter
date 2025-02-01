using Application.UseCases.Users.Queries.GetFollowed;
using Web.Dto;

namespace Web.Factories;

internal static class UserResponseFactory
{
    internal static UserResponse Create(UserDto userDto)
    {
        return new UserResponse(
            name: userDto.Name,
            email: userDto.Email
        );
    }
}