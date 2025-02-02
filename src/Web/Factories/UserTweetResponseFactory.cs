using Application.UseCases.Users.Queries.GetUserTweets;
using Web.Dto;

namespace Web.Factories;

internal static class UserTweetResponseFactory
{
    internal static UserTweetResponse Create(TweetDto tweetDto)
    {
        return new UserTweetResponse(
            id:tweetDto.Id,
            content: tweetDto.Content,
            date: tweetDto.Date
        );
    }
}