namespace Application.UseCases.Users.Queries.GetUserTweets;

public class GetUserTweetsDto
{
    //TODO: Paginar
    public ICollection<TweetDto> Tweets { get; set; } = default!;
    public GetUserTweetsDto(ICollection<TweetDto> tweets)
    {
        Tweets = tweets;
    }
}