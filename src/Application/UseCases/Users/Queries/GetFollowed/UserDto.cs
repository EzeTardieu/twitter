namespace Application.UseCases.Users.Queries.GetFollowed;
public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public UserDto(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}