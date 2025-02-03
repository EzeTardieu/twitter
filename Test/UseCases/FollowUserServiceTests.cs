using Application.UseCases.Tweets.Queries.GetTweet;
using Application.UseCases.Users.Commands.FollowUser;
using Application.UseCases.Users.Queries.GetUserTweets;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;
using FluentAssertions;
using FluentValidation;
using Moq;

namespace UseCases;
public class FollowUserServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new();
    private readonly FollowUserService _followUserService;
    private readonly IValidator<FollowUserCommand> _validator;

    public FollowUserServiceTests()
    {
        _validator = new FollowUserCommandValidator();
        _followUserService = new FollowUserService(_userRepositoryMock.Object, _validator);
    }

    [Fact]
    public async Task Execute_ShouldThrowValidationException_WhenUserTriesToFollowThemselves()
    {
        var userId = Guid.NewGuid();
        var command = new FollowUserCommand(userId, userId);

        var act = async () => await _followUserService.Execute(command);

        await act.Should().ThrowAsync<ValidationException>()
            .WithMessage("*A user cannot follow themselves.*");
    }

    [Fact]
    public async Task Execute_ShouldSuccessfullyFollowAnotherUser_WhenValidRequest()
    {
        var userId = Guid.NewGuid();
        var followUserId = Guid.NewGuid();
        var command = new FollowUserCommand(userId, followUserId);

        var user = new User(userId, "User1", "user1@mail.com");
        var followUser = new User(followUserId, "User2", "user2@mail.com");

        _userRepositoryMock
            .Setup(repo => repo.GetAsync(userId))
            .ReturnsAsync(user);
        _userRepositoryMock
            .Setup(repo => repo.GetAsync(followUserId))
            .ReturnsAsync(followUser);

        await _followUserService.Execute(command);

        user.FollowedUsers.Should().Contain(followUser);

        _userRepositoryMock.Verify(repo => repo.UpdateAsync(user), Times.Once);

    }
}
