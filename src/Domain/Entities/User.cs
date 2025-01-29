namespace Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = default!;
    public IReadOnlyCollection<Tweet> Tweets { get; private set; } = []; 
}