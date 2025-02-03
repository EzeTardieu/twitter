namespace Application.UseCases.Users.Queries.GetUserById;

public class GetUserByIdDto
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    
    public GetUserByIdDto(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}