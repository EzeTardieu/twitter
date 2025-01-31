using Application.UseCases.Users.Commands.CreateUser;
using Application.UseCases.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly GetUsersService _getUsersService;
    private readonly CreateUserService _createUserService;

    public UserController(
        ILogger<UserController> logger,
        GetUsersService getUsersService,
        CreateUserService createUserService
        )
    {
        _logger = logger;
        _getUsersService = getUsersService;
        _createUserService = createUserService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetUsersQuery query)
    {
        var result = await _getUsersService.Execute(query);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Get([FromBody] CreateUserCommand command)
    {
        await _createUserService.Execute(command);
        return Ok();
    }
}
