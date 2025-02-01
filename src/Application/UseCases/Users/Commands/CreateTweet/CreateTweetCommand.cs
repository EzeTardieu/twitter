namespace Application.UseCases.Users.Commands.CreateTweet;

public record CreateTweetCommand(Guid UserId ,string Content);