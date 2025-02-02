namespace Application.UseCases.Tweets.Queries.GetTimeline;

public class TweetDto
{
    public string UserName { get; private set; }
    public string Content { get; private set; }
    public DateTime Date { get; private set; }
    public TweetDto(string userName, string content, DateTime date)
    {
        UserName = userName;
        Content = content;
        Date = date;
    }
}