using Application.UseCases.Users.Queries.GetFollowed;
using Web.Dto;

namespace Web.Factories;

internal static class GetFollowedResponseFactory
{
    internal static GetFollowedResponse Create(GetFollowedDto getFollowedDto)
    {
        return new GetFollowedResponse(
            users: getFollowedDto.Users.Select(UserResponseFactory.Create)
        );
    }
}