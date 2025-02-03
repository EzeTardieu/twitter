using Application.Constants;
using Application.UseCases.Tweets.Commands.CreateTweet;
using FluentValidation;

public class CreateTweetCommandValidator : AbstractValidator<CreateTweetCommand>
{
    public CreateTweetCommandValidator()
    {
        RuleFor(command => command.Content)
            .NotEmpty().WithMessage("Tweet content cannot be empty.")
            .MaximumLength(TweetConstants.MaxTweetLength).WithMessage($"Tweet content cannot exceed {TweetConstants.MaxTweetLength} characters.");
    }
}