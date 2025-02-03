namespace Application.UseCases.Users.Queries.GetUserTweets;

public class TweetDto
{
    public Guid Id { get; private set; }
    public string Content { get; private set; }
    public DateTime Date { get; private set; }
    public TweetDto(Guid id, string content, DateTime date)
    {
        Id = id;
        Content = content;
        Date = date;
    }
}