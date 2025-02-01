using Application.UseCases.Users.Factories;
using Domain.Repositories;

namespace Application.UseCases.Users.Queries.GetUserTweets;

public class GetUserTweetsService
{
    private readonly IUserRepository _userRepository;

    public GetUserTweetsService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<GetUserTweetsDto> Execute(GetUserTweetsQuery query)
    {
        var user = await _userRepository.GetAsync(
            id: query.UserId,
            includeTweets: true);
        return GetUserTweetsDtoFactory.Create(user);
    }
}