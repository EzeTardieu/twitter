using Application.UseCases.Tweets.Queries.GetTimeline;
using Domain.Entities;

namespace Application.UseCases.Tweets.Factories;
 
 internal static class GetTimelineDtoFactory
 {
    internal static GetTimelineDto Create(IEnumerable<Tweet> tweets, int totalCount)
    {
        return new GetTimelineDto(
            tweets: tweets.Select(CreateTweetDto),
            totalCount: totalCount
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