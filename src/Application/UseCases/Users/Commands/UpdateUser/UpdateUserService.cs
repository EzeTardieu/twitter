using Domain.Repositories;

namespace Application.UseCases.Users.Commands.UpdateUser;
public class UpdateUserService
{
    private readonly IUserRepository _userRepository;

    public UpdateUserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Execute(UpdateUserCommand command)
    {
        var user = await _userRepository.GetAsync(command.Id);
        
        user.Name = command.Name;
        user.Email = command.Email;

        await _userRepository.UpdateAsync(user);
    }
}