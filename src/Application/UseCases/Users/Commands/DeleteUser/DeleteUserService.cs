using Domain.Repositories;

namespace Application.UseCases.Users.Commands.DeleteUser;
public class DeleteUserService
{
    private readonly IUserRepository _userRepository;

    public DeleteUserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Execute(DeleteUserCommand command)
    {
        await _userRepository.DeleteAsync(command.Id);
    }
}