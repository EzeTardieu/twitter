namespace Domain.Entities;

public class Tweet : Entity
{
    public string Content { get; set; } = default!;
    public DateTime Date { get; set; }
}