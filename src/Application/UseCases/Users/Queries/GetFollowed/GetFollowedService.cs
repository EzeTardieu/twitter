using Application.UseCases.Users.Factories;
using Application.UseCases.Users.Queries.GetFollowed;
using Application.UseCases.Users.Queries.GetFollowing;
using Domain.Repositories;

namespace Application.UseCases.Users.Queries.GetUserById;

public class GetFollowedService
{
    private readonly IUserRepository _userRepository;

    public GetFollowedService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<GetFollowedDto> Execute(GetFollowedQuery query)
    {
        var followedUsers = await _userRepository.GetFollowed(query.UserId);
        return GetFollowedDtoFactory.Create(followedUsers);
    }
}