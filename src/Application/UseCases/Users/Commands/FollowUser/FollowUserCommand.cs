namespace Application.UseCases.Users.Commands.FollowUser;

public record FollowUserCommand(Guid userId, Guid userToBeFollowedId);