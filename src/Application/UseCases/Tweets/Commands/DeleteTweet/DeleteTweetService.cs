using Application.UseCases.Tweets.Commands.CreateTweet;
using Domain.Repositories;

namespace Application.UseCases.Tweets.Commands.DeleteTweet;
public class DeleteTweetService
{
    private readonly ITweetRepository _tweetRepository;

    public DeleteTweetService(ITweetRepository tweetRepository)
    {
        _tweetRepository = tweetRepository;
    }

    public async Task Execute(DeleteTweetCommand command)
    {
        await _tweetRepository.DeleteAsync(command.TweetId);
    }

    public async Task Execute(CreateTweetCommand createTweetCommand)
    {
        throw new NotImplementedException();
    }
}