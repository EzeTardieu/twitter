namespace Web.Dto;

public class TweetResponse
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Content { get; private set; }
    public DateTime Date { get; private set; }
    public TweetResponse(Guid id, Guid userId, string content, DateTime date)
    {
        Id = id;
        UserId = userId;
        Content = content;
        Date = date;
    }
}