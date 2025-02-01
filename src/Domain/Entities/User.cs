namespace Domain.Entities;

public class User : Entity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public ICollection<Tweet> Tweets { get; set; } = [];
    public virtual ICollection<User> FollowedUsers {get; set; } = [];

    public User(
        string name,
        string email
        )
    {
        Name = name;
        Email = email;
    }
}