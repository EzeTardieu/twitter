namespace Web.Dto;

public class GetTimelineResponse
{
    public IEnumerable<TweetResponse> Tweets { get; private set; }
    public int Total { get; private set; }
    public GetTimelineResponse(IEnumerable<TweetResponse> tweets, int total)
    {
        Tweets = tweets;
        Total = total;
    }
}