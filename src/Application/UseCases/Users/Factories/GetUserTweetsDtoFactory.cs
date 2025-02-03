using Application.UseCases.Users.Queries.GetUserTweets;
using Domain.Entities;

namespace Application.UseCases.Users.Factories;

internal static class GetUserTweetsDtoFactory
{
    internal static GetUserTweetsDto Create(User user)
    {
        return new GetUserTweetsDto(user.Tweets.Select(TweetDtoFactory.Create));
    }
}