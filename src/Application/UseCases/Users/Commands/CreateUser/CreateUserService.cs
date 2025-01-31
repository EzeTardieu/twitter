using Application.UseCases.Users.Factories;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases.Users.Commands.CreateUser;
public class CreateUserService
{
    private readonly IUserRepository _userRepository;

    public CreateUserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Execute(CreateUserCommand command)
    {
        User user = UserFactory.Create(command);
        await _userRepository.AddAsync(user);
    }
}