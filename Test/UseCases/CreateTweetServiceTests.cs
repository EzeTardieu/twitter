using Application.UseCases.Tweets.Commands.CreateTweet;
using Application.UseCases.Tweets.Queries.GetTweet;
using Application.UseCases.Users.Queries.GetUserTweets;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace UseCases;
public class CreateTweetServiceTests
{
    private readonly Mock<ITweetRepository> _tweetRepositoryMock = new();
    private readonly CreateTweetService _createTweetService;

    public CreateTweetServiceTests()
    {
        _createTweetService = new CreateTweetService(_tweetRepositoryMock.Object);
    }

}
