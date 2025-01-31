using Application.UseCases.Users.Commands.CreateUser;
using Application.UseCases.Users.Queries.GetUserById;
using Domain.Entities;

namespace Application.UseCases.Users.Factories;

internal static class UserFactory
{
    internal static User Create(CreateUserCommand command)
    {
        return new User(
            name: command.Name,
            email: command.Email
        );
    }
    
}