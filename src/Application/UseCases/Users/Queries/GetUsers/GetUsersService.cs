using Application.UseCases.Users.Factories;
using Domain.Repositories;

namespace Application.UseCases.Users.Queries.GetUsers;

public class GetUsersService
{
    private readonly IUserRepository _userRepository;

    public GetUsersService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<GetUsersDto> Execute(GetUsersQuery query)
    {
        var users = await _userRepository.GetAllAsync();
        return GetUsersDtoFactory.Create(users);
    }
}