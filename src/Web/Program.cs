
using Microsoft.OpenApi.Models;
using Infrastructure.Data.Extensions;
using Application.UseCases.Users.Commands.CreateUser;
using Application.UseCases.Users.Queries.GetUsers;
using Application.UseCases.Users.Queries.GetUserById;
using Application.UseCases.Users.Commands.DeleteUser;
using Application.UseCases.Users.Commands.UpdateUser;
using Domain.Repositories;
using Infrastructure.Repositories;
using Application.UseCases.Users.Queries.GetUserTweets;
using Application.UseCases.Tweets.Commands.CreateTweet;
using Application.UseCases.Users.Commands.FollowUser;
using Application.UseCases.Tweets.Queries.GetTimeline;
using FluentValidation;
using Web.Dto;
using Web.Validators;
using Application.UseCases.Seeding;
using Domain.Seeding;
using Infrastructure.Data.Seeding;
using Application.UseCases.Tweets.Queries.GetTweet;
using Application.UseCases.Tweets.Commands.DeleteTweet;

namespace Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });

        //Dependency Injection
        builder.Services.AddInfrastructure();

        builder.Services.AddScoped<IUserRepository,UserRepository>();
        builder.Services.AddScoped<ITweetRepository,TweetRepository>();
        builder.Services.AddScoped<IDataSeeder, DataSeeder>();

        builder.Services
            .AddScoped<CreateUserService>()
            .AddScoped<GetUsersService>()
            .AddScoped<GetUserByIdService>()
            .AddScoped<DeleteUserService>()
            .AddScoped<UpdateUserService>()
            .AddScoped<GetUserTweetsService>()
            .AddScoped<GetFollowedService>()
            .AddScoped<FollowUserService>()
            ;

        builder.Services
            .AddScoped<CreateTweetService>()
            .AddScoped<GetTimelineService>()
            .AddScoped<GetTweetService>()
            .AddScoped<DeleteTweetService>()
            ;

        builder.Services
            .AddScoped<SeedDataService>();

        builder.Services
            .AddScoped<IValidator<GetTimelineRequest>, GetTimelineRequestValidator>()
            .AddScoped<IValidator<FollowUserCommand>, FollowUserCommandValidator>()
            .AddScoped<IValidator<CreateTweetCommand>, CreateTweetCommandValidator>()
            .AddScoped<IValidator<CreateTweetRequest>, CreateTweetRequestValidator>()
            .AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
