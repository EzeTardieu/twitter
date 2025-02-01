namespace Application.UseCases.Users.Queries.GetUserTweets;

public class TweetDto
{
    public string Content { get; set; } = default!;
    public DateTime Date { get; set; }
    public TweetDto(string content, DateTime date)
    {
        Content = content;
        Date = date;
    }
}