using Application.UseCases.Seeding;
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
public class SeedingController : ControllerBase
{
    private readonly ILogger<SeedingController> _logger;
    private readonly SeedDataService _seedDataService;

    public SeedingController(
        ILogger<SeedingController> logger,
        SeedDataService seedDataService
        )
    {
        _logger = logger;
        _seedDataService = seedDataService;
    }

    [HttpPost]
    public async Task<IResult> SeedData()
    {
        await _seedDataService.Execute(new SeedDataCommand());
        return Results.Created();
    }
}
