using Application.UseCases.Users.Commands.FollowUser;
using Web.Dto;

namespace Web.Factories;

internal static class FollowUserCommandFactory
{
    internal static FollowUserCommand Create(Guid userId, FollowUserRequest followUserDto){
        return new FollowUserCommand
        (
            userId: userId,
            userToBeFollowedId: followUserDto.UserToBeFollowedId
        );
    }
}