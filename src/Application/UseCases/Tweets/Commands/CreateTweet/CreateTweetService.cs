using Application.UseCases.Tweets.Factories;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases.Tweets.Commands.CreateTweet;
public class CreateTweetService
{
    private readonly ITweetRepository _tweetRepository;

    public CreateTweetService(ITweetRepository tweetRepository)
    {
        _tweetRepository = tweetRepository;
    }

    public async Task<Guid> Execute(CreateTweetCommand command)
    {
        Tweet tweet = TweetFactory.Create(command);
        await _tweetRepository.AddAsync(tweet);
        return tweet.Id;
    }
}