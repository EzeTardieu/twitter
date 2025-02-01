using Application.UseCases.Tweets.Commands.CreateTweet;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TweetController : ControllerBase
{
    private readonly ILogger<TweetController> _logger;
    private readonly CreateTweetService _createTweetService;

    public TweetController(
        ILogger<TweetController> logger,
        CreateTweetService createTweetService
        )
    {
        _logger = logger;
        _createTweetService = createTweetService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTweetCommand command)
    {
        await _createTweetService.Execute(command);
        return Ok();
    }
}
