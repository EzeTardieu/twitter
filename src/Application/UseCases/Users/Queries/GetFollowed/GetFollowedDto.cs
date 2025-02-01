namespace Application.UseCases.Users.Queries.GetFollowed;

public class GetFollowedDto
{
    public IEnumerable<UserDto> Users { get; set; } = default!;
    //TODO: Agregar paginación
    public GetFollowedDto(IEnumerable<UserDto> users)
    {
        Users = users;
    }
}