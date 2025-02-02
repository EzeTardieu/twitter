using FluentValidation;
using Web.Constants;
using Web.Dto;

namespace Web.Validators;
public class CreateTweetRequestValidator : AbstractValidator<CreateTweetRequest>
{
    public CreateTweetRequestValidator()
    {
        RuleFor(request => request.Content).Length(0,TweetConstants.MaxTweetLength);
    }
}