using Application.UseCases.Tweets.Factories;
using Domain.Repositories;

namespace Application.UseCases.Tweets.Queries.GetTimeline;
public class GetTimelineService
{
    private readonly IUserRepository _userRepository;
    private readonly ITweetRepository _tweetRepository;

    public GetTimelineService(
        IUserRepository userRepository,
        ITweetRepository tweetRepository
    )
    {
        _userRepository = userRepository;
        _tweetRepository = tweetRepository;
    }
    public async Task<GetTimelineDto> Execute(GetTimelineQuery query)
    {
        var followedUsersIds = (await _userRepository.GetFollowed(query.UserId)).Select(user => user.Id);
        var filteredTweets = await _tweetRepository.GetAllAsync(TweetFilterFactory.Create(followedUsersIds));
        return GetTimelineDtoFactory.Create(filteredTweets);
    }
}