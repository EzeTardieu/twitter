using Application.Constants;
using Application.UseCases.Tweets.Commands.CreateTweet;
using Application.UseCases.Tweets.Factories;
using Application.UseCases.Tweets.Queries.GetTimeline;
using Application.UseCases.Tweets.Queries.GetTweet;
using Application.UseCases.Users.Queries.GetUserTweets;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;
using FluentAssertions;
using FluentValidation;
using Moq;

namespace UseCases;
public class GetTimelineServiceTests
{
    private readonly Mock<ITweetRepository> _tweetRepositoryMock = new();
    private readonly Mock<IUserRepository> _userRepositoryMock = new();
    private readonly GetTimelineService _getTimelineService;

    public GetTimelineServiceTests()
    {
        _getTimelineService = new GetTimelineService(_userRepositoryMock.Object, _tweetRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnTweets_WhenUserFollowsOtherUsers()
    {
        var userId = Guid.NewGuid();
        var followedUserId = Guid.NewGuid();
        var query = new GetTimelineQuery(userId, 0, 2);

        var followedUsers = new List<User>
    {
        new User(followedUserId, "FollowedUser", "followed@mail.com")
    };

        var tweets = new List<Tweet>
    {
        new Tweet(followedUserId, "First tweet", DateTime.Now),
        new Tweet(followedUserId, "Second tweet", DateTime.Now)
    };

        foreach (var tweet in tweets)
        {
            tweet.User = followedUsers[0];
        }

        var tweetFilter = TweetFilterFactory.Create(followedUsers.Select(u => u.Id), query);

        _userRepositoryMock
            .Setup(repo => repo.GetFollowed(userId))
            .ReturnsAsync(followedUsers);

        _tweetRepositoryMock
            .Setup(repo => repo.GetAllAsync(It.IsAny<TweetFilter>()))
            .ReturnsAsync(tweets);

        _tweetRepositoryMock
            .Setup(repo => repo.CountAllAsync(It.IsAny<TweetFilter>()))
            .ReturnsAsync(tweets.Count);

        var result = await _getTimelineService.Execute(query);

        result.Tweets.Should().HaveCount(2);
        result.TotalCount.Should().Be(2);
        result.Tweets.First().Content.Should().Be("First tweet");
    }

    [Fact]
    public async Task Execute_ShouldReturnEmptyList_WhenUserFollowsNoOne()
    {
        var userId = Guid.NewGuid();
        var user = new User(userId, "User1", "user1@mail.com");

        _userRepositoryMock
            .Setup(repo => repo.GetFollowed(userId))
            .ReturnsAsync(new List<User>());
        
        _tweetRepositoryMock
            .Setup(repo => repo.GetAllAsync(It.IsAny<TweetFilter>()))
            .ReturnsAsync(new List<Tweet>());

        _tweetRepositoryMock
            .Setup(repo => repo.CountAllAsync(It.IsAny<TweetFilter>()))
            .ReturnsAsync(0);

        
        var result = await _getTimelineService.Execute(new GetTimelineQuery(userId, 0, 10));

        result.Tweets.Should().BeEmpty();
        result.TotalCount.Should().Be(0);
    }
}
