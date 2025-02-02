using FluentValidation;
using Web.Constants;
using Web.Dto;

namespace Web.Validators;
public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(request => request.Name).Length(0,UserConstants.UserNameMaxLength);
        RuleFor(request => request.Email).EmailAddress();
    }
}