namespace Domain.Entities;

public class Tweet : BaseEntity
{
    public string Content { get; set; } = default!;
}