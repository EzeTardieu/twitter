using Application.UseCases.Users.Commands.CreateTweet;
using Application.UseCases.Users.Commands.CreateUser;
using Application.UseCases.Users.Commands.DeleteUser;
using Application.UseCases.Users.Commands.UpdateUser;
using Application.UseCases.Users.Queries.GetUserById;
using Application.UseCases.Users.Queries.GetUsers;
using Application.UseCases.Users.Queries.GetUserTweets;
using Microsoft.AspNetCore.Mvc;
using Web.Factories;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly GetUsersService _getUsersService;
    private readonly GetUserByIdService _getUserByIdService;
    private readonly DeleteUserService _deleteUserService;
    private readonly UpdateUserService _updateUserService;
    private readonly CreateUserService _createUserService;
    private readonly CreateTweetService _createTweetService;
    private readonly GetUserTweetsService _getUserTweetsService;

    public UserController(
        ILogger<UserController> logger,
        GetUsersService getUsersService,
        GetUserByIdService getUserByIdService,
        DeleteUserService deleteUserService,
        UpdateUserService updateUserService,
        CreateUserService createUserService,
        CreateTweetService createTweetService,
        GetUserTweetsService getUserTweetsService
        )
    {
        _logger = logger;
        _getUsersService = getUsersService;
        _getUserByIdService = getUserByIdService;
        _deleteUserService = deleteUserService;
        _updateUserService = updateUserService;
        _createUserService = createUserService;
        _createTweetService = createTweetService;
        _getUserTweetsService = getUserTweetsService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _getUsersService.Execute(GetUsersQueryFactory.Create());
        return Ok(users);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _getUserByIdService.Execute(GetUserByIdQueryFactory.Create(id));
        return Ok(user);
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        await _createUserService.Execute(command);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteUserService.Execute(DeleteUserCommandFactory.Create(id));
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserCommand command)
    {
        if (id != command.Id)
            return BadRequest();
        
        await _updateUserService.Execute(command);
        return Ok();
    }
    [HttpPost("{userId}/tweets")]
    public async Task<IActionResult> AddTweetToUser(Guid userId, [FromBody] CreateTweetCommand command)
    {
        if (userId != command.UserId)
            return BadRequest();
        
        await _createTweetService.Execute(command);
        return Ok();
    }
    [HttpGet("{userId}/tweets")]
    public async Task<IActionResult> GetUserTweets(Guid userId)
    {

        var tweets = await _getUserTweetsService.Execute(GetUserTweetsQueryFactory.Create(userId));
        return Ok(tweets);
    }
}
