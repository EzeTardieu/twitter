namespace Web.Dto;

public class GetTimelineResponse
{
    public IEnumerable<TweetResponse> Tweets {get; private set;}
    public GetTimelineResponse(IEnumerable<TweetResponse> tweets)
    {
        Tweets = tweets;
    }
}