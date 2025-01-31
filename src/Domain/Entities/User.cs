namespace Domain.Entities;

public class User : Entity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public ICollection<Tweet> Tweets { get; private set; } = [];

    public User(
        string name,
        string email
        )
    {
        Name = name;
        Email = email;
    }
}