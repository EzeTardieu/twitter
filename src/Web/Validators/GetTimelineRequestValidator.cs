using Application.Constants;
using FluentValidation;
using Web.Dto;

namespace Web.Validators;
public class GetTimelineRequestValidator : AbstractValidator<GetTimelineRequest>
{
    public GetTimelineRequestValidator()
    {
        RuleFor(request => request.Page)
            .GreaterThan(0);

        RuleFor(request => request.PageSize)
            .InclusiveBetween(TweetConstants.MinTimelinePageSize,TweetConstants.MaxTimelinePageSize);
    }
}