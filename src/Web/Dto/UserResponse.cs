namespace Web.Dto;
public class UserResponse
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public UserResponse(string name, string email)
    {
        Name = name;
        Email = email;
    }
}