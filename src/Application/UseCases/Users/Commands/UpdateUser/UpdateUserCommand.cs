namespace Application.UseCases.Users.Commands.UpdateUser;

public record UpdateUserCommand(Guid Id, string Name, string Email);