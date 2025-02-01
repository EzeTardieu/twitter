namespace Web.Dto;
public class GetFollowedResponse
{
    public IEnumerable<UserResponse> Users { get; private set; } = default!;
    public GetFollowedResponse(IEnumerable<UserResponse> users)
    {
        Users = users;
    }
}