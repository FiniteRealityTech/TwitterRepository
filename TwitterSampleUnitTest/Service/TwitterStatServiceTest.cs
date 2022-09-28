using TwitterModel.Model;

namespace TwitterSampleUnitTest.Service;

public class TwitterStatServiceTest
{
    /// <summary>
    /// Simulate one hashtag per Tweet
    /// </summary>
    /// <param name="data"></param>
    /// <param name="toStringResult"></param>
    [Theory]
    [MemberData(nameof(StatTrackerTestData))]
    public void StatTrackerTest(List<StatTracker> data, string toStringResult)
    {
        var twitterStatService = new TwitterStatService();

        foreach (var stat in data)
        {
            twitterStatService.IncrementTweetCount();
            twitterStatService.Add(stat);
        }

        var twitterStatString = twitterStatService.ToString();
        Assert.Equal(toStringResult, twitterStatString);
    }

    public static IEnumerable<object[]> StatTrackerTestData()
    {
        yield return new object[]
        {
            new List<StatTracker>
            {
                new StatTracker
                {
                    Count = 1,
                    Value = "#Hashtag1"
                },
                new StatTracker
                {
                    Count = 1,
                    Value = "#Hashtag55"
                },
                new StatTracker
                {
                    Count = 1,
                    Value = "#Hashtag1"
                },
                new StatTracker
                {
                    Count = 1,
                    Value = "#Hashtag55"
                },
                new StatTracker
                {
                    Count = 1,
                    Value = "#Hashtag3"
                },
                new StatTracker
                {
                    Count = 1,
                    Value = "#Hashtag3"
                },
                new StatTracker
                {
                    Count = 1,
                    Value = "#Hashtag1"
                },
                new StatTracker
                {
                    Count = 1,
                    Value = "#Hashtag9"
                },
                new StatTracker
                {
                    Count = 1,
                    Value = "#Hashtag55"
                },
            },
            "There have been 9 tweets.\n\nTop ten hashtags:#Hashtag55 has a count of 3\n#Hashtag1 has a count of 3\n#Hashtag3 has a count of 2\n#Hashtag9 has a count of 1\n"
        };
    }
}