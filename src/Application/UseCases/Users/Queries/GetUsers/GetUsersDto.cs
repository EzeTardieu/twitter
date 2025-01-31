namespace Application.UseCases.Users.Queries.GetUsers;
public class GetUsersDto
{
    public ICollection<UserDto> Users { get; set; } = default!;
    //TODO: Agregar paginación
    public GetUsersDto(ICollection<UserDto> users)
    {
        Users = users;
    }
}