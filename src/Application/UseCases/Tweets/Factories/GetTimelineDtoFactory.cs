using Application.UseCases.Tweets.Queries.GetTimeline;
using Domain.Entities;

namespace Application.UseCases.Tweets.Factories;
 
 internal static class GetTimelineDtoFactory
 {
    internal static GetTimelineDto Create(IEnumerable<Tweet> tweets)
    {
        return new GetTimelineDto(
            tweets: tweets.Select(CreateTweetDto)
        );
    }
    internal static TweetDto CreateTweetDto(Tweet tweet)
    {
        return new TweetDto(
            userName: tweet.User.Name,
            content: tweet.Content,
            date: tweet.Date
        );
    }
 }