using Application.UseCases.Tweets.Commands.CreateTweet;
using Application.UseCases.Tweets.Queries.GetTimeline;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
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
    private readonly IValidator<CreateTweetRequest> _createTweetRequestValidator;

    public TweetController(
        ILogger<TweetController> logger,
        CreateTweetService createTweetService,
        GetTimelineService getTimelineService,
        IValidator<CreateTweetRequest> createTweetRequestValidator
        )
    {
        _logger = logger;
        _createTweetService = createTweetService;
        _getTimelineService = getTimelineService;
        _createTweetRequestValidator = createTweetRequestValidator;
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CreateTweetRequest createTweetRequest)
    {
        ValidationResult validationResult = await _createTweetRequestValidator.ValidateAsync(createTweetRequest);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }
        
        await _createTweetService.Execute(CreateTweetCommandFactory.Create(createTweetRequest));
        return Results.Created();
    }
    [HttpGet("timeline")]
    public async Task<IResult> GetTimeline([FromQuery] GetTimelineRequest getTimelineRequest)
    {
        GetTimelineQuery getTimelineQuery = GetTimelineQueryFactory.Create(getTimelineRequest);
        var timeline = await _getTimelineService.Execute(getTimelineQuery);
        var timelineResponse = GetTimelineResponseFactory.Create(timeline);
        return Results.Ok(timelineResponse);
    }
}
