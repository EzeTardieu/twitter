using Application.UseCases.Tweets.Queries.GetTimeline;

namespace Web.Dto;

public class GetUserTweetsResponse
{
    public Guid UserId { get; private set; }
    public IEnumerable<UserTweetResponse> Tweets { get; private set; }
    public GetUserTweetsResponse(Guid userId, IEnumerable<UserTweetResponse> tweets)
    {
        UserId = userId;
        Tweets = tweets;
    }
}