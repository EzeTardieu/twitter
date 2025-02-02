using FluentValidation;
using Application.Constants;
using Web.Dto;

namespace Web.Validators;
public class CreateTweetRequestValidator : AbstractValidator<CreateTweetRequest>
{
    public CreateTweetRequestValidator()
    {
        RuleFor(request => request.Content)
            .NotEmpty().WithMessage("Tweet content cannot be empty.")
            .MaximumLength(TweetConstants.MaxTweetLength).WithMessage("Tweet content cannot exceed 280 characters.");
    }
}