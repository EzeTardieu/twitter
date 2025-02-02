using Application.UseCases.Tweets.Factories;
using Domain.Entities;
using Domain.Repositories;
using FluentValidation;

namespace Application.UseCases.Tweets.Commands.CreateTweet;
public class CreateTweetService
{
    private readonly ITweetRepository _tweetRepository;
    private readonly IValidator<CreateTweetCommand> _validator;

    public CreateTweetService(ITweetRepository tweetRepository, IValidator<CreateTweetCommand> validator)
    {
        _tweetRepository = tweetRepository;
        _validator = validator;
    }

    public async Task<Guid> Execute(CreateTweetCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        Tweet tweet = TweetFactory.Create(command);
        await _tweetRepository.AddAsync(tweet);
        return tweet.Id;
    }
}