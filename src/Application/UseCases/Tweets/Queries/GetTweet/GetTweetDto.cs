namespace Application.UseCases.Tweets.Queries.GetTweet;

public class GetTweetDto
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Content { get; private set; }
    public DateTime Date { get; private set; }
    public GetTweetDto(Guid id, Guid userId, string content, DateTime date)
    {
        Id = id;
        UserId = userId;
        Content = content;
        Date = date;
    }
}