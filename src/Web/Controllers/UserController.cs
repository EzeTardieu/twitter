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
        try
        {
            var user = await _getUserByIdService.Execute(GetUserByIdQueryFactory.Create(id));
            return Results.Ok(user);
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound($"User with ID {id} not found.");
        }
    }
    [HttpPost]
    public async Task<IResult> Post([FromBody] CreateUserRequest request)
    {
        ValidationResult validationResult = await _createUserRequestValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        var newUserId = await _createUserService.Execute(CreateUserCommandFactory.Create(request));
        return Results.Created($"/user/{newUserId}", newUserId);
    }
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(Guid id)
    {
        try
        {
            await _deleteUserService.Execute(DeleteUserCommandFactory.Create(id));
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound($"User with ID {id} not found.");
        }
        return Results.Ok();
    }
    [HttpPut("{id}")]
    public async Task<IResult> Put(Guid id, [FromBody] UpdateUserRequest request)
    {
        UpdateUserCommand command = new UpdateUserCommand(id, request.Name, request.Email);
        try
        {
            await _updateUserService.Execute(command);
            return Results.Ok();
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound($"User with ID {id} not found.");
        }
    }
    [HttpGet("{userId}/tweets")]
    public async Task<IResult> GetUserTweets(Guid userId)
    {
        try
        {
            GetUserTweetsDto? GetUserTweetsDto = await _getUserTweetsService.Execute(GetUserTweetsQueryFactory.Create(userId));
            GetUserTweetsResponse response = new(userId, GetUserTweetsDto.Tweets.Select(UserTweetResponseFactory.Create));
            return Results.Ok(GetUserTweetsDto);
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound($"User with ID {userId} not found.");
        }
    }
    [HttpPost("{userId}/follow")]
    public async Task<IResult> FollowUser(Guid userId, FollowUserRequest followUserDto)
    {
        if (userId.Equals(followUserDto.UserToBeFollowedId))
            return Results.BadRequest("You cannot follow yourself.");

        FollowUserCommand followUserCommand = FollowUserCommandFactory.Create(userId, followUserDto);
        try
        {
            await _followUserService.Execute(followUserCommand);
            return Results.Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return Results.NotFound(ex.Message);
        }
    }
    [HttpGet("{userId}/followed")]
    public async Task<IResult> GetFollowed(Guid userId)
    {
        GetFollowedQuery getFollowedQuery = GetFollowedQueryFactory.Create(userId);
        try
        {
            Application.UseCases.Users.Queries.GetFollowed.GetFollowedDto? users = await _getFollowedService.Execute(getFollowedQuery);
            var usersResponse = GetFollowedResponseFactory.Create(users);
            return Results.Ok(usersResponse);
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound($"User with ID {userId} not found.");
        }
    }
}
