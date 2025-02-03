using Application.UseCases.Users.Commands.CreateUser;
using Web.Dto;

namespace Web.Factories;

internal static class CreateUserCommandFactory
{
    internal static CreateUserCommand Create(CreateUserRequest request)
    {
        return new CreateUserCommand(
            Name: request.Name,
            Email: request.Email
        );
    }
}