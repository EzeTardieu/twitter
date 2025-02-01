using Domain.Repositories;

namespace Application.UseCases.Users.Commands.FollowUser;
public class FollowUserService
{
    private readonly IUserRepository _userRepository;

    public FollowUserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Execute(FollowUserCommand command)
    {
        var user = await _userRepository.GetAsync(command.userId);
        var userToBeFollowed = await _userRepository.GetAsync(command.userToBeFollowedId);
        user.FollowedUsers.Add(userToBeFollowed);
        await _userRepository.UpdateAsync(user);
    }
}