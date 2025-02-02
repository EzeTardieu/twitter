using Application.UseCases.Tweets.Commands.CreateTweet;
using Application.UseCases.Tweets.Queries.GetTimeline;
using Microsoft.AspNetCore.Mvc;
using Web.Factories;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TweetController : ControllerBase
{
    private readonly ILogger<TweetController> _logger;
    private readonly CreateTweetService _createTweetService;
    private readonly GetTimelineService _getTimelineService;

    public TweetController(
        ILogger<TweetController> logger,
        CreateTweetService createTweetService,
        GetTimelineService getTimelineService
        )
    {
        _logger = logger;
        _createTweetService = createTweetService;
        _getTimelineService = getTimelineService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTweetCommand command)
    {
        await _createTweetService.Execute(command);
        return Ok();
    }
    [HttpGet("timeline")]
    public async Task<IActionResult> GetTimeline([FromQuery] Guid userId)
    {
        GetTimelineQuery getTimelineQuery = new (userId);
        var timeline = await _getTimelineService.Execute(getTimelineQuery);
        var timelineResponse = GetTimelineResponseFactory.Create(timeline);
        return Ok(timelineResponse);
    }
}
