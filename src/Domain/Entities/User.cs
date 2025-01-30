namespace Domain.Entities;

public class User : Entity
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public ICollection<Tweet> Tweets { get; private set; } = []; 
}