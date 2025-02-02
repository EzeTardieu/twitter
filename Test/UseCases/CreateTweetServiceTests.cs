using Application.Constants;
using Application.UseCases.Tweets.Commands.CreateTweet;
using Application.UseCases.Tweets.Queries.GetTweet;
using Application.UseCases.Users.Queries.GetUserTweets;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;
using FluentAssertions;
using FluentValidation;
using Moq;

namespace UseCases;
public class CreateTweetServiceTests
{
    private readonly Mock<ITweetRepository> _tweetRepositoryMock = new();
    private readonly CreateTweetService _createTweetService;
    private readonly IValidator<CreateTweetCommand> _validator;

    public CreateTweetServiceTests()
    {
        _validator = new CreateTweetCommandValidator();
        _createTweetService = new CreateTweetService(_tweetRepositoryMock.Object, _validator);
    }
    [Fact]
    public async Task Execute_ShouldThrowValidationException_WhenTweetContentIsEmpty()
    {
        var userId = Guid.NewGuid();
        var emptyContent = "";
        var command = new CreateTweetCommand(userId, emptyContent, DateTime.Now);

        var act = async () => await _createTweetService.Execute(command);

        await act.Should().ThrowAsync<ValidationException>()
            .WithMessage("*Tweet content cannot be empty*");
    }
    [Fact]
    public async Task Execute_ShouldThrowValidationException_WhenTweetContentIsTooLong()
    {
        var userId = Guid.NewGuid();
        var longContent = new string('a', TweetConstants.MaxTweetLength + 1);
        var command = new CreateTweetCommand(userId, longContent, DateTime.Now);

        var act = async () => await _createTweetService.Execute(command);

        await act.Should().ThrowAsync<ValidationException>()
            .WithMessage($"*Tweet content cannot exceed {TweetConstants.MaxTweetLength} characters.*");
    }

    [Fact]
    public async Task Execute_ShouldCreateTweet_WhenDataIsValid()
    {
        var userId = Guid.NewGuid();
        var content = "This is a test tweet";
        var command = new CreateTweetCommand(userId, content, DateTime.Now);

        _tweetRepositoryMock
            .Setup(repo => repo.AddAsync(It.IsAny<Tweet>()))
            .Returns(Task.CompletedTask);

        await _createTweetService.Execute(command);

        _tweetRepositoryMock.Verify(repo => repo.AddAsync(It.Is<Tweet>(
            t => t.UserId == userId && t.Content == content)), Times.Once);
    }
}
