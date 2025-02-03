namespace Web.Dto;

public class GetTimelineResponse
{
    public IEnumerable<TimelineTweetResponse> Tweets { get; private set; }
    public int Total { get; private set; }
    public GetTimelineResponse(IEnumerable<TimelineTweetResponse> tweets, int total)
    {
        Tweets = tweets;
        Total = total;
    }
}