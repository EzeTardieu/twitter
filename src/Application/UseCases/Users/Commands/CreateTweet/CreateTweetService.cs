using Application.UseCases.Users.Factories;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases.Users.Commands.CreateTweet;
public class CreateTweetService
{
    private readonly IUserRepository _userRepository;

    public CreateTweetService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Execute(CreateTweetCommand command)
    {
        User user = await _userRepository.GetAsync(command.UserId);
        Tweet tweet = TweetFactory.Create(command);
        user.Tweets.Add(tweet);

        await _userRepository.UpdateAsync(user);
    }
}