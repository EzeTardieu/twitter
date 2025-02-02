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
        var filter = TweetFilterFactory.Create(followedUsersIds, query);
        var filteredTweets = await _tweetRepository.GetAllAsync(filter);
        var totalCount = await _tweetRepository.CountAllAsync(filter);
        return GetTimelineDtoFactory.Create(filteredTweets, totalCount);
    }
}