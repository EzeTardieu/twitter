using Application.UseCases.Users.Queries.GetUserById;
using Domain.Entities;

namespace Application.UseCases.Users.Factories;

internal static class GetUserByIdDtoFactory
{
    internal static GetUserByIdDto Create(User user)
    {
        return new(
             id: user.Id,
             name: user.Name,
             email: user.Email
         );
    }
}