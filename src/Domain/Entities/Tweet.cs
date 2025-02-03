namespace Domain.Entities;

public class Tweet : Entity
{
    public Guid UserId { get; set; }
    public User User{ get; set; } = default!;
    public string Content { get; set; } = default!;
    public DateTime Date { get; set; }

    public Tweet(
        Guid userId,
        string content,
        DateTime date)
    {
        Content = content;
        Date = date;
        UserId = userId;
    }

}