namespace TwitterService.Service.Interface;

public interface ITwitterStatService
{
    void Add(StatTracker stat);
    void IncrementTweetCount();
}