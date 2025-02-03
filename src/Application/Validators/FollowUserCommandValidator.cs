using Application.Constants;
using Application.UseCases.Tweets.Commands.CreateTweet;
using Application.UseCases.Users.Commands.FollowUser;
using FluentValidation;

public class FollowUserCommandValidator : AbstractValidator<FollowUserCommand>
{
    public FollowUserCommandValidator()
    {
        RuleFor(command => command.userId)
            .NotEqual(command => command.userToBeFollowedId).WithMessage("A user cannot follow themselves.");
    }
}