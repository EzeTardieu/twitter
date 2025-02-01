using Application.UseCases.Users.Commands.DeleteUser;

namespace Web.Factories;

internal static class DeleteUserCommandFactory
{
    internal static DeleteUserCommand Create(Guid id)
    {
        return new(id);
    }
}