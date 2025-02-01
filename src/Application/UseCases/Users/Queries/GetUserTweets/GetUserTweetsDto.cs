namespace Application.UseCases.Users.Queries.GetUserTweets;

public class GetUserTweetsDto
{
    //TODO: Paginar
    public IEnumerable<TweetDto> Tweets { get; set; } = default!;
    public GetUserTweetsDto(IEnumerable<TweetDto> tweets)
    {
        Tweets = tweets;
    }
}