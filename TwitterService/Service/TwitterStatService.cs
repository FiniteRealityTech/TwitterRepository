namespace TwitterModel.Model;

public class TwitterStatService : ITwitterStatService
{
    private int? Total = 0;
    private ConcurrentBag<StatTracker>? StatTracker = new();

    public void Add(StatTracker stat)
    {
        var trackedStat = StatTracker.SingleOrDefault(s => s.Value == stat.Value);

        if (trackedStat != null)
        {
            trackedStat.Count++;
            return;
        }

        StatTracker.Add(stat);
    }

    public void IncrementTweetCount()
    {
        Total++;
    }

    public override string ToString()
    {
        var topTenHashtags = StatTracker.OrderByDescending(stat => stat.Count).Take(10).Select(stat => stat.ToString());
        var hashTagString = string.Join("\n", topTenHashtags);
        return $"There have been {Total} tweets.\n\nTop ten hashtags:{hashTagString}\n";
    }
}