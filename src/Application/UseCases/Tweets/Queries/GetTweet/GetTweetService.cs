using Application.UseCases.Tweets.Factories;
using Domain.Repositories;

namespace Application.UseCases.Tweets.Queries.GetTweet;
public class GetTweetService
{
    private readonly ITweetRepository _tweetRepository;

    public GetTweetService(
        ITweetRepository tweetRepository
    )
    {
        _tweetRepository = tweetRepository;
    }
    public async Task<GetTweetDto> Execute(GetTweetQuery query)
    {
        var tweet= await _tweetRepository.GetAsync(query.Id);
        return GetTweetDtoFactory.Create(tweet);
    }
}