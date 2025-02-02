using Application.UseCases.Tweets.Commands.CreateTweet;
using Application.UseCases.Tweets.Commands.DeleteTweet;
using Application.UseCases.Tweets.Queries.GetTimeline;
using Application.UseCases.Tweets.Queries.GetTweet;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Web.Dto;
using Web.Factories;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TweetController : ControllerBase
{
    private readonly ILogger<TweetController> _logger;
    private readonly CreateTweetService _createTweetService;
    private readonly GetTimelineService _getTimelineService;
    private readonly DeleteTweetService _deleteTweetService;
    private readonly GetTweetService _getTweetService;
    private readonly IValidator<CreateTweetRequest> _createTweetRequestValidator;

    public TweetController(
        ILogger<TweetController> logger,
        CreateTweetService createTweetService,
        GetTimelineService getTimelineService,
        DeleteTweetService deleteTweetService,
        GetTweetService getTweetService,
        IValidator<CreateTweetRequest> createTweetRequestValidator
        )
    {
        _logger = logger;
        _createTweetService = createTweetService;
        _getTimelineService = getTimelineService;
        _deleteTweetService = deleteTweetService;
        _getTweetService = getTweetService;
        _createTweetRequestValidator = createTweetRequestValidator;
    }
    [HttpGet("{id}")]
    public async Task<IResult> Get(Guid id)
    {
        try
        {
            var tweet =await _getTweetService.Execute(GetTweetQueryFactory.Create(id));
            var response = new TweetResponse(tweet.Id,tweet.UserId,tweet.Content,tweet.Date);
            return Results.Ok(response);
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound($"Tweet with ID {id} not found.");
        }
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CreateTweetRequest createTweetRequest)
    {
        ValidationResult validationResult = await _createTweetRequestValidator.ValidateAsync(createTweetRequest);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }
        try
        {
            var newTweetId = await _createTweetService.Execute(CreateTweetCommandFactory.Create(createTweetRequest));
            return Results.Created($"/tweet/{newTweetId}", newTweetId);
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound($"User with ID {createTweetRequest.UserId} not found.");
        }
    }
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(Guid id)
    {
        try
        {
            await _deleteTweetService.Execute(DeleteTweetCommandFactory.Create(id));
            return Results.Ok();
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound($"Tweet with ID {id} not found.");
        }
    }
    [HttpGet("timeline")]
    public async Task<IResult> GetTimeline([FromQuery] GetTimelineRequest getTimelineRequest)
    {
        GetTimelineQuery getTimelineQuery = GetTimelineQueryFactory.Create(getTimelineRequest);
        try
        {
            var timeline = await _getTimelineService.Execute(getTimelineQuery);
            var timelineResponse = GetTimelineResponseFactory.Create(timeline);
            return Results.Ok(timelineResponse);
        }
        catch (KeyNotFoundException)
        {
            return Results.NotFound($"User with ID {getTimelineRequest.UserId} not found.");
        }
    }
}
