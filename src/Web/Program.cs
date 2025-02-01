
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

        builder.Services
            .AddScoped<CreateUserService>()
            .AddScoped<GetUsersService>()
            .AddScoped<GetUserByIdService>()
            .AddScoped<DeleteUserService>()
            .AddScoped<UpdateUserService>()
            .AddScoped<GetUserTweetsService>()
            ;

        builder.Services
            .AddScoped<CreateTweetService>();

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
