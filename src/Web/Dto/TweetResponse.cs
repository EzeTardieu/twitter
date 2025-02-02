namespace Web.Dto;

public class TweetResponse
{
    public string UserName { get; private set; }
    public string Content { get; private set; }
    public DateTime Date { get; private set; }
    public TweetResponse(string userName, string content, DateTime date)
    {
        UserName = userName;
        Content = content;
        Date = date;
    }
}