using Application.UseCases.Users.Commands.CreateUser;
using Application.UseCases.Users.Commands.DeleteUser;
using Application.UseCases.Users.Commands.FollowUser;
using Application.UseCases.Users.Commands.UpdateUser;
using Application.UseCases.Users.Queries.GetFollowing;
using Application.UseCases.Users.Queries.GetUserById;
using Application.UseCases.Users.Queries.GetUsers;
using Application.UseCases.Users.Queries.GetUserTweets;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Web.Dto;
using Web.Factories;
using Web.Validators;

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
    private readonly FollowUserService _followUserService;
    private readonly GetFollowedService _getFollowedService;
    private readonly GetUserTweetsService _getUserTweetsService;
    private readonly IValidator<CreateUserRequest> _createUserRequestValidator;

    public UserController(
        ILogger<UserController> logger,
        GetUsersService getUsersService,
        GetUserByIdService getUserByIdService,
        DeleteUserService deleteUserService,
        UpdateUserService updateUserService,
        CreateUserService createUserService,
        FollowUserService followUserService,
        GetFollowedService getFollowedService,
        GetUserTweetsService getUserTweetsService,
        IValidator<CreateUserRequest> createUserRequestValidator
        )
    {
        _logger = logger;
        _getUsersService = getUsersService;
        _getUserByIdService = getUserByIdService;
        _deleteUserService = deleteUserService;
        _updateUserService = updateUserService;
        _createUserService = createUserService;
        _followUserService = followUserService;
        _getFollowedService = getFollowedService;
        _getUserTweetsService = getUserTweetsService;
        _createUserRequestValidator = createUserRequestValidator;
    }

    [HttpGet]
    public async Task<IResult> Get()
    {
        var users = await _getUsersService.Execute(GetUsersQueryFactory.Create());
        return Results.Ok(users);
    }
    [HttpGet("{id}")]
    public async Task<IResult> Get(Guid id)
    {
        var user = await _getUserByIdService.Execute(GetUserByIdQueryFactory.Create(id));
        return Results.Ok(user);
    }
    [HttpPost]
    public async Task<IResult> Post([FromBody] CreateUserRequest request)
    {
        ValidationResult validationResult = await _createUserRequestValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }
        
        await _createUserService.Execute(CreateUserCommandFactory.Create(request));
        return Results.Created();
    }
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(Guid id)
    {
        await _deleteUserService.Execute(DeleteUserCommandFactory.Create(id));
        return Results.Ok();
    }
    [HttpPut("{id}")]
    public async Task<IResult> Put(Guid id, [FromBody] UpdateUserCommand command)
    {
        if (id != command.Id)
            return Results.BadRequest();
        
        await _updateUserService.Execute(command);
        return Results.Ok();
    }
    [HttpGet("{userId}/tweets")]
    public async Task<IResult> GetUserTweets(Guid userId)
    {

        var tweets = await _getUserTweetsService.Execute(GetUserTweetsQueryFactory.Create(userId));
        return Results.Ok(tweets);
    }
    [HttpPost("{userId}/follow")]
    public async Task<IResult> FollowUser(Guid userId, FollowUserRequest followUserDto)
    {
        FollowUserCommand followUserCommand = FollowUserCommandFactory.Create(userId, followUserDto); 
        await _followUserService.Execute(followUserCommand);
        return Results.Ok();
    }
    [HttpGet("{userId}/followed")]
    public async Task<IResult> GetFollowed(Guid userId)
    {
        GetFollowedQuery getFollowedQuery = GetFollowedQueryFactory.Create(userId); 
        Application.UseCases.Users.Queries.GetFollowed.GetFollowedDto? users = await _getFollowedService.Execute(getFollowedQuery);
        var usersResponse = GetFollowedResponseFactory.Create(users);
        return Results.Ok(usersResponse);
    }
}
