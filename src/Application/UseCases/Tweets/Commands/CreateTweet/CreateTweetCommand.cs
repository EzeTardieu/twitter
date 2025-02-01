namespace Application.UseCases.Tweets.Commands.CreateTweet;

public record CreateTweetCommand(Guid UserId ,string Content);