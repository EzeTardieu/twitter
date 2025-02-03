using Application.UseCases.Users.Factories;
using Domain.Repositories;

namespace Application.UseCases.Users.Queries.GetUserById;

public class GetUserByIdService
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<GetUserByIdDto> Execute(GetUserByIdQuery query)
    {
        var user = await _userRepository.GetAsync(query.Id);
        return GetUserByIdDtoFactory.Create(user);
    }
}