using Application.UseCases.Tweets.Queries.GetTweet;
using Application.UseCases.Users.Queries.GetUserTweets;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace UseCases;
public class GetTweetsServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new();
    private readonly GetUserTweetsService _getUserTweetsService;

    public GetTweetsServiceTests()
    {
        _getUserTweetsService = new GetUserTweetsService(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnTweets_WhenUserHasTweets()
    {
        var userId = Guid.NewGuid();
        var tweets = new List<Tweet>
        {
            new Tweet(userId, "First tweet", DateTime.Now),
            new Tweet(userId, "Second tweet", DateTime.Now)
        };
        User user = new User(userId, "testUser", "test@mail.com");

        user.Tweets = tweets;

        _userRepositoryMock
            .Setup(repo => repo.GetAsync(userId, true))
            .ReturnsAsync(user);

        var result = await _getUserTweetsService.Execute(new GetUserTweetsQuery(userId));

        result.Tweets.Should().HaveCount(2);
        result.Tweets.First().Content.Should().Be("First tweet");
    }

    [Fact]
    public async Task Execute_ShouldReturnEmptyList_WhenUserHasNoTweets()
    {

        var userId = Guid.NewGuid();
        var user = new User(userId, "testUser", "test@mail.com");

        _userRepositoryMock
            .Setup(repo => repo.GetAsync(userId, true))
            .ReturnsAsync(user);

        var result = await _getUserTweetsService.Execute(new GetUserTweetsQuery(userId));

        result.Tweets.Should().BeEmpty();
    }
    [Fact]
    public async Task Execute_ShouldThrowKeyNotFoundException_WhenUserDoesNotExist()
    {
        var userId = Guid.NewGuid();

        _userRepositoryMock
            .Setup(repo => repo.GetAsync(userId, true))
            .ThrowsAsync(new KeyNotFoundException());

        var act = async () => await _getUserTweetsService.Execute(new GetUserTweetsQuery(userId));

        await act.Should().ThrowAsync<KeyNotFoundException>();
    }
}
