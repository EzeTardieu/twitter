namespace Application.UseCases.Users.Queries.GetUsers;
public class GetUsersDto
{
    public IEnumerable<UserDto> Users { get; set; } = default!;
    //TODO: Agregar paginación
    public GetUsersDto(IEnumerable<UserDto> users)
    {
        Users = users;
    }
}