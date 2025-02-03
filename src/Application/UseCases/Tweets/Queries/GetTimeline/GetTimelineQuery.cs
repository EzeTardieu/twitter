namespace Application.UseCases.Tweets.Queries.GetTimeline;

public record GetTimelineQuery(Guid UserId, int Offset, int Limit);