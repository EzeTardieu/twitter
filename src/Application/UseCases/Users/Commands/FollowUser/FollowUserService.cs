using Domain.Repositories;
using FluentValidation;

namespace Application.UseCases.Users.Commands.FollowUser;
public class FollowUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<FollowUserCommand> _validator;

    public FollowUserService(IUserRepository userRepository, IValidator<FollowUserCommand> validator)
    {
        _userRepository = userRepository;
        _validator = validator;
    }

    public async Task Execute(FollowUserCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var user = await _userRepository.GetAsync(command.userId);
        var userToBeFollowed = await _userRepository.GetAsync(command.userToBeFollowedId);
        user.FollowedUsers.Add(userToBeFollowed);
        await _userRepository.UpdateAsync(user);
    }
}