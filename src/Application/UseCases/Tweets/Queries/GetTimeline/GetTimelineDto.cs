namespace Application.UseCases.Tweets.Queries.GetTimeline;

public class GetTimelineDto
{
    public IEnumerable<TweetDto> Tweets { get; private set; }
    public int TotalCount { get; private set; }

    public GetTimelineDto(IEnumerable<TweetDto> tweets, int totalCount)
    {
        Tweets = tweets;
        TotalCount = totalCount;
    }
}