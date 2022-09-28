namespace TwitterSampleUnitTest;

public class CommonExtensionTest
{
    [Theory]
    [MemberData(nameof(ToJsonTestData))]
    public void ToJsonTheory(TwitterData data, string jsonString)
    {
        var testObject = jsonString.ToJsonObject<TwitterData>();

        Assert.Equal(data.TwitterSettings.First().Key, testObject.TwitterSettings.First().Key);
        Assert.Equal(data.TwitterSettings.First().Value, testObject.TwitterSettings.First().Value);
    }

    public static IEnumerable<object[]> ToJsonTestData()
    {
        yield return new object[]
        {
            new TwitterData
            {
                TwitterSettings = new Dictionary<string, string>()
                {
                    { "FirstPassingTestKey", "FirstPassingTestValue" }
                }
            },
            "{ \"TwitterSettings\": { \"FirstPassingTestKey\": \"FirstPassingTestValue\" } }"
        };
    }
}