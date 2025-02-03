namespace Application.UseCases.Users.Queries.GetFollowed;

public class GetFollowedDto
{
    public IEnumerable<UserDto> Users { get; set; } = default!;
    public GetFollowedDto(IEnumerable<UserDto> users)
    {
        Users = users;
    }
}