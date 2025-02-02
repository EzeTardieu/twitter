namespace Web.Dto;

public class UserTweetResponse
{
    public Guid Id { get; private set; }
    public string Content { get; private set; }
    public DateTime Date { get; private set; }
    public UserTweetResponse(Guid id, string content, DateTime date)
    {
        Id = id;
        Content = content;
        Date = date;
    }
}